using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpatialAudioUITester : MonoBehaviour
{
    [Range(0f, 100f)]
    public float testGain;

    [Range(-1f, 1f)]
    public float testPan;

    public Text gainText;
    public Text panText;

    public Slider gainSlider;
    public Slider panSlider;


    private void Update()
    {
        UpdateSpatialAudioVisualizer(testGain, testPan);
    }

    public void UpdateSpatialAudioVisualizer(float newGain, float newPan)
    {
        gainSlider.value = newGain;
        panSlider.value = newPan;

        gainText.text = "Gain: \n" + gainSlider.value.ToString();
        panText.text = "Pan: \n" + panSlider.value.ToString();
    }
}
