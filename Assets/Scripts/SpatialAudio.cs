using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using agora_gaming_rtc;

public enum PanControl
{
    LEFT = -1,
    RIGHT = 1
};

public class SpatialAudio : Photon.MonoBehaviour
{

    private IRtcEngine agoraEngine;
    private IAudioEffectManager agoraAudioEffects;
    private uint UID = 0;
    private int currentPanDirection = 0;
    private int currentGainAmount = 100;

    private AgoraVideoChat agoraScript;

    // Start is called before the first frame update
    void Start()
    {
        agoraScript = GetComponent<AgoraVideoChat>();

        GetAgoraStats();
    }

    void GetAgoraStats()
    {
        if(photonView.isMine)
        {
            agoraEngine = agoraScript.GetRtcEngine();
            UID = agoraScript.GetCurrentUID();
            agoraAudioEffects = agoraEngine.GetAudioEffectManager();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            // pan left
            UpdateAgoraAudioPan(-1);
        }
        else if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            // pan right
            UpdateAgoraAudioPan(1);
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

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player"))
        {
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

    public void UpdateAgoraAudioPan(int panDirection)
    {
        if (!photonView.isMine)
            return;

        currentPanDirection = Mathf.Clamp(currentPanDirection + panDirection, -1, 1);

        Debug.LogWarning("current pan direction: " + currentPanDirection);

        if (UID == 0)
        {
            GetAgoraStats();
            return;
        }

        int audioSuccess = agoraAudioEffects.SetRemoteVoicePosition(UID, currentPanDirection, currentGainAmount);
        Debug.LogWarning("set agora pan success: " + audioSuccess);
    }

    void UpdateAgoraAudioGain(int changeInGain)
    {
        if (!photonView.isMine)
            return;

        currentGainAmount = Mathf.Clamp(currentGainAmount + changeInGain, 0, 100);
        Debug.LogWarning("current gain amount: " + currentGainAmount);

        if(UID == 0)
        {
            GetAgoraStats();
            return;
        }

        int audioSuccess = agoraAudioEffects.SetRemoteVoicePosition(UID, currentPanDirection, currentGainAmount);
        Debug.LogWarning("set agora gain success: " + audioSuccess);
    }
}
