using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Option_bridge : MonoBehaviour
{
    [SerializeField] multiAudio multiAudio;
    // Start is called before the first frame update
    public void BgmVolume(float value)
    {
        float a = multiAudio.bgmSlider.value;

        Audiovolume.instance.SetBgmVolume(a);
        multiAudio.audioMixer.SetFloat("BGM", multiAudio.ConvertVolumeToDb(multiAudio.bgmSlider.value));

        multiAudio.BgmSave();
        print(a);
    }

    public void SeVolume(float value)
    {
        float b = multiAudio.seSlider.value;

        Audiovolume.instance.SetSeVolume(b);
        multiAudio.audioMixer.SetFloat("SE", multiAudio.ConvertVolumeToDb(multiAudio.seSlider.value));
        //ÉZÅ[Éu
        multiAudio.SeSave();

        //audioSourceBGM = GameObject.Find("BGM_ob").GetComponent<AudioSource>();
        //audioSourceSE= GameObject.Find("SE_ob").GetComponent<AudioSource>();


        print(b);
    }
}
