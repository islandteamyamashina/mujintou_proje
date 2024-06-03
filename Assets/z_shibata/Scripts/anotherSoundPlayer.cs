using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class anotherSoundPlayer : MonoBehaviour
{
    public AudioClip[] audioClipSE;
    public void ChooseSongs_SE(int num)
    {
        Audiovolume.instance.audioSourceSE = GameObject.FindWithTag("SE").GetComponent<AudioSource>();

        if (!Audiovolume.instance.audioSourceSE.isPlaying)
        {
            GameObject.FindWithTag("SE").GetComponent<AudioSource>().PlayOneShot(audioClipSE[num]);
        }

            GameObject.FindWithTag("SE").GetComponent<AudioSource>().volume = Audiovolume.instance.SE;
        
    }
}
