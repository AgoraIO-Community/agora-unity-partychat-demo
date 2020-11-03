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
    [SerializeField] private Text text1;
    [SerializeField] private Text text2;
    [SerializeField] private Text text3;
    [SerializeField] private Text text4;
    [SerializeField] private Text text5;
    [SerializeField] private Text text6;
    [SerializeField] private Text text7;
    [SerializeField] private Text text8;
    [SerializeField] private Text text9;
    [SerializeField] private Text text10;
    [SerializeField] private Text text11;
    [SerializeField] private Text text12;

    void Start()
    {
        fallbackToAudioOnly = false;

        statsPanel = transform.GetChild(0).gameObject;
        statsPanel.SetActive(false);

        if (AgoraEngine.mRtcEngine != null)
        {
            if (isLocalVideo)
            {
                AgoraEngine.mRtcEngine.OnLocalVideoStats += OnLocalVideoStatsCallback;
            }
            else
            {
                AgoraEngine.mRtcEngine.OnRemoteVideoStats += OnRemoteVideoStatsCallback;
            }
        }
    }

    void OnDisable()
    {
        if(AgoraEngine.mRtcEngine != null)
        {
            if (isLocalVideo)
            {
                AgoraEngine.mRtcEngine.OnLocalVideoStats -= OnLocalVideoStatsCallback;
            }
            else
            {
                AgoraEngine.mRtcEngine.OnRemoteVideoStats -= OnRemoteVideoStatsCallback;
            }
        }
    }

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
            uidText.text = "UID: " + gameObject.name;
            fallbackText.text = "Fallback to audio only: " + fallbackToAudioOnly;

            text1.text = "Sent frame rate: " + localVideoStats.sentFrameRate;
            text2.text = "Target frame rate: " + localVideoStats.targetFrameRate;
            text3.text = "Enc output frm rate: " + localVideoStats.encoderOutputFrameRate;

            text4.text = "Eframe countt: " + localVideoStats.encodedFrameCount;
            text5.text = "Eframe height: " + localVideoStats.encodedFrameHeight;
            text6.text = "Eframe width: " + localVideoStats.encodedFrameWidth;

            text7.text = "Enc bitrate: " + localVideoStats.encodedBitrate;
            text8.text = "Sent bitrate: " + localVideoStats.sentBitrate;
            text9.text = "Target bitrate: " + localVideoStats.targetBitrate;

            text10.text = "Quality adapt indication: " + localVideoStats.qualityAdaptIndication;
            text12.text = "Codec type: " + localVideoStats.codecType;
        }
    }

    void OnRemoteVideoStatsCallback(RemoteVideoStats remoteVideoStats)
    {
        if (gameObject.name == remoteVideoStats.uid.ToString())
        {
            uidText.text = "UID: " + remoteVideoStats.uid;
            fallbackText.text = "Fallback to audio only: " + fallbackToAudioOnly;

            text1.text = "Width: " + remoteVideoStats.width;
            text2.text = "Height: " + remoteVideoStats.height;
            text3.text = "Delay: " + remoteVideoStats.delay;

            text4.text = "Total active time: " + remoteVideoStats.totalActiveTime;
            text5.text = "Total frozen time: " + remoteVideoStats.totalFrozenTime;
            text6.text = "Frozen rate: " + remoteVideoStats.frozenRate;

            text7.text = "Received bitrate: " + remoteVideoStats.receivedBitrate;
            text8.text = "Packet loss rate: " + remoteVideoStats.packetLossRate;

            text10.text = "Renderer output frame rate: " + remoteVideoStats.rendererOutputFrameRate;
            text11.text = "Decoder output frame rate: " + remoteVideoStats.decoderOutputFrameRate;

            text12.text = "Stream type: " + remoteVideoStats.rxStreamType;
        }
    }
}