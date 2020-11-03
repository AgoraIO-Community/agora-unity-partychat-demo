using UnityEngine;
using agora_gaming_rtc;

public class AgoraEngine : MonoBehaviour
{
    [Header("Agora Properties")]
    [SerializeField]
    private string appID = "57481146914f4cddaa220d6f7a045063";
    public static IRtcEngine mRtcEngine;

    void Start()
    {
        if(mRtcEngine != null)
        {
            IRtcEngine.Destroy();
        }

        // Initialize Agora engine
        mRtcEngine = IRtcEngine.GetEngine(appID);

        // Setup square video profile
        VideoEncoderConfiguration config = new VideoEncoderConfiguration();
        config.dimensions.width = 480;
        config.dimensions.height = 480;
        config.frameRate = FRAME_RATE.FRAME_RATE_FPS_15;
        config.bitrate = 800;
        config.degradationPreference = DEGRADATION_PREFERENCE.MAINTAIN_QUALITY;
        mRtcEngine.SetVideoEncoderConfiguration(config);

        mRtcEngine.EnableVideo();
        mRtcEngine.EnableVideoObserver();
    }

    // Cleaning up the Agora engine during OnApplicationQuit() is an essential part of the Agora process with Unity. 
    private void OnApplicationQuit()
    {
        TerminateAgoraEngine();
    }

    public static void TerminateAgoraEngine()
    {
        if (mRtcEngine != null)
        {
            mRtcEngine.LeaveChannel();
            mRtcEngine = null;
            IRtcEngine.Destroy();
        }
    }
}