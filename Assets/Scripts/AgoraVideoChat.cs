using System.Collections.Generic;
using UnityEngine; 
using agora_gaming_rtc;



/* NOTE: 
 *
 * This script handles the Agora-related functionality:
 * - Joining / Leaving Channels
 * - Creating / Deleting VideoSurface objects that enable us to see the camera feed of Agora party chat
 * - Managing the UI that contains the VideoSurface objects 
 *
 */



public class AgoraVideoChat : Photon.MonoBehaviour
{
    [Header("Agora Properties")]
    [SerializeField]
    private string appID = "57481146914f4cddaa220d6f7a045063";
    [SerializeField]
    private string channel = "unity3d";
    private string originalChannel;
    private IRtcEngine mRtcEngine;
    private uint myUID = 0;

    [Header("Player Video Panel Properties")]
    [SerializeField]
    private GameObject userVideoPrefab;
    [SerializeField]
    private Transform spawnPoint;
    [SerializeField]
    private RectTransform content;
    [SerializeField]
    private float spaceBetweenUserVideos = 150f;
    private List<GameObject> playerVideoList;

    public delegate void AgoraCustomEvent();
    public static event AgoraCustomEvent PlayerChatIsEmpty;
    public static event AgoraCustomEvent PlayerChatIsPopulated;

    void Start()
    {
        if (!photonView.isMine)
        {
            return;
        }
            

        playerVideoList = new List<GameObject>();

        // Setup Agora Engine and Callbacks.
        if(mRtcEngine != null)
        {
            IRtcEngine.Destroy();
        }

        originalChannel = channel;

        // -- These are all necessary steps to initialize the Agora engine -- //
        // Initialize Agora engine
        mRtcEngine = IRtcEngine.GetEngine(appID);

        // Setup our callbacks (there are many other Agora callbacks, however these are the calls we need).
        mRtcEngine.OnJoinChannelSuccess = OnJoinChannelSuccessHandler;
        mRtcEngine.OnUserJoined = OnUserJoinedHandler;
        mRtcEngine.OnLeaveChannel = OnLeaveChannelHandler;
        mRtcEngine.OnUserOffline = OnUserOfflineHandler;

        // Your video feed will not render if EnableVideo() isn't called. 
        mRtcEngine.EnableVideo();
        mRtcEngine.EnableVideoObserver();

        // By setting our UID to "0" the Agora Engine creates a new one and assigns it. 
        mRtcEngine.JoinChannel(channel, null, 0);
    }

    public string GetCurrentChannel() => channel;

    public void JoinRemoteChannel(string remoteChannelName)
    {
        if (!photonView.isMine)
        {
            return;
        } 

        mRtcEngine.LeaveChannel();

        mRtcEngine.JoinChannel(remoteChannelName, null, myUID);
        mRtcEngine.EnableVideo();
        mRtcEngine.EnableVideoObserver();

        channel = remoteChannelName;
    }

    /// <summary>
    /// Resets player Agora video chat party, and joins their original channel.
    /// </summary>
    public void JoinOriginalChannel()
    {
        if (!photonView.isMine)
        {
            return;
        }


        /* NOTE:
         * Say I'm in my original channel - "myChannel" - and someone joins me.
         * If I want to leave the party, and go back to my original channel, someone is already in it!
         * Therefore, if someone is inside "myChannel" and I want to be alone, I have to join a new channel that has the name of my unique Agora UID "304598093" (for example).
         */
        if(channel != originalChannel || channel == myUID.ToString())
        {
            channel = originalChannel;
        }
        else if(channel == originalChannel)
        {
            channel = myUID.ToString();
        }

        JoinRemoteChannel(channel);
    }

    #region Agora Callbacks
    // Local Client Joins Channel.
    private void OnJoinChannelSuccessHandler(string channelName, uint uid, int elapsed)
    {
        if (!photonView.isMine)
            return;

        myUID = uid;

        CreateUserVideoSurface(uid, true);
    }

