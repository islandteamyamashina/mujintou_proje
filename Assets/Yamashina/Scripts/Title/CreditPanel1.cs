using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditPanel1 : MonoBehaviour
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
