using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


public class Audiovolume : MonoBehaviour
{
    public static Audiovolume instance;
    private void Awake()
    {

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
        //if (audioClipsBGM != null)
        //{
        //    Debug.Log(audioClipsBGM.Length);//ここが通った
        //}
        //else
        //{
        //    Debug.Log("audioClipsBGM is Null!");
        //}
        //if (audioClipSE != null)
        //{
        //    Debug.Log(audioClipSE.Length);//ここが通った
        //}
        //else
        //{
        //    Debug.Log("audioClipSE is Null!");
        //}
        //if (audioClipsBGM != null)
        //{
        //    Debug.Log("audioSourceBGM is not Null!");
        //}

        //else
        //{

        //    Debug.Log("audioSourceBGM is Null!");
        //}
        //if (audioClipSE != null)
        //{
        //    Debug.Log("audioSourceSE is not Null!");

        //}
        //else
        //{

        //    Debug.Log("audioSourceSE is Null!");
        //}
        //Debug.Log("その他");//ここが通る？？
    }



    public AudioSource audioSourceBGM;//BGMスピーカー
    public AudioClip[] audioClipsBGM;//BGMの素材

    public AudioSource audioSourceSE;//SoundEffectのスピーカー
    public AudioClip[] audioClipSE;//ならす音源

    public void SetBgmVolume(float bgmVolume)
    {
        audioSourceBGM.volume = bgmVolume;

    }

    public void SetSeVolume(float seVolume)
    {
        audioSourceSE.volume = seVolume;

    }
   
       


}

