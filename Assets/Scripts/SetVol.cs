using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SetVol : MonoBehaviour
{
    public AudioMixer mixer;
    private string sliderName;

    public void SetSliderName(string sliderName)
    {
        this.sliderName = sliderName;
    }

    public void SetLevel (float sliderValue)
    {
        mixer.SetFloat(sliderName, Mathf.Log10(sliderValue) * 20);
    }
}
