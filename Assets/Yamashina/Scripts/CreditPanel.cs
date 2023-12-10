using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Unity.VisualScripting;


public class PanelChange : MonoBehaviour
{
    public GameObject mainPanel;
    public GameObject subPanel;

    void Start()
    {
        mainPanel.SetActive(true);
        subPanel.SetActive(false);
    }

    public void MainView()
    {
        mainPanel.SetActive(true);
        subPanel.SetActive(false);
    }

    public void SubView()
    {
        mainPanel.SetActive(false);
        subPanel.SetActive(true);
    }
}