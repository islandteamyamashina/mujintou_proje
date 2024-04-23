using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScene_afterTitle : MonoBehaviour
{
    [SerializeField] SceneObject Title;
    [SerializeField] SwitchActivateSelf switchActivate;

    private void Start()
    {
        switchActivate=GameObject.FindAnyObjectByType<SwitchActivateSelf>().GetComponent<SwitchActivateSelf>();

    }
    public void Load()
    {
        switchActivate.SwitchActiveSelf();
        SceneManager.LoadScene(Title);
        //SceneManager.sceneLoaded += OnSceneLoaded;
    }

    //    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    //    {
    //        PlayerInfo.Instance.SwitchUIVisibility(); ;
    //    }
}

