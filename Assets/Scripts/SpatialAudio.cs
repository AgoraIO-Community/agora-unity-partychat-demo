using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using agora_gaming_rtc;

// when a user joins in, I need to automatically add them to my player list
// when a user joins in, search Scene for gameobjects by "Player" tag
// Check for networked UID, if not found, add UID and player to the lists

// First player is spawned via photon
// Then agora stuff kicks in
// photon network ID is discovered .25 seconds after spawn. 
// when a new user joins in, all users scan the entire field for new networked IDs - add users to spatial audio list



public class SpatialAudio : Photon.MonoBehaviour
{
    [Header("Agora Attributes")]
    private IRtcEngine agoraEngine;
    private IAudioEffectManager agoraAudioEffects;
    private SphereCollider agoraChatRadius;
    private AgoraVideoChat agoraScript;
    [SerializeField]
    private List<Transform> players;
    [SerializeField]
    private List<uint> playerUIDs;
    //private bool searchingNetworkForIDs = false;

    private const float MAX_CHAT_PROXIMITY = 1.5f;
    private const float PAN_MIN = -1f;
    private const float PAN_MAX = 1f;

    void Start()
    {
        if (photonView.isMine)
        {
            agoraScript = GetComponent<AgoraVideoChat>();
            agoraChatRadius = GetComponent<SphereCollider>();

            agoraEngine = agoraScript.GetRtcEngine();
            agoraAudioEffects = agoraEngine.GetAudioEffectManager();

            agoraEngine.OnUserJoined += OnUserJoinedHandler;
            agoraEngine.OnUserOffline += OnUserOfflineHandler;

            players = new List<Transform>();
            playerUIDs = new List<uint>();

            StartCoroutine(AddNetworkedPlayersToSpatialAudioList());
        }
    }

    private void Update()
    {
        UpdateSpatialAudio();
    }

    IEnumerator AddNetworkedPlayersToSpatialAudioList()
    {
        if (photonView.isMine == false)
        {
            yield break;
        }

        GameObject[] otherPlayers = GameObject.FindGameObjectsWithTag("Player");

        foreach (GameObject player in otherPlayers)
        {
            if (player == this.gameObject)
            {
                continue;
            }

            uint playerNetworkID = player.GetComponent<AgoraVideoChat>().GetNetworkedUID();

            float networkTimer = 2f;
            float networkWaitTime = 0f;
            while (playerNetworkID == 0)
            {
                playerNetworkID = player.GetComponent<AgoraVideoChat>().GetNetworkedUID();
                networkWaitTime += Time.deltaTime;
                if (networkWaitTime >= networkTimer)
                {
                    Debug.LogError("Photon network time out for finding player network ID on player: " + player.name);
                    break;
                }

                yield return new WaitForSeconds(.05f);
            }

            bool isPlayerAlreadyInList = false;
            foreach (uint playerID in playerUIDs)
            {
                if (playerNetworkID == playerID)
                {
                    isPlayerAlreadyInList = true;
                    break;
                }
            }

            if (isPlayerAlreadyInList == false)
            {
                players.Add(player.transform);
                playerUIDs.Add(playerNetworkID);
            }
        }
    }

    // Remote Client Joins Channel.
    private void OnUserJoinedHandler(uint uid, int elapsed)
    {
        if (photonView.isMine)
        {
            StartCoroutine(AddNetworkedPlayersToSpatialAudioList());
        }
    }

    // Remote User Leaves the Channel.
    private void OnUserOfflineHandler(uint uid, USER_OFFLINE_REASON reason)
    {
        if (photonView.isMine)
        {
            for (int i = 0; i < playerUIDs.Count; i++)
            {
                if (uid == playerUIDs[i])
                {
                    playerUIDs.RemoveAt(i);
                    players.RemoveAt(i);
                    break;
                }
            }
        }
    }

    void UpdateSpatialAudio()
    {
        if (photonView.isMine)
        {
            for (int i = 0; i < players.Count; i++)
            {
                float distanceToPlayer = Vector3.Distance(transform.position, players[i].position);
                float gain = GetGainByPlayerDistance(distanceToPlayer);
                float pan = GetPanByPlayerOrientation(players[i]);

                agoraAudioEffects.SetRemoteVoicePosition(playerUIDs[i], pan, gain);
            }
        }
    }

    float GetGainByPlayerDistance(float distanceToPlayer)
    {
        // Agora -- Gain Attributes -- Unity Distance
        //  100        Max Gain        MAX_CHAT_PROXIMITY [1.5f] (as close as the player can get to another remote player)
        //   0         Min Gain        agoraChatRadius [6f] (anything past this distance will be muted)
        // if player is too far, gain is 0 (min volume)

        // Clamp incoming distance to Min and Max values
        distanceToPlayer = Mathf.Clamp(distanceToPlayer, MAX_CHAT_PROXIMITY, agoraChatRadius.radius);

        // Normalize the result between a value of 0f - 100f;
        float gain = (distanceToPlayer - agoraChatRadius.radius) / (MAX_CHAT_PROXIMITY - agoraChatRadius.radius);
        gain *= 100;

        return gain;
    }

    float GetPanByPlayerOrientation(Transform otherPlayer)
    {
        // Agora -- Pan Attributes -- Dot Product
        //  -1          Left            0.0f
        //   0          Center          0.5f
        //   1          Right           1.0f

        // Summary:
        // I need to know to what amount the remote player is to the left or right of me, to determine how much of their voice to send to each ear.
        // To find this info, the dot product is utilized.

        // Step 1: Get the dot product between the vector pointing from local towards the remote player,
        // and right-facing vector of local player
        Vector3 directionToRemotePlayer = otherPlayer.position - transform.position;

        // (The length of the vector isn't important for this calculation, so the vector is normalized).
        directionToRemotePlayer.Normalize();

        // A value between -1 and 1 is produced, indicating the orientation of local player to the remote player.
        float dot = Vector3.Dot(transform.right, directionToRemotePlayer);

        // The resulting dot product range of (-1, 1) is normalized to (0,1) to utilize Unity's Lerp function. 
        float normalizedDot = (dot - PAN_MIN) / (PAN_MAX - PAN_MIN);

        float pan = Mathf.Lerp(-1, 1, normalizedDot);

        return pan;
    }
}