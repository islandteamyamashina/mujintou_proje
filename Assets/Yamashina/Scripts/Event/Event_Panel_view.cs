using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_Panel_view : MonoBehaviour
{
    public GameObject mainPanel;
    public GameObject OptionPanel;

    void Start()
    {
        mainPanel.SetActive(true);
        OptionPanel.SetActive(false);

    }

    public  void MainView()
    {
        mainPanel.SetActive(true);
        OptionPanel.SetActive(false);

    }

    
    public  void OptionPanelView()
    {
        mainPanel.SetActive(true);
        OptionPanel.SetActive(true);
    }
}   

