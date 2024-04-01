using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


public class Audiovolume : MonoBehaviour
{


    public AudioMixer audioMixer;
    public Slider bGMSlider;
    public Slider sESlider;
    private int BGMvalue = 5;
    private int SEValue = 5;
    [SerializeField] AudioSource AudioSource_BGM;
    [SerializeField] AudioSource AudioSource_SE;
    private bool isSoundEnabled_BGM = true; // 音が再生されるかどうかを管理するフラグ

    private void Start()
    {
        if (AudioSource_BGM == null)
        {
            // AudioSource_BGMがアサインされていない場合、現在のゲームオブジェクトからAudioSourceを検索してアサインする
            AudioSource_BGM = GameObject.Find("BGM_ob").GetComponent<AudioSource>();    


        }
        if (AudioSource_SE == null)
        {
            AudioSource_SE= GameObject.Find("SE_ob").GetComponent<AudioSource>();
        }
        bGMSlider.value = BGMvalue;
        sESlider.value = SEValue;
        audioMixer.GetFloat("BGM", out float bgmVolume);
        bGMSlider.value = bgmVolume;
        audioMixer.GetFloat("SE", out float seVolume);
        sESlider.value = seVolume;

        // スライダーの値が変更されたときに呼び出されるイベントハンドラを設定
        bGMSlider.onValueChanged.AddListener(OnBGMSliderValueChanged);
        sESlider.onValueChanged.AddListener(OnSESliderValueChanged);
    }

    void OnBGMSliderValueChanged(float value)
    {
        // スライダーの値に応じて音量を調整
        // ここでは、スライダーの最小値が0、最大値が1と仮定しています
        AudioSource_BGM.volume = value;

        // スライダーが一番端に行った場合、音を消す
        if (value == bGMSlider.minValue || value == bGMSlider.maxValue)
        {
            AudioSource_BGM.volume = 0f;
        }
       

    }
    void OnSESliderValueChanged(float value)
    {
        AudioSource_SE.volume = value;
        // スライダーが一番端に行った場合、音を消す
        if (value == sESlider.minValue || value == sESlider.maxValue)
        {
            isSoundEnabled_BGM = false;       
        }
        else
        {
            isSoundEnabled_BGM = true;
        }
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

