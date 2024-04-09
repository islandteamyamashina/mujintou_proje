using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class multiAudio : MonoBehaviour
{

    [SerializeField] private Slider bgmSlider;//BGMスライダー
    [SerializeField] private Slider seSlider;//SEスライダー
    [SerializeField] AudioMixer audioMixer;
    void Start()

    {//起動時にロードする
      
       

    }
    public void BgmVolume()
    {
        float a = bgmSlider.value;
        Audiovolume.instance.SetBgmVolume(a);
        audioMixer.SetFloat("BGM", ConvertVolumeToDb(bgmSlider.value));

        BgmSave();
        print(a);
    }

    public void SeVolume()
    {
        float b = seSlider.value;
        Audiovolume.instance.SetSeVolume(b);
        audioMixer.SetFloat("SE", ConvertVolumeToDb(seSlider.value));

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
    public void BgmLoadSlider()
    {
        bgmSlider.value = PlayerPrefs.GetFloat("bgmSliderValue", 1.0f);
        float a = bgmSlider.value;
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
    public float ConvertVolumeToDb(float volume)
    {
        return Mathf.Clamp(Mathf.Log10(Mathf.Clamp(volume, 0f, 1f)) * 20f, -80f, 0f);
    }
    public void playse()
    {
        GameObject.FindWithTag("SE").GetComponent<AudioSource>().clip = Audiovolume.instance.audioClipSE[1];
        GameObject.FindWithTag("SE").GetComponent<AudioSource>().PlayOneShot(Audiovolume.instance.audioClipSE[1]);
    }
    public void CancelSE()
    {
        //    GameObject.Find("BGM_ob").GetComponent<AudioSource>().clip = Audiovolume.instance.audioClipSE[2];
        //   GameObject.Find("SE_ob").GetComponent<AudioSource>().PlayOneShot(Audiovolume.instance.audioClipSE[2]);

    }
    public void BGMSE()
    {
        //    GameObject.Find("BGM_ob").GetComponent<AudioSource>().clip = Audiovolume.instance.audioClipsBGM[1];
        //    GameObject.Find("BGM_ob").GetComponent<AudioSource>().Play();
    }
    public void BGMSE_Kyoten()
    {
        GameObject.FindWithTag("BGM").GetComponent<AudioSource>().clip= Audiovolume.instance.audioClipsBGM[1];

        GameObject.FindWithTag("BGM").GetComponent<AudioSource>().Play();
    }

}