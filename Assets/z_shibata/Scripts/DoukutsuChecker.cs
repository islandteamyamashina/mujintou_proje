using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoukutsuChecker : MonoBehaviour
{
    [SerializeField] GameObject caveImage;
    void Start()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        if (sceneName == "Doukutu_fire" || sceneName == "Doukutu_light")
        {
            caveImage.gameObject.SetActive(true);
        }
        else
        {
            caveImage.gameObject.SetActive(false);
        }
    }
}
