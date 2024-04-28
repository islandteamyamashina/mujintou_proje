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

    void Start()
    {
        bgmSlider.fillRect = multiAudio.fillRectTransform_BGM;
        seSlider.fillRect = multiAudio.fillRectTransform_SE;
        //fillRectTransform_BGM = GameObject.FindGameObjectWithTag("BGM_Rect").GetComponent<RectTransform>();
        //fillRectTransform_SE = GameObject.FindGameObjectWithTag("SE_Rect").GetComponent<RectTransform>();


        //// 幅と高さを固定値に設定する
        SetFixedSize();
    }

    // 幅と高さを固定値に設定するメソッド
    void SetFixedSize()
    {
        //幅と高さを設定する
        multiAudio.fillRectTransform_BGM.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal,multiAudio. fixedWidth);
        multiAudio.fillRectTransform_BGM.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, multiAudio.fixedHeight);
        multiAudio.fillRectTransform_SE.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, multiAudio.fixedWidth);
        multiAudio.fillRectTransform_SE.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, multiAudio.fixedHeight);
    }

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