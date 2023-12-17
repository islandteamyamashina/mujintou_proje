using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    [SerializeField]
    string sceneName;

    // Update is called once per frame
    public void OnClick()
    {
        SceneManager.LoadScene(sceneName);
    }
}

