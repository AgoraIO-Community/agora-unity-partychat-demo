using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using agora_gaming_rtc;

public class InCallStats : Photon.MonoBehaviour
{
    private bool isBroadcaster;

    private AgoraVideoChat agoraScript;
    private IRtcEngine agoraEngine;

    private LocalVideoStats broadcasterVideoStats;
    private RemoteVideoStats audienceVideoStats;

    private bool fallbackToAudioOnly;

    // Start is called before the first frame update
    void Start()
    {
        if(photonView.isMine)
        {
            agoraEngine = null;
            isBroadcaster = false;
            fallbackToAudioOnly = false;
            agoraScript = GetComponent<AgoraVideoChat>();

            StartCoroutine(AgoraEngineSetup());
        }
    }

    IEnumerator AgoraEngineSetup()
    {
        if(photonView.isMine)
        {
            agoraEngine = agoraScript.GetAgoraEngine();
            float engineTimer = 0f;
            float engineTimeout = 3f;


            while (agoraEngine == null)
            {
                agoraEngine = agoraScript.GetAgoraEngine();
                engineTimer += Time.deltaTime;

                if (engineTimer >= engineTimeout)
                {
                    Debug.LogError("No Agora Engine Found.");
                    yield break;
                }

                yield return null;
            }

            InitializeStreamFallback();
        }
    }

    void InitializeStreamFallback()
    {
        if (photonView.isMine)
        {
            agoraEngine.SetChannelProfile(CHANNEL_PROFILE.CHANNEL_PROFILE_LIVE_BROADCASTING);

            // Enables high and low bitrate data streams to subscribe to for variable network conditions.
            agoraEngine.EnableDualStreamMode(true);

            // First player into the game is the PUBLISHER...
            if (photonView.ownerId == 1)
            {                
                agoraEngine.SetClientRole(CLIENT_ROLE_TYPE.CLIENT_ROLE_BROADCASTER);
                isBroadcaster = true;

                // Occurs when the locally published media stream falls back to an audio-only stream due to poor network conditions,
                // or switches back to the video after the network conditions improve.
                agoraEngine.SetLocalPublishFallbackOption(STREAM_FALLBACK_OPTIONS.STREAM_FALLBACK_OPTION_AUDIO_ONLY);
            }
            // ...all other joining players are SUBSCRIBERS.
            else
            {
                agoraEngine.SetClientRole(CLIENT_ROLE_TYPE.CLIENT_ROLE_AUDIENCE);

                // Occurs when the remote media stream falls back etc.
                agoraEngine.SetRemoteSubscribeFallbackOption(STREAM_FALLBACK_OPTIONS.STREAM_FALLBACK_OPTION_AUDIO_ONLY);
            }

            agoraEngine.OnLocalPublishFallbackToAudioOnly = OnLocalPublishFallbackToAudioOnlyCallback;
            agoraEngine.OnRemoteSubscribeFallbackToAudioOnly = OnRemoteSubscribeFallbackToAudioOnlyCallback;
            agoraEngine.OnRemoteVideoStats = OnRemoteVideoStatsCallback;
            agoraEngine.OnLocalVideoStats = OnLocalVideoStatsCallback;
        }
    }

    void OnLocalPublishFallbackToAudioOnlyCallback(bool isFallbackOrRecover)
    {
        if(photonView.isMine)
        {
            print("Local publish fallback - is falling back to audio only: " + isFallbackOrRecover);
            fallbackToAudioOnly = isFallbackOrRecover;
        }
    }

    void OnRemoteSubscribeFallbackToAudioOnlyCallback(uint uid, bool isFallbackOrRecover)
    {
        if(photonView.isMine)
        {
            print("Remote subscribe fallback - UID of remote user: " + uid + " - is falling back to audio only: " + isFallbackOrRecover);
            fallbackToAudioOnly = isFallbackOrRecover;
        }
    }

    void OnRemoteVideoStatsCallback(RemoteVideoStats remoteVideoStats)
    {
        if (photonView.isMine)
        {
            audienceVideoStats = remoteVideoStats;
        }
    }

    void OnLocalVideoStatsCallback(LocalVideoStats localVideoStats)
    {
        if(photonView.isMine)
        {
            broadcasterVideoStats = localVideoStats;
        }
    }

    private void OnGUI()
    {
        // Rect(left most, top most, total width, total height)

        if(photonView.isMine)
        {
            if (isBroadcaster)
            {
                GUI.Box(new Rect(Screen.width - 200, 0, 200, 260), "Agora Local Broadcaster Stats");
                GUI.Label(new Rect(Screen.width - 195, 15, 200, 200), "target bitrate: " + broadcasterVideoStats.targetBitrate);
                GUI.Label(new Rect(Screen.width - 195, 30, 200, 200), "sent bitrate:  " + broadcasterVideoStats.sentBitrate);
                GUI.Label(new Rect(Screen.width - 195, 45, 200, 200), "target framerate: " + broadcasterVideoStats.targetFrameRate);
                GUI.Label(new Rect(Screen.width - 195, 60, 200, 200), "sent framerate: " + broadcasterVideoStats.sentFrameRate);
                GUI.Label(new Rect(Screen.width - 195, 75, 200, 200), "encoder output framerate: " + broadcasterVideoStats.encoderOutputFrameRate);
                GUI.Label(new Rect(Screen.width - 195, 90, 200, 200), "renderer output framerate: " + broadcasterVideoStats.rendererOutputFrameRate);
                GUI.Label(new Rect(Screen.width - 195, 105, 200, 200), "encoded bitrate: " + broadcasterVideoStats.encodedBitrate);
                GUI.Label(new Rect(Screen.width - 195, 120, 200, 200), "encoded frame count: " + broadcasterVideoStats.encodedFrameCount);
                GUI.Label(new Rect(Screen.width - 195, 135, 200, 200), "encoded frame width: " + broadcasterVideoStats.encodedFrameWidth);
                GUI.Label(new Rect(Screen.width - 195, 150, 200, 200), "encoded frame height: " + broadcasterVideoStats.encodedFrameHeight);
                GUI.Label(new Rect(Screen.width - 195, 180, 200, 200), "quality adapt indication: " + broadcasterVideoStats.qualityAdaptIndication);
                GUI.Label(new Rect(Screen.width - 195, 210, 200, 200), "codec type: " + broadcasterVideoStats.codecType);
                GUI.Label(new Rect(Screen.width - 195, 240, 200, 200), "fallback to audio only: " + fallbackToAudioOnly);
            }
            else
            {
                GUI.Box(new Rect(Screen.width - 215, 0, 220, 250), "Agora Remote Audience Stats");
                GUI.Label(new Rect(Screen.width - 210, 15, 200, 200), "uid: " + audienceVideoStats.uid);
                GUI.Label(new Rect(Screen.width - 210, 30, 200, 200), "delay: " + audienceVideoStats.delay);
                GUI.Label(new Rect(Screen.width - 210, 45, 200, 200), "width: " + audienceVideoStats.width);
                GUI.Label(new Rect(Screen.width - 210, 60, 200, 200), "height: " + audienceVideoStats.height);
                GUI.Label(new Rect(Screen.width - 210, 75, 200, 200), "received bitrate: " + audienceVideoStats.receivedBitrate);
                GUI.Label(new Rect(Screen.width - 210, 90, 200, 200), "decoder output framerate: " + audienceVideoStats.decoderOutputFrameRate);
                GUI.Label(new Rect(Screen.width - 210, 105, 200, 200), "renderer output framerate: " + audienceVideoStats.rendererOutputFrameRate);
                GUI.Label(new Rect(Screen.width - 210, 120, 200, 200), "packet loss rate: " + audienceVideoStats.packetLossRate);
                GUI.Label(new Rect(Screen.width - 210, 135, 200, 200), "toal active time: " + audienceVideoStats.totalActiveTime);
                GUI.Label(new Rect(Screen.width - 210, 150, 200, 200), "total frozen time: " + audienceVideoStats.totalFrozenTime);
                GUI.Label(new Rect(Screen.width - 210, 165, 200, 200), "frozen rate: " + audienceVideoStats.frozenRate);
                GUI.Label(new Rect(Screen.width - 210, 195, 220, 200), "rx stream type: " + audienceVideoStats.rxStreamType);
                GUI.Label(new Rect(Screen.width - 210, 225, 220, 200), "fallback to audio only: " + fallbackToAudioOnly);
            }
        }
    }
}