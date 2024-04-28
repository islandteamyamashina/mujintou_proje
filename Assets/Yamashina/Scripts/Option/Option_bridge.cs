using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Option_bridge : MonoBehaviour
{
    [SerializeField] public AudioMixer audioMixer;
    [SerializeField] public Slider bgmSlider;//BGMスライダー
    [SerializeField] public Slider seSlider;//SEスライダー
    [SerializeField] multiAudio multiAudio;
  
    // Start is called before the first frame update
    public void BgmVolume(float value)
    {
        float a = bgmSlider.value;

        Audiovolume.instance.SetBgmVolume(a);
        audioMixer.SetFloat("BGM", multiAudio.ConvertVolumeToDb(bgmSlider.value));

        BgmSave();
        print(a);
    }

    public void SeVolume(float value)
    {
        float b = multiAudio.seSlider.value;

        Audiovolume.instance.SetSeVolume(b);
        audioMixer.SetFloat("SE", multiAudio.ConvertVolumeToDb(multiAudio.seSlider.value));
        //セーブ
        SeSave();

        //audioSourceBGM = GameObject.Find("BGM_ob").GetComponent<AudioSource>();
        //audioSourceSE= GameObject.Find("SE_ob").GetComponent<AudioSource>();


        print(b);
    }
    public void BgmSave()
    {
        PlayerPrefs.SetFloat("bgmSliderValue", bgmSlider.value);
        Debug.Log("Check OnDisable");

    }
    public void SeSave()
    {
        PlayerPrefs.SetFloat("seSliderValue", seSlider.value);
        Debug.Log("Check OnDisable");

    }
}