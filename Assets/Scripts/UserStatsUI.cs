using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using agora_gaming_rtc;

public class UserStatsUI : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    private bool isLocalVideo = false;
    private GameObject statsPanel;
    private bool fallbackToAudioOnly;

    [Header("Stuff")]
    [SerializeField] private Text uidText;
    [SerializeField] private Text fallbackText;
    [SerializeField] private Text delayText;
    [SerializeField] private Text widthText;
    [SerializeField] private Text heightText;
    [SerializeField] private Text receivedBitrateText;
    [SerializeField] private Text packetLossRateText;
    [SerializeField] private Text activeTimeText;
    [SerializeField] private Text frozenTimeText;
    [SerializeField] private Text frozenRateText;
    [SerializeField] private Text decoderOutputFrameRateText;
    [SerializeField] private Text rendererOutputFramerateText;
    [SerializeField] private Text rxStreamTypeText;

    void Start()
    {
        fallbackToAudioOnly = false;

        statsPanel = transform.GetChild(0).gameObject;
        statsPanel.SetActive(false);

        if (isLocalVideo)
        {
            AgoraVideoChat.mRtcEngine.OnLocalVideoStats += OnLocalVideoStatsCallback;
        }
        else
        {
            AgoraVideoChat.mRtcEngine.OnRemoteVideoStats += OnRemoteVideoStatsCallback;
        }
    }

    //void OnEnable()
    //{
    //    if (isLocalVideo)
    //    {
    //        AgoraVideoChat.mRtcEngine.OnLocalVideoStats += OnLocalVideoStatsCallback;
    //    }
    //    else
    //    {
    //        AgoraVideoChat.mRtcEngine.OnRemoteVideoStats += OnRemoteVideoStatsCallback;
    //    }
    //}

    //void OnDisable()
    //{
    //    if (isLocalVideo)
    //    {
    //        AgoraVideoChat.mRtcEngine.OnLocalVideoStats -= OnLocalVideoStatsCallback;
    //    }
    //    else
    //    {
    //        AgoraVideoChat.mRtcEngine.OnRemoteVideoStats -= OnRemoteVideoStatsCallback;
    //    }
    //}

    public void SetIsLocal(bool isLocal)
    {
        isLocalVideo = isLocal;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(statsPanel.activeInHierarchy)
        {
            statsPanel.SetActive(false);
        }
        else
        {
            statsPanel.SetActive(true);
        }
    }

    void OnLocalVideoStatsCallback(LocalVideoStats localVideoStats)
    {
        if(isLocalVideo)
        {
            uidText.text = "uid: " + gameObject.name;
            fallbackText.text = "Fallback to audio only: " + fallbackToAudioOnly;
            delayText.text = "Eframe ct: " + localVideoStats.encodedFrameCount;
            widthText.text = "Eframe height: " + localVideoStats.encodedFrameHeight;
            heightText.text = "Eframe width: " + localVideoStats.encodedFrameWidth;
            receivedBitrateText.text = "Sent frame rate: " + localVideoStats.sentFrameRate;
            packetLossRateText.text = "Target frame rate: " + localVideoStats.targetFrameRate;
            activeTimeText.text = "Enc bit rate: " + localVideoStats.encodedBitrate;
            frozenTimeText.text = "Sent bitrate: " + localVideoStats.sentBitrate;
            frozenRateText.text = "Target bitrate: " + localVideoStats.targetBitrate;
            decoderOutputFrameRateText.text = "Quality adapt: " + localVideoStats.qualityAdaptIndication;
            rendererOutputFramerateText.text = "";
            rxStreamTypeText.text = "Codec type: " + localVideoStats.codecType;
        }
    }

    void OnRemoteVideoStatsCallback(RemoteVideoStats remoteVideoStats)
    {
        if (gameObject.name == remoteVideoStats.uid.ToString())
        {
            print(gameObject.name + " remote video callback");

            uidText.text = "Uid: " + remoteVideoStats.uid;
            fallbackText.text = "Fallback to audio only: " + fallbackToAudioOnly;
            delayText.text = "Delay: " + remoteVideoStats.delay;
            widthText.text = "Width: " + remoteVideoStats.width;
            heightText.text = "Height: " + remoteVideoStats.height;
            receivedBitrateText.text = "Received bit rate: " + remoteVideoStats.receivedBitrate;
            packetLossRateText.text = "Packet loss rate: " + remoteVideoStats.packetLossRate;
            activeTimeText.text = "Total active time: " + remoteVideoStats.totalActiveTime;
            frozenTimeText.text = "Total frozen time: " + remoteVideoStats.totalFrozenTime;
            frozenRateText.text = "Frame rate: " + remoteVideoStats.frozenRate;
            decoderOutputFrameRateText.text = "Decoder output frame rate: " + remoteVideoStats.decoderOutputFrameRate;
            rendererOutputFramerateText.text = "Renderer output frame rate: " + remoteVideoStats.rendererOutputFrameRate;
            rxStreamTypeText.text = "Stream type: " + remoteVideoStats.rxStreamType;
        }
    }
}
