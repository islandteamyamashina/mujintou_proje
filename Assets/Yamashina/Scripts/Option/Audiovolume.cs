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
        //if (audioClipsBGM != null)
        //{
        //    Debug.Log(audioClipsBGM.Length);//�������ʂ���
        //}
        //else
        //{
        //    Debug.Log("audioClipsBGM is Null!");
        //}
        //if (audioClipSE != null)
        //{
        //    Debug.Log(audioClipSE.Length);//�������ʂ���
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
        //Debug.Log("���̑�");//�������ʂ�H�H
    }



    public AudioSource audioSourceBGM;//BGM�X�s�[�J�[

    public AudioSource audioSourceSE;//SoundEffect�̃X�s�[�J�[

    public void SetBgmVolume(float bgmVolume)
    {
        audioSourceBGM.volume = bgmVolume;

    }

    public void SetSeVolume(float seVolume)
    {
        audioSourceSE.volume = seVolume;

    }
   
       


}

