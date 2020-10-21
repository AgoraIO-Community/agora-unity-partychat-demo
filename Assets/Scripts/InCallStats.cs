using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using agora_gaming_rtc;

public class InCallStats : Photon.MonoBehaviour
{
    // Stream Fallback
    // Call stats


    // this isn't for a uniform group chat. this is based on a publish/subscribe broadcast paradigm
    // if player is first player in the photon room, they are the publisher, else subscriber


    private bool isPublisher;

    private AgoraVideoChat agoraScript;
    private IRtcEngine agoraEngine;

    // Start is called before the first frame update
    void Start()
    {
        if(photonView.isMine)
        {
            agoraEngine = null;
            isPublisher = false;
            agoraScript = GetComponent<AgoraVideoChat>();

            StartCoroutine(AgoraEngineSetup());

            print("photon owner ID " + photonView.ownerId);
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

                // Occurs when the locally published media stream falls back to an audio-only stream due to poor network conditions,
                // or switches back to the video after the network conditions improve.
                agoraEngine.SetLocalPublishFallbackOption(STREAM_FALLBACK_OPTIONS.STREAM_FALLBACK_OPTION_AUDIO_ONLY);
            }
            // ...all other joining players are SUBSCRIBERS.
            else
            {
                agoraEngine.SetClientRole(CLIENT_ROLE_TYPE.CLIENT_ROLE_AUDIENCE);

                // Occurs when the remote media stream falls back to audio-only stream due to poor network conditions,
                // or switches back to the video stream after the network conditions improve.
                agoraEngine.SetRemoteSubscribeFallbackOption(STREAM_FALLBACK_OPTIONS.STREAM_FALLBACK_OPTION_AUDIO_ONLY);
            }

            agoraEngine.OnLocalPublishFallbackToAudioOnly += OnLocalPublishFallbackToAudioOnlyCallback;
            agoraEngine.OnRemoteSubscribeFallbackToAudioOnly += OnRemoteSubscribeFallbackToAudioOnlyCallback;
            agoraEngine.OnRemoteVideoStats += OnRemoteVideoStatsCallback;
        }
    }

    void OnLocalPublishFallbackToAudioOnlyCallback(bool isFallbackOrRecover)
    {
        if(photonView.isMine)
        {
            print("Local publish fallback - is falling back to audio only: " + isFallbackOrRecover);
        }
    }

    void OnRemoteSubscribeFallbackToAudioOnlyCallback(uint uid, bool isFallbackOrRecover)
    {
        if(photonView.isMine)
        {
            print("Remote subscribe fallback - UID of remote user: " + uid + " - is falling back to audio only: " + isFallbackOrRecover);
        }
    }

    void OnRemoteVideoStatsCallback(RemoteVideoStats remoteVideoStats)
    {
        // you can monitor the steam switch between a high and low stream here
        if (photonView.isMine)
        {
            print("--- RemoteVideo Stats ---");
            print("uid: " + remoteVideoStats.uid);
            print("received bitrate: " + remoteVideoStats.receivedBitrate);
            print("packet loss rate: " + remoteVideoStats.packetLossRate);
            print("rx stream type: " + remoteVideoStats.rxStreamType);
            print("--------------------------");
        }
    }
}