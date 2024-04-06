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
    }
   
    public AudioSource audioSourceBGM;//BGM�X�s�[�J�[
    public AudioClip[] audioClipsBGM;//BGM�̑f��

    public AudioSource audioSourceSE;//SoundEffect�̃X�s�[�J�[
    public AudioClip[] audioClipSE;//�Ȃ炷����

    public void SetBgmVolume(float bgmVolume)
    {
        audioSourceBGM.volume = bgmVolume;

    }

    public void SetSeVolume(float seVolume)
    {
        audioSourceSE.volume = seVolume;
       
    }
   

    

}

