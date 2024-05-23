using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class anotherBGMPlayer : MonoBehaviour
{
    [SerializeField] AudioClip[] BGMclips;
    [SerializeField] int num;
    private void Start()
    {
        Invoke("PlayBGMofDiray", 0.1f);
    }
    public void ChooseSongs_BGM(int num)
    {
        GameObject.FindWithTag("BGM").GetComponent<AudioSource>().clip = BGMclips[num];
        GameObject.FindWithTag("BGM").GetComponent<AudioSource>().Play();
    }
    public void PlayBGMofDiray()
    {
        GameObject.FindWithTag("BGM").GetComponent<AudioSource>().clip = BGMclips[num];
        GameObject.FindWithTag("BGM").GetComponent<AudioSource>().Play();
    }
    // フェードアウトの関数
    public IEnumerator FadeOutAudio(float fadeDuration)
    {
        AudioSource audioSource = GameObject.FindWithTag("BGM").GetComponent<AudioSource>();
        float startVolume = audioSource.volume;

        while (audioSource.volume > 0)
        {
            audioSource.volume -= startVolume * Time.deltaTime / fadeDuration;
            yield return null;
        }

        audioSource.Stop();
        audioSource.volume = startVolume;
    }

    // フェードインの関数
    public IEnumerator FadeInAudio(int num, float fadeDuration)
    {
        AudioSource audioSource = GameObject.FindWithTag("BGM").GetComponent<AudioSource>();
        float setVolume = audioSource.volume;

        audioSource.volume = 0;
        audioSource.clip = BGMclips[num];
        audioSource.Play();

        while (audioSource.volume < setVolume)
        {
            audioSource.volume += Time.deltaTime / fadeDuration;
            yield return null;
        }
    }

}