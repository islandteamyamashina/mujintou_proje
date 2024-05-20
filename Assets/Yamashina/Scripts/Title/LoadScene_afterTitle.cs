using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScene_afterTitle : MonoBehaviour
{
    [SerializeField] SceneObject Title;
    [SerializeField] SwitchActivateSelf switchActivate;
    public Audiovolume audiovolume;
    private void Start()
    {
        audiovolume = GameObject.FindAnyObjectByType < Audiovolume>(). GetComponent<Audiovolume>();

        switchActivate = GameObject.FindAnyObjectByType<SwitchActivateSelf>().GetComponent<SwitchActivateSelf>();

    }
    public void Load()
    {
        switchActivate.SwitchActiveSelf();
        PlayerInfo.Instance.DestroySelf();
        audiovolume.BGM = GameObject.FindWithTag("BGM").GetComponent<AudioSource>().volume;
        audiovolume.SE = GameObject.FindWithTag("SE").GetComponent<AudioSource>().volume;

        SceneManager.LoadScene(Title);
        //SceneManager.sceneLoaded += OnSceneLoaded;
    }

    //    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    //    {
    //        PlayerInfo.Instance.SwitchUIVisibility(); ;
    //    }
}

