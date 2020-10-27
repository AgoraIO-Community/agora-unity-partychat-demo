using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using agora_gaming_rtc;

public class InCallStats : Photon.MonoBehaviour
{
    private bool isBroadcaster;
    private bool fallbackToAudioOnly;
    private AgoraVideoChat agoraScript;
    private IRtcEngine agoraEngine;

    private LocalVideoStats broadcasterVideoStats;
    private RemoteVideoStats audienceVideoStats;

    [Header("UI Elements")]
    [SerializeField]
    private GameObject BroadCastSelectionPanel;
    [SerializeField]
    private GameObject PartyUIContainer;
    [SerializeField]
    private GameObject CallStatsPanel;
    [SerializeField]
    private Text callStatsText;
    [SerializeField]
    private GameObject ToggleStatsButton;

    [Header("Broadcaster")]
    [SerializeField]
    private Material broadcasterMaterial;
    [SerializeField]
    private SkinnedMeshRenderer vikingMesh;
    
    void Start()
    {
        if(photonView.isMine)
        {
            agoraEngine = null;
            isBroadcaster = false;
            fallbackToAudioOnly = false;

            BroadCastSelectionPanel.SetActive(false);
            PartyUIContainer.SetActive(false);
            CallStatsPanel.SetActive(false);
            ToggleStatsButton.SetActive(false);

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
                    Debug.LogError("InCallStats AgoraEngineSetup() Failure - No Agora Engine Found.");
                    yield break;
                }

                yield return null;
            }

            agoraEngine.SetChannelProfile(CHANNEL_PROFILE.CHANNEL_PROFILE_LIVE_BROADCASTING);
            BroadCastSelectionPanel.SetActive(true);
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

    void OnLocalVideoStatsCallback(LocalVideoStats localVideoStats)
    {
        if (photonView.isMine)
        {
            broadcasterVideoStats = localVideoStats;
            UpdateCallStatsUI();
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
            UpdateCallStatsUI();
        }
    }

    public void SetPlayerAsBroadCaster()
    {
        if(photonView.isMine)
        {
            agoraEngine.SetClientRole(CLIENT_ROLE_TYPE.CLIENT_ROLE_BROADCASTER);
            agoraEngine.SetLocalPublishFallbackOption(STREAM_FALLBACK_OPTIONS.STREAM_FALLBACK_OPTION_AUDIO_ONLY);
            isBroadcaster = true;

            TurnVikingGold();

            PartyUIContainer.SetActive(true);
            BroadCastSelectionPanel.SetActive(false);
            ToggleStatsButton.SetActive(true);

            InitializeCallbacks();
            agoraScript.JoinChannel();
        }
    }

    public void TurnVikingGold()
    {
        if(isBroadcaster)
        {
            photonView.RPC("UpdateBroadcasterMaterial", PhotonTargets.All);
        }


        if(photonView.isMine)
        {
            print("Turn viking gold called");
        }
    }

    [PunRPC]
    public void UpdateBroadcasterMaterial()
    {
        vikingMesh.material = broadcasterMaterial;   
    }

    public void SetPlayerAsAudience()
    {
        if (photonView.isMine)
        {
            agoraEngine.SetClientRole(CLIENT_ROLE_TYPE.CLIENT_ROLE_AUDIENCE);
            agoraEngine.SetRemoteSubscribeFallbackOption(STREAM_FALLBACK_OPTIONS.STREAM_FALLBACK_OPTION_AUDIO_ONLY);
            isBroadcaster = false;

            PartyUIContainer.SetActive(true);
            BroadCastSelectionPanel.SetActive(false);
            ToggleStatsButton.SetActive(true);

            InitializeCallbacks();
            agoraScript.JoinChannel();
        }
    }

    void InitializeCallbacks()
    {
        agoraEngine.OnLocalPublishFallbackToAudioOnly = OnLocalPublishFallbackToAudioOnlyCallback;
        agoraEngine.OnLocalVideoStats = OnLocalVideoStatsCallback;
        agoraEngine.OnRemoteSubscribeFallbackToAudioOnly = OnRemoteSubscribeFallbackToAudioOnlyCallback;
        agoraEngine.OnRemoteVideoStats = OnRemoteVideoStatsCallback;
    }

    public void ButtonToggleAgoraStreamStats()
    {
        if(CallStatsPanel.activeInHierarchy)
        {
            CallStatsPanel.SetActive(false);
        }
        else
        {
            CallStatsPanel.SetActive(true);
        }
    }

    void UpdateCallStatsUI()
    {
        if (isBroadcaster)
        {
            callStatsText.text =
            "Agora Local Broadcaster Stats" +
            "\ntarget bitrate: " + broadcasterVideoStats.targetBitrate +
            "\nsent bitrate: " + broadcasterVideoStats.sentBitrate +
            "\ntarget framerate: " + broadcasterVideoStats.targetFrameRate +
            "\nsent framerate: " + broadcasterVideoStats.sentFrameRate +
            "\nencoder output framerate: " + broadcasterVideoStats.encoderOutputFrameRate +
            "\nrenderer output framerate: " + broadcasterVideoStats.rendererOutputFrameRate +
            "\nencoded bitrate: " + broadcasterVideoStats.encodedBitrate +
            "\nencoded frame count: " + broadcasterVideoStats.encodedFrameCount +
            "\nencoded frame width: " + broadcasterVideoStats.encodedFrameWidth +
            "\nencoded frame height: " + broadcasterVideoStats.encodedFrameHeight +
            "\nquality adapt indication: " + broadcasterVideoStats.qualityAdaptIndication +
            "\ncodec type: " + broadcasterVideoStats.codecType +
            "\nfallback to audio only: " + fallbackToAudioOnly;
        }
        else
        {
            callStatsText.text =
            "Agora Remote Audience Stats" +
            "\nuid: " + audienceVideoStats.uid +
            "\ndelay: " + audienceVideoStats.delay +
            "\nwidth: " + audienceVideoStats.width +
            "\nheight: " + audienceVideoStats.height +
            "\nreceived bitrate: " + audienceVideoStats.receivedBitrate +
            "\ndecoder output framerate: " + audienceVideoStats.decoderOutputFrameRate +
            "\nrenderer output framerate: " + audienceVideoStats.rendererOutputFrameRate +
            "\npacket loss rate: " + audienceVideoStats.packetLossRate +
            "\ntotal active time: " + audienceVideoStats.totalActiveTime +
            "\ntotal frozen time: " + audienceVideoStats.totalFrozenTime +
            "\nfrozen rate: " + audienceVideoStats.frozenRate +
            "\nrx stream type: " + audienceVideoStats.rxStreamType +
            "\nfallback to audio only: " + fallbackToAudioOnly;
        }
    }
}