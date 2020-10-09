using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using agora_gaming_rtc;



public class SpatialAudio : Photon.MonoBehaviour
{
    [Header("Agora Attributes")]
    private IRtcEngine agoraEngine;
    private IAudioEffectManager agoraAudioEffects;
    private SphereCollider agoraChatRadius;
    private AgoraVideoChat agoraScript;

    private List<Transform> players;
    private List<uint> playerUIDs;
    private bool searchingNetworkForIDs = false;

    private const float MAX_CHAT_PROXIMITY = 1.5f;
    private const float PAN_MIN = -1f;
    private const float PAN_MAX = 1f;

    void Start()
    {
        agoraScript = GetComponent<AgoraVideoChat>();
        agoraChatRadius = GetComponent<SphereCollider>();

        if (photonView.isMine)
        {
            agoraEngine = agoraScript.GetRtcEngine();
            agoraAudioEffects = agoraEngine.GetAudioEffectManager();
        }

        players = new List<Transform>();
        playerUIDs = new List<uint>();
    }

    IEnumerator AddNetworkedPlayerToSpatialAudioList(Collider otherPlayer)
    {
        if (searchingNetworkForIDs == true)
            yield break;

        if(photonView.isMine)
        {
            searchingNetworkForIDs = true;

            // When players spawn in, they can spawn on top of each other within 1-2 frames.
            // The photon network needs a little longer to populate the proper IDs which can mess up functionality
            // This timer is to give the Photon network 2 seconds to populate the proper IDs or the trigger overlap is nullified
            uint triggerPlayerID = otherPlayer.GetComponent<AgoraVideoChat>().GetNetworkedUID();
            float networkTimer = 2f;
            float networkWaitTime = 0f;

            while (triggerPlayerID == 0)
            {
                triggerPlayerID = otherPlayer.GetComponent<AgoraVideoChat>().GetNetworkedUID();
                networkWaitTime += Time.deltaTime;
                if (networkWaitTime >= networkTimer)
                {
                    Debug.LogError("Photon network time out for finding player network ID on player: " + otherPlayer.gameObject.name);
                    yield break;
                }
                yield return null;
            }

            // Now that we have made sure our network IDs are loaded, we can add players to the list
            bool isDuplicatePlayer = false;
            foreach (Transform player in players)
            {
                if (otherPlayer.transform == player)
                {
                    isDuplicatePlayer = true;
                    break;
                }
            }
            if (isDuplicatePlayer == false)
            {
                players.Add(otherPlayer.transform);
                playerUIDs.Add(triggerPlayerID);
            }

            searchingNetworkForIDs = false;
        }   
    }

    private void OnTriggerEnter(Collider other)
    {
        if(photonView.isMine && other.CompareTag("Player"))
        {
            StartCoroutine(AddNetworkedPlayerToSpatialAudioList(other));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(photonView.isMine && other.CompareTag("Player"))
        {
            for (int i = 0; i < players.Count; i++)
            {
                if (other.transform == players[i])
                {
                    agoraAudioEffects.SetRemoteVoicePosition(playerUIDs[i], 0, 0);
                    players.RemoveAt(i);
                    playerUIDs.RemoveAt(i);
                    break;
                }
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (photonView.isMine && other.CompareTag("Player"))
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
