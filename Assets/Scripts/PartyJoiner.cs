using UnityEngine;
using UnityEngine.UI;

/* NOTE: 
 *
 * This script handles the Photon Network functionality, and the UI required to access player parties:
 * - 
 * - 
 * - 
 *
 */

public class PartyJoiner : Photon.MonoBehaviour
{
    [Header("Local Player Stats")]
    [SerializeField]
    private Button inviteButton;
    [SerializeField]
    private GameObject joinButton;
    [SerializeField]
    private GameObject leaveButton;

    [Header("Remote Player Stats")]
    [SerializeField]
    private int remotePlayerViewID;
    [SerializeField]
    private string remoteInviteChannelName = null;

    private AgoraVideoChat agoraVideo;

    private void Awake()
    {
        agoraVideo = GetComponent<AgoraVideoChat>();
    }

    private void Start()
    {
        if(!photonView.isMine)
        {
            // Disable the Canvas of remote users - If we didn't, everyone's canvas would render to all screens.
            transform.GetChild(0).gameObject.SetActive(false);
        }

        inviteButton.interactable = false;
        joinButton.SetActive(false);
        leaveButton.SetActive(false);
    }

    private void OnEnable()
    {
        AgoraVideoChat.PlayerChatIsEmpty += DisableLeaveButton;
        AgoraVideoChat.PlayerChatIsPopulated += EnableLeaveButton;
    }

    private void OnDisable()
    {
        AgoraVideoChat.PlayerChatIsEmpty -= DisableLeaveButton;
        AgoraVideoChat.PlayerChatIsPopulated -= EnableLeaveButton;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!photonView.isMine || !other.CompareTag("Player"))
        {
            return;
        }

        // Get a reference to the player that we are standing next to in our Trigger Volume.
        PhotonView otherPlayerPhotonView = other.GetComponent<PhotonView>();
        if (otherPlayerPhotonView != null)
        {
            remotePlayerViewID = otherPlayerPhotonView.viewID;
            inviteButton.interactable = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(!photonView.isMine || !other.CompareTag("Player"))
        {
            return;
        }

        // Remove that player reference when they walk away.
        remoteInviteChannelName = null;    
        inviteButton.interactable = false;
        joinButton.SetActive(false);
    }

    public void OnInviteButtonPress()
    {
        // Sends out a ping across the Photon network to check if any players have this "Invite" function attached.
        PhotonView.Find(remotePlayerViewID).RPC("InvitePlayerToPartyChannel", PhotonTargets.All, remotePlayerViewID, agoraVideo.GetCurrentChannel());
    }

    [PunRPC]
    public void InvitePlayerToPartyChannel(int invitedID, string channelName)
    {
        // When the invited ID matches the correct player ID, update their canvas and tell them what Agora channel to join.
        if (photonView.isMine && invitedID == photonView.viewID)
        {
            joinButton.SetActive(true);
            remoteInviteChannelName = channelName;
        }
    }

    public void OnJoinButtonPress()
    {
        if (photonView.isMine && remoteInviteChannelName != null)
        {
            agoraVideo.JoinRemoteChannel(remoteInviteChannelName);
            joinButton.SetActive(false);
            leaveButton.SetActive(true);
        }
    }

    public void OnLeaveButtonPress()
    {
        if(photonView.isMine)
        {
            agoraVideo.JoinOriginalChannel();
            leaveButton.SetActive(false);
        }
    }

    private void EnableLeaveButton()
    {
        if(photonView.isMine)
        {
            leaveButton.SetActive(true);
        }
    }

    private void DisableLeaveButton()
    {
        if(photonView.isMine)
        {
            leaveButton.SetActive(false);
        }
    }
}