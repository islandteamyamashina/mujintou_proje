using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainSoundPlayer : MonoBehaviour
{
    void Start()
    {
        GetComponent<AudioSource>().volume = GameObject.FindGameObjectWithTag("BGM").GetComponent<AudioSource>().volume;

        if(PlayerInfo.Instance.weather == PlayerInfo.Weather.Rainy)
        {
            GetComponent<AudioSource>().Play();
        }
    }

}
