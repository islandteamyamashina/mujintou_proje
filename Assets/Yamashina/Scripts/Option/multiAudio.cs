using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Recorder;
using UnityEngine;

public class multiAudio : MonoBehaviour
{
    bool f = false;

      [SerializeField] private AudioSource a;//AudioSource型の変数aを宣言 使用するAudioSourceコンポーネントをアタッチ必要

        [SerializeField] private AudioClip b1;//AudioClip型の変数b1を宣言 使用するAudioClipをアタッチ必要
        [SerializeField] private AudioClip b2;//AudioClip型の変数b2を宣言 使用するAudioClipをアタッチ必要 
    [SerializeField] private AudioClip b3;
    //自作の関数1
    public void SE1()
        {
            a.PlayOneShot(b1);
        }

    //自作の関数2
    public void SE2()
    {
            a.PlayOneShot(b2);
    }

    public void SE3()
    {
        a.PlayOneShot(b3);
    }

}

