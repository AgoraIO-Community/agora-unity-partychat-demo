using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using agora_gaming_rtc;

public class UserStatsUI : MonoBehaviour, IPointerClickHandler
{

    private GameObject statsPanel;
    private bool fallbackToAudioOnly;

    [Header("Stuff")]
    [SerializeField] private Text uidText;
    [SerializeField] private Text fallbackText;
    [SerializeField] private Text delayText;
    [SerializeField] private Text widthText;
    [SerializeField] private Text heightText;
    [SerializeField] private Text receiverBitrateText;
    [SerializeField] private Text packetLossRateText;
    [SerializeField] private Text activeTimeText;
    [SerializeField] private Text frozenTimeText;
    [SerializeField] private Text frameRateText;
    [SerializeField] private Text decoderOutputFrameRateText;
    [SerializeField] private Text rendererOutputFramerateText;
    [SerializeField] private Text rxStreamTypeText;

    void Start()
    {
        fallbackToAudioOnly = false;

        statsPanel = transform.GetChild(0).gameObject;
        statsPanel.SetActive(false);

        AgoraVideoChat.mRtcEngine.OnRemoteVideoStats = OnRemoteVideoStatsCallback;
        AgoraVideoChat.mRtcEngine.OnRemoteSubscribeFallbackToAudioOnly = OnRemoteSubscribeFallbackToAudioOnlyCallback;
         
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

    void OnRemoteSubscribeFallbackToAudioOnlyCallback(uint uid, bool isFallbackOrRecover)
    {
        if(uid.ToString() == gameObject.name)
        {
            print("Remote subscribe fallback - UID of remote user: " + uid + " - is falling back to audio only: " + isFallbackOrRecover);
            fallbackToAudioOnly = isFallbackOrRecover;
        }
    }

    void OnRemoteVideoStatsCallback(RemoteVideoStats remoteVideoStats)
    {
        


        if(gameObject.name == remoteVideoStats.uid.ToString())
        {
            uidText.text = "Uid: " + remoteVideoStats.uid;
            fallbackText.text = "Fallback to audio only: " + fallbackToAudioOnly;
            delayText.text = "Delay: " + remoteVideoStats.delay;
            widthText.text = "Width: " + remoteVideoStats.width;
            heightText.text = "Height: " + remoteVideoStats.height;
            //[SerializeField] private Text receiverBitrateText;
            //[SerializeField] private Text packetLossRateText;
            //[SerializeField] private Text activeTimeText;
            //[SerializeField] private Text frozenTimeText;
            //[SerializeField] private Text frameRateText;
            //[SerializeField] private Text decoderOutputFrameRateText;
            //[SerializeField] private Text rendererOutputFramerateText;
            //[SerializeField] private Text rxStreamTypeText;
        }



        // grab user UID + stats and output to stat window


        //print("remote UID: " + remoteVideoStats.uid);

        //print("remote video stats: " + remoteVideoStats.receivedBitrate);
        //print("remote video stats: " + remoteVideoStats.rxStreamType);


        //if (photonView.isMine)
        //{
        //    audienceVideoStats = remoteVideoStats;
        //    UpdateCallStatsUI();
        //}
    }
}
