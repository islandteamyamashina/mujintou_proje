using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class anotherBGMPlayer : MonoBehaviour
{
    [SerializeField] AudioClip[] BGMclips;
    [SerializeField] int num;
    private void Start()
    {
        GameObject.FindWithTag("BGM").GetComponent<AudioSource>().clip = BGMclips[num];
        GameObject.FindWithTag("BGM").GetComponent<AudioSource>().Play();
    }
    public void ChooseSongs_BGM(int num)
    {
        GameObject.FindWithTag("BGM").GetComponent<AudioSource>().clip = BGMclips[num];
        GameObject.FindWithTag("BGM").GetComponent<AudioSource>().Play();
    }
}