    // Remote Client Joins Channel.
    private void OnUserJoinedHandler(uint uid, int elapsed)
    {
        if (!photonView.isMine)
            return;

        CreateUserVideoSurface(uid, false);
    }

    // Local user leaves channel.
    private void OnLeaveChannelHandler(RtcStats stats)
    {
        if (!photonView.isMine)
            return;

        foreach (GameObject player in playerVideoList)
        {
            Destroy(player.gameObject);
        }
        playerVideoList.Clear();
    }

    // Remote User Leaves the Channel.
    private void OnUserOfflineHandler(uint uid, USER_OFFLINE_REASON reason)
    {
        if (!photonView.isMine)
            return;

        if (playerVideoList.Count <= 1)
        {
            PlayerChatIsEmpty();
        }

        RemoveUserVideoSurface(uid);
    }
    #endregion

    // Create new image plane to display users in party.
    private void CreateUserVideoSurface(uint uid, bool isLocalUser)
    {
        // Avoid duplicating Local player VideoSurface image plane.
        for (int i = 0; i < playerVideoList.Count; i++)
        {
            if (playerVideoList[i].name == uid.ToString())
            {
                return;
            }
        }

        // Get the next position for newly created VideoSurface to place inside UI Container.
        float spawnY = playerVideoList.Count * spaceBetweenUserVideos;
        Vector3 spawnPosition = new Vector3(0, -spawnY, 0);

        // Create Gameobject that will serve as our VideoSurface.
        GameObject newUserVideo = Instantiate(userVideoPrefab, spawnPosition, spawnPoint.rotation);
        if (newUserVideo == null)
        {
            Debug.LogError("CreateUserVideoSurface() - newUserVideoIsNull");
            return;
        }
        newUserVideo.name = uid.ToString();
        newUserVideo.transform.SetParent(spawnPoint, false);
        newUserVideo.transform.rotation = Quaternion.Euler(Vector3.right * -180);

        playerVideoList.Add(newUserVideo);

        // Update our VideoSurface to reflect new users
        VideoSurface newVideoSurface = newUserVideo.GetComponent<VideoSurface>();
        if(newVideoSurface == null)
        {
            Debug.LogError("CreateUserVideoSurface() - VideoSurface component is null on newly joined user");
            return;
        }

        if (isLocalUser == false)
        {
            newVideoSurface.SetForUser(uid);
        }
        newVideoSurface.SetGameFps(30);

        // Update our "Content" container that holds all the newUserVideo image planes
        content.sizeDelta = new Vector2(0, playerVideoList.Count * spaceBetweenUserVideos + 140);

        UpdatePlayerVideoPostions();
        UpdateLeavePartyButtonState();
    }

    private void RemoveUserVideoSurface(uint deletedUID)
    {
        foreach (GameObject player in playerVideoList)
        {
            if (player.name == deletedUID.ToString())
            {
                playerVideoList.Remove(player);
                Destroy(player.gameObject);
                break;
            }
        }

        // update positions of new players
        UpdatePlayerVideoPostions();

        Vector2 oldContent = content.sizeDelta;
        content.sizeDelta = oldContent + Vector2.down * spaceBetweenUserVideos;
        content.anchoredPosition = Vector2.zero;

        UpdateLeavePartyButtonState();
    }

    private void UpdatePlayerVideoPostions()
    {
        for (int i = 0; i < playerVideoList.Count; i++)
        {
            playerVideoList[i].GetComponent<RectTransform>().anchoredPosition = Vector2.down * spaceBetweenUserVideos * i;
        }
    }

    private void UpdateLeavePartyButtonState()
    {
        if (playerVideoList.Count > 1)
        {
            PlayerChatIsPopulated();
        }
        else
        {
            PlayerChatIsEmpty();
        }
    }

    // Cleaning up the Agora engine during OnApplicationQuit() is an essential part of the Agora process with Unity. 
    private void OnApplicationQuit()
    {
        if(mRtcEngine != null)
        {
            mRtcEngine.LeaveChannel();
            mRtcEngine = null;
            IRtcEngine.Destroy();
        }
    }
}