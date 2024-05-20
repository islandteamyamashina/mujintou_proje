using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


public class Audiovolume : MonoBehaviour
{
    public static Audiovolume instance;
    public float BGM = 1;
    public float SE = 1;

    private void Awake()
    {
        audioSourceBGM = GameObject.FindWithTag("BGM").GetComponent<AudioSource>();
       audioSourceSE = GameObject.FindWithTag("SE").GetComponent<AudioSource>();


        GameObject.FindWithTag("BGM").GetComponent<AudioSource>().volume = audioSourceBGM.volume;
        GameObject.FindWithTag("SE").GetComponent<AudioSource>().volume = audioSourceSE.volume;
        Debug.Log(GameObject.FindWithTag("BGM").GetComponent<AudioSource>().volume);
        Debug.Log(GameObject.FindWithTag("SE").GetComponent<AudioSource>().volume);

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
       

        
    }



    public AudioSource audioSourceBGM;//BGMスピーカー

    public AudioSource audioSourceSE;//SoundEffectのスピーカー

    public void SetBgmVolume(float bgmVolume)
    {
        audioSourceBGM.volume = bgmVolume;

    }

    public void SetSeVolume(float seVolume)
    {
        audioSourceSE.volume = seVolume;

    }
   
       


}

