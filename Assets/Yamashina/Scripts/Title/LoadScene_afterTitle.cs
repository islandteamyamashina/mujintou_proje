using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScene_afterTitle : MonoBehaviour
{
    [SerializeField] SceneObject Title;
    
    public void Load()
    {

        SceneManager.LoadScene(Title);
    }
}

