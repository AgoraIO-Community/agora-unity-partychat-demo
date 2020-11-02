using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using agora_gaming_rtc;

public class AgoraEngineCallStats : MonoBehaviour
{


    public delegate void AgoraRemoteCallback(RemoteVideoStats remoteVideoStats);
    public static event AgoraRemoteCallback UpdateRemoteVideoStats;

    public delegate void AgoraLocalCallback(LocalVideoStats localVideoStats);
    public static event AgoraLocalCallback UpdateLocalVideoStats;

    void Start()
    {
        StartCoroutine(InitializeAgora());
    }

    IEnumerator InitializeAgora()
    {
        float engineTimer = 0f;

        while (AgoraVideoChat.mRtcEngine == null)
        {
            engineTimer += Time.deltaTime;
            print("engineTimer: " + engineTimer);

            yield return null;
        }

        if(AgoraVideoChat.mRtcEngine == null)
        {
            print("engine is null");
            yield break;
        }
        else
        {
            print("engine found");
        }

        AgoraVideoChat.mRtcEngine.OnRemoteVideoStats = OnRemoteVideoStatsCallback;
        AgoraVideoChat.mRtcEngine.OnRemoteSubscribeFallbackToAudioOnly = OnRemoteSubscribeFallbackToAudioOnlyCallback;
        //AgoraVideoChat.mRtcEngine.OnLocalVideoStats = OnLocalVideoStatsCallback;
        AgoraVideoChat.mRtcEngine.OnLocalPublishFallbackToAudioOnly = OnLocalPublishFallbackToAudioOnlyCallback;
    }

    void OnLocalPublishFallbackToAudioOnlyCallback(bool isFallbackOrRecover)
    {
        print("Local publish fallback - is falling back to audio only: " + isFallbackOrRecover);
    }

    void OnLocalVideoStatsCallback(LocalVideoStats localVideoStats)
    {
        //print("local bitrate: " + localVideoStats.sentBitrate);
        //UpdateLocalVideoStats(localVideoStats);
    }

    void OnRemoteSubscribeFallbackToAudioOnlyCallback(uint uid, bool isFallbackOrRecover)
    {
        print("Remote subscribe fallback - UID of remote user: " + uid + " - is falling back to audio only: " + isFallbackOrRecover);
    }

    void OnRemoteVideoStatsCallback(RemoteVideoStats remoteVideoStats)
    {
        //print("remote uid: " + remoteVideoStats.uid);

        //UpdateRemoteVideoStats(remoteVideoStats);
    }
}