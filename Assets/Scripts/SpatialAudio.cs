using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using agora_gaming_rtc;



public class SpatialAudio : Photon.MonoBehaviour
{
    private IRtcEngine agoraEngine;
    private IAudioEffectManager agoraAudioEffects;
    public uint remoteUID = 0;
    public int currentPanDirection = 0;
    public int currentGainAmount = 100;

    private AgoraVideoChat agoraScript;

    public List<Transform> players;
    public List<uint> playerUIDs;
    bool searchingNetworkForIDs = false;

    void Start()
    {
        agoraScript = GetComponent<AgoraVideoChat>();

        if (photonView.isMine)
        {
            agoraEngine = agoraScript.GetRtcEngine();
            agoraAudioEffects = agoraEngine.GetAudioEffectManager();
        }

        players = new List<Transform>();
        playerUIDs = new List<uint>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            // pan left
            //UpdateAgoraAudioPan(-1);
        }
        else if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            // pan right
            //UpdateAgoraAudioPan(1);
        }
        else if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            UpdateAgoraAudioGain(20);
        }
        else if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            UpdateAgoraAudioGain(-20);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position, -transform.forward);

        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.forward);
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
                float pan = GetPanByPlayerOrientation();

                agoraAudioEffects.SetRemoteVoicePosition(playerUIDs[i], pan, gain);
            }

            Debug.DrawRay(transform.position, other.transform.position - transform.position, Color.yellow);
        }
    }

    ////point
    //Vector2 PanAndGain(Vector2 point)
    //{
    //    Vector2 midBottom = new Vector2(x: (availablePeerRect.xMax + availablePeerRect.xMin) / 2, y: availablePeerRect.yMin);
    //    Vector2 direction = point - midBottom;

    //    float pan = 0;
    //    if (direction == Vector2.zero)
    //    {
    //        pan = 0;
    //    }
    //    else if (direction.y == 0)
    //    {
    //        pan = direction.x > 0 ? 1 : -1;
    //    }
    //    else
    //    {
    //        pan = Mathf.Atan(direction.x / direction.y) / Mathf.PI * 2;
    //    }

    float GetGainByPlayerDistance(float distanceToPlayer)
    {
        distanceToPlayer = Mathf.Clamp(distanceToPlayer, 1.5f, 3f);
        float gain = 100f + ((-100f * distanceToPlayer) + 150f) / 1.5f;

        return gain;
    }

    float GetPanByPlayerOrientation()
    {
        float pan = 0;

        // if other player is in front of me
            // on left = left ear
            // on right = right ear

        // if other player is behind me
            // on left = right ear
            // on righ = left ear

        return pan;
    }


    void UpdateAgoraAudioGain(int changeInGain)
    {
        if (!photonView.isMine)
            return;

        currentGainAmount = Mathf.Clamp(currentGainAmount + changeInGain, 0, 100);
        Debug.LogWarning("current gain amount: " + currentGainAmount);

        int audioSuccess = agoraAudioEffects.SetRemoteVoicePosition(remoteUID, currentPanDirection, currentGainAmount);
        Debug.LogWarning("set agora gain success: " + audioSuccess);
    }
}
