using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cameraChanger : MonoBehaviour
{

    void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;  //sceneLoadedに関数を追加
    }
    //関数の定義
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log(scene.name + " scene loaded");
        Camera camera = GameObject.Find("Main Camera").GetComponent<Camera>();
        if (this != null)
        {
            this.GetComponent<Canvas>().worldCamera = camera;
        }
    }
 
}
