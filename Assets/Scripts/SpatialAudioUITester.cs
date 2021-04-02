using UnityEngine;
using UnityEngine.UI;

public class SpatialAudioUITester : MonoBehaviour
{
    public Text gainText;
    public Text panText;

    public Slider gainSlider;
    public Slider panSlider;

    public void UpdateSpatialAudioVisualizer(float newGain, float newPan)
    {
        gainSlider.value = newGain;
        panSlider.value = newPan;

        gainText.text = "Gain: \n" + gainSlider.value.ToString();
        panText.text = "Pan: \n" + panSlider.value.ToString();
    }
}