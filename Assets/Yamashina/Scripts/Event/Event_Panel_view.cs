using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_Panel_view : MonoBehaviour
{
    public GameObject mainPanel;
    public GameObject subPanel;

    public GameObject OptionPanel;

    void Start()
    {
        mainPanel.SetActive(true);
        OptionPanel.SetActive(false);
        subPanel.SetActive(false);

    }

    public  void MainView()
    {
        mainPanel.SetActive(true);
        OptionPanel.SetActive(false);
        subPanel.SetActive(false);

    }


    public  void OptionPanelView()
    {
        mainPanel.SetActive(true);
        OptionPanel.SetActive(true);
        subPanel.SetActive(false);

    }
    public virtual void SubView()
    {
        mainPanel.SetActive(true);
        subPanel.SetActive(true);
        OptionPanel.SetActive(false);

    }
}   

