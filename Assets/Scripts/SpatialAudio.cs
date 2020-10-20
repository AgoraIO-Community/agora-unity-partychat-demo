using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using agora_gaming_rtc;

public class SpatialAudio : Photon.MonoBehaviour
{
    [Header("Agora Attributes")]
    private IRtcEngine agoraEngine;

    [SerializeField]
    private List<Transform> players;
    [SerializeField]
    private List<uint> playerUIDs;

    private IAudioEffectManager agoraAudioEffects;
    private SphereCollider agoraChatRadius;
    private AgoraVideoChat agoraScript;

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
        // Clamp incoming distance to Min and Max values
        distanceToPlayer = Mathf.Clamp(distanceToPlayer, MAX_CHAT_PROXIMITY, agoraChatRadius.radius);

        // Normalize the result between a value of 0f - 100f;
        float gain = (distanceToPlayer - agoraChatRadius.radius) / (MAX_CHAT_PROXIMITY - agoraChatRadius.radius);
        gain *= 100;

        return gain;
    }

    float GetPanByPlayerOrientation(Transform otherPlayer)
    {
        // Get the dot product between the vector pointing from local towards the remote player,
        // and right-facing vector of local player
        Vector3 directionToRemotePlayer = otherPlayer.position - transform.position;

        // The length of the vector isn't important for this calculation, so the vector is normalized
        directionToRemotePlayer.Normalize();

        // When normazlid, a value between -1 and 1 is produced, indicating the orientation of local player to the remote player
        float pan = Vector3.Dot(transform.right, directionToRemotePlayer);

        return pan;
    }
}