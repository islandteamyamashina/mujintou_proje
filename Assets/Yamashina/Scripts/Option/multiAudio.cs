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
    public void SE_0()
    {
        GameObject.FindWithTag("SE").GetComponent<AudioSource>().clip = audioClipSE[0];
        audioClipSE = GetComponent<multiAudio>().audioClipSE;

        GameObject.FindWithTag("SE").GetComponent<AudioSource>().PlayOneShot(audioClipSE[0]);
    }
    public void SE_1()
    {
        GameObject.FindWithTag("SE").GetComponent<AudioSource>().clip = audioClipSE[1];
        audioClipSE = GetComponent<multiAudio>().audioClipSE;

        GameObject.FindWithTag("SE").GetComponent<AudioSource>().PlayOneShot(audioClipSE[1]);
    }
    public void SE_2()
    {
        GameObject.FindWithTag("SE").GetComponent<AudioSource>().clip = audioClipSE[2];
        audioClipSE = GetComponent<multiAudio>().audioClipSE;

        GameObject.FindWithTag("SE").GetComponent<AudioSource>().PlayOneShot(audioClipSE[2]);

    }
    public void BGM_0()
    {
        GameObject.FindWithTag("BGM").GetComponent<AudioSource>().clip = audioClipsBGM[0];
       audioClipsBGM =GetComponent<multiAudio>().audioClipsBGM;

        GameObject.FindWithTag("BGM").GetComponent<AudioSource>().Play();
    }
    public void BGM_1()
    {
        GameObject.FindWithTag("BGM").GetComponent<AudioSource>().clip = audioClipsBGM[1];
        audioClipsBGM = GetComponent<multiAudio>().audioClipsBGM;
        GameObject.FindWithTag("BGM").GetComponent<AudioSource>().Play();
    }

}