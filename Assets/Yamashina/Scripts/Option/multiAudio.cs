using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class multiAudio : MonoBehaviour
{

    [SerializeField] private Slider bgmSlider;//BGM�X���C�_�[
    [SerializeField] private Slider seSlider;//SE�X���C�_�[
    void Start()
    {//�N�����Ƀ��[�h����
        BgmLoadSlider();
        SeLoadSlider();

    }
    public void BgmVolume()
    {
        float a = bgmSlider.value * 0.8f;
        Audiovolume.instance.SetBgmVolume(a);
        BgmSave();
        print(a);
    }

    public void SeVolume()
    {
        float b = seSlider.value;
        Audiovolume.instance.SetSeVolume(b);
        //�Z�[�u
        SeSave();
        
            GameObject.Find("SE_ob").GetComponent<AudioSource>().clip = Audiovolume.instance.audioClipSE[1];
            //audioSourceBGM = GameObject.Find("BGM_ob").GetComponent<AudioSource>();
            //audioSourceSE= GameObject.Find("SE_ob").GetComponent<AudioSource>();

            GameObject.Find("SE_ob").GetComponent<AudioSource>().PlayOneShot(Audiovolume.instance.audioClipSE[1]);
        
        print(b);
    }
    public void BgmSave()
    {
        PlayerPrefs.SetFloat("bgmSliderValue", bgmSlider.value);
    }
    public void SeSave()
    {
        PlayerPrefs.SetFloat("seSliderValue", seSlider.value);
    }
    public void BgmLoadSlider()
    {
        bgmSlider.value = PlayerPrefs.GetFloat("bgmSliderValue", 1.0f);
        float a = bgmSlider.value * 0.8f;
        Audiovolume.instance.SetBgmVolume(a);
        print(a);
    }

    public void SeLoadSlider()
    {
        seSlider.value = PlayerPrefs.GetFloat("seSliderValue", 1.0f);
        float b = seSlider.value;
        Audiovolume.instance.SetSeVolume(b);
        print(b);
    }
}

