using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class multiAudio : MonoBehaviour
{
    

    [SerializeField] Audiovolume audioVolume;
    




    // 幅と高さを固定値に設定するメソッド
//    void SetFixedSize()
//{
//    //幅と高さを設定する
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
        GameObject.FindWithTag("SE").GetComponent<AudioSource>().clip = Audiovolume.instance.audioClipSE[0];
        audioVolume.audioClipSE = GameObject.FindWithTag("SoundControler").GetComponent<Audiovolume>().audioClipSE;

        GameObject.FindWithTag("SE").GetComponent<AudioSource>().PlayOneShot(Audiovolume.instance.audioClipSE[0]);
    }
    public void SE_1()
    {
        GameObject.FindWithTag("SE").GetComponent<AudioSource>().clip = Audiovolume.instance.audioClipSE[1];
        audioVolume.audioClipSE = GameObject.FindWithTag("SoundControler").GetComponent<Audiovolume>().audioClipSE;

        GameObject.FindWithTag("SE").GetComponent<AudioSource>().PlayOneShot(Audiovolume.instance.audioClipSE[1]);
    }
    public void SE_2()
    {
        GameObject.FindWithTag("SE").GetComponent<AudioSource>().clip = Audiovolume.instance.audioClipSE[2];
        audioVolume.audioClipSE = GameObject.FindWithTag("SoundControler").GetComponent<Audiovolume>().audioClipSE;

        GameObject.FindWithTag("SE").GetComponent<AudioSource>().PlayOneShot(Audiovolume.instance.audioClipSE[2]);

    }
    public void BGM_0()
    {
        GameObject.FindWithTag("BGM").GetComponent<AudioSource>().clip = Audiovolume.instance.audioClipsBGM[0];
        audioVolume.audioClipsBGM = GameObject.FindWithTag("SoundControler").GetComponent<Audiovolume>().audioClipsBGM;

        GameObject.FindWithTag("BGM").GetComponent<AudioSource>().Play();
    }
    public void BGM_1()
    {
        GameObject.FindWithTag("BGM").GetComponent<AudioSource>().clip = Audiovolume.instance.audioClipsBGM[1];
        audioVolume.audioClipsBGM = GameObject.FindWithTag("SoundControler").GetComponent<Audiovolume>().audioClipsBGM;
        GameObject.FindWithTag("BGM").GetComponent<AudioSource>().Play();
    }

}