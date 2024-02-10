using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


public class Audiovolume : MonoBehaviour
{
 
 
    public AudioMixer audioMixer;
    public Slider bGMSlider;
    public Slider sESlider;
    private int BGMvalue=5;
    private int SEValue = 5;

    private void Start()
    {
        bGMSlider.value = BGMvalue;
        sESlider.value = SEValue; 
        audioMixer.GetFloat("BGM", out float bgmVolume);
        bGMSlider.value = bgmVolume;
        audioMixer.GetFloat("SE", out float seVolume);
        sESlider.value = seVolume;
    }

    public void SetBGM(float volume)
    {
        audioMixer.SetFloat("BGM", volume);
    }

    public void SetSE(float volume)
    {
        audioMixer.SetFloat("SE", volume);
    }


}

