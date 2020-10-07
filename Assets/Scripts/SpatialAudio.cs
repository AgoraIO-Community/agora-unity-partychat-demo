using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using agora_gaming_rtc;


// What I need to do:
/*
 * when a player crosses the trigger zone
    
    6 = minimum volume
    1.5 = maximum volume





    * get the position and orientation values for a player
    * get that players UID
    * Use two lists Player | UID
    * Calucualte Data on Player[0] | setRemoteVoicePosition(uidList[0], pan, gain);


*/



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


    // Start is called before the first frame update
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

    private void OnTriggerEnter(Collider other)
    {
        if(!photonView.isMine)
        {
            return;
        }

        if(other.CompareTag("Player"))
        {
            // check if collided player UID is already in the list
            foreach (Transform player in players)
            {
                if (other.transform == player)
                {
                    return;
                }
            }

            // if player doesn't match add player transform to list
            players.Add(other.transform);
            playerUIDs.Add(other.GetComponent<AgoraVideoChat>().GetNetworkedUID());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(!photonView.isMine)
        {
            return;
        }

        if(other.CompareTag("Player"))
        {
            int index = 0;
            for (int i = 0; i < players.Count - 1; i++)
            {
                if (other.transform == other)
                {
                    index = i;
                    break;
                }
            }

            players.RemoveAt(index);
            playerUIDs.RemoveAt(index);
        }
    }

    private void OnTriggerStay(Collider other)
    {



        if(photonView.isMine && other.CompareTag("Player"))
        {
            // for (int i = 0; i < playerList; i++)
            // {
            /*      float gain = Distance to player
             *      float pan = orientation to player
             *      setRemoteVoicePosition(uidList[i], gain, pan);
             * }
             * 
             */


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

    //    float gain = 100f - 50f * direction.magnitude / availablePeerRect.height;
    //    if (gain < 20)
    //    {
    //        gain = 20f;
    //    }

    //    return new Vector2(pan, gain);
    //}

    //public void UpdateAgoraAudioPan(int panDirection)
    //{
    //    if (!photonView.isMine)
    //        return;

    //    currentPanDirection = Mathf.Clamp(currentPanDirection + panDirection, -1, 1);

    //    Debug.LogWarning("current pan direction: " + currentPanDirection);



    //    int audioSuccess = agoraAudioEffects.SetRemoteVoicePosition(remoteUID, currentPanDirection, currentGainAmount);
    //    Debug.LogWarning("set agora pan success: " + audioSuccess);
    //}

    void CalculateGainAmount(float distanceToPlayer)
    {
        // Lerp gain value between
        // Distance 6 = Gain 0
        // Distance 1.5 = Gain 100

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
