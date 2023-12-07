using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class no_button : MonoBehaviour
{
    
    [SerializeField] public GameObject newPanel; // 新しいUIパネルへの参照

    public void Start()
    {
        newPanel.SetActive(true);
    }
    public void OnClick()
    {
        newPanel.SetActive(false);
    }
}


