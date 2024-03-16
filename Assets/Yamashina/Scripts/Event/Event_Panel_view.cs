using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Event_Panel_view : MonoBehaviour
{
    public GameObject mainPanel;
    public GameObject Opbutton;

    public GameObject OptionPanel;

    void Start()
    {
        mainPanel.SetActive(true);
        OptionPanel.SetActive(false);
        Opbutton.SetActive(true);
        GameObject.Find("MaintoInventoryPanel").transform.position = Vector3.zero;

    }

    public void MainView()
    {
        mainPanel.SetActive(true);
        OptionPanel.SetActive(false);
        Opbutton.SetActive(true);
        
    }


    public void OptionPanelView()
    {
        mainPanel.SetActive(true);
        OptionPanel.SetActive(true);
        Opbutton.SetActive(false);

    }
    public virtual void SubView()
    {
        mainPanel.SetActive(true);
        OptionPanel.SetActive(false);
        Opbutton.SetActive(false);
        GameObject.Find("InventorySlotManager").transform.position = Vector3.zero;
        GameObject.Find("InventoryUIPanel").transform.position = Vector3.zero;
    }
}

