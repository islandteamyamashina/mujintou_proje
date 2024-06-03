using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class multiAudio : MonoBehaviour
{



    public AudioClip[] audioClipsBGM;//BGM�̑f��

    public AudioClip[] audioClipSE;//�Ȃ炷����



    // ���ƍ������Œ�l�ɐݒ肷�郁�\�b�h
    //    void SetFixedSize()
    //{
    //    //���ƍ�����ݒ肷��
    //    fillRectTransform_BGM.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, fixedWidth);
    //    fillRectTransform_BGM.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, fixedHeight);
    //    fillRectTransform_SE.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, fixedWidth);
    //    fillRectTransform_SE.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, fixedHeight);
    //}





    public float ConvertVolumeToDb(float volume)
    {
        return Mathf.Clamp(Mathf.Log10(Mathf.Clamp(volume, 0f, 1f)) * 20f, -80f, 0f);
    }

    public void ChooseSongs_BGM(int num)
    {
        switch (num)
        {
            case 0:
                GameObject.FindWithTag("BGM").GetComponent<AudioSource>().clip = audioClipsBGM[num];
                audioClipsBGM = GetComponent<multiAudio>().audioClipsBGM;

                GameObject.FindWithTag("BGM").GetComponent<AudioSource>().Play();
                break;
            case 1:
                GameObject.FindWithTag("BGM").GetComponent<AudioSource>().clip = audioClipsBGM[num];
                audioClipsBGM = GetComponent<multiAudio>().audioClipsBGM;

                GameObject.FindWithTag("BGM").GetComponent<AudioSource>().Play();
                break;
        }
    }

    public void ChooseSongs_SE(int num)
    {

        switch (num)
        {
            case 0:
                if (!Audiovolume.instance.audioSourceSE.isPlaying)
                {
                    GameObject.FindWithTag("SE").GetComponent<AudioSource>().clip = audioClipSE[num];
                    audioClipSE = GetComponent<multiAudio>().audioClipSE;
                    GameObject.FindWithTag("SE").GetComponent<AudioSource>().volume = Audiovolume.instance.SE;


                    GameObject.FindWithTag("SE").GetComponent<AudioSource>().PlayOneShot(audioClipSE[num]);
                }
                break;

            case 1:
                if (!Audiovolume.instance.audioSourceSE.isPlaying)
                {
                    GameObject.FindWithTag("SE").GetComponent<AudioSource>().clip = audioClipSE[num];
                    audioClipSE = GetComponent<multiAudio>().audioClipSE;
                    GameObject.FindWithTag("SE").GetComponent<AudioSource>().volume = Audiovolume.instance.SE;

                    GameObject.FindWithTag("SE").GetComponent<AudioSource>().PlayOneShot(audioClipSE[num]);
                }
                break;
            case 2:
                if (!Audiovolume.instance.audioSourceSE.isPlaying)
                {
                    GameObject.FindWithTag("SE").GetComponent<AudioSource>().clip = audioClipSE[num];
                    audioClipSE = GetComponent<multiAudio>().audioClipSE;
                    GameObject.FindWithTag("SE").GetComponent<AudioSource>().volume = Audiovolume.instance.SE;

                    GameObject.FindWithTag("SE").GetComponent<AudioSource>().PlayOneShot(audioClipSE[num]);
                }
                break;
        }
    }

}

