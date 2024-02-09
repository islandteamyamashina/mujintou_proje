using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Event_Panel_view : MonoBehaviour
{
    public GameObject mainPanel;
    public GameObject subPanel;
    public GameObject Opbutton;
    public GameObject Inbutton;

    public GameObject OptionPanel;

    void Start()
    {
        mainPanel.SetActive(true);
        OptionPanel.SetActive(false);
        subPanel.SetActive(false);
        Opbutton.SetActive(true); 
    Inbutton.SetActive(true);   
    }

    public  void MainView()
    {
        mainPanel.SetActive(true);
        OptionPanel.SetActive(false);
        subPanel.SetActive(false);
       Opbutton.SetActive(true);
        Inbutton.SetActive(true);   
    }


    public  void OptionPanelView()
    {
        mainPanel.SetActive(true);
        OptionPanel.SetActive(true);
        subPanel.SetActive(false);
        Opbutton.SetActive(false);
        Inbutton.SetActive(false);  

    }
    public virtual void SubView()
    {
        mainPanel.SetActive(true);
        subPanel.SetActive(true);
        OptionPanel.SetActive(false);
        Opbutton.SetActive(false);
                Inbutton.SetActive(false);

    }
}   

