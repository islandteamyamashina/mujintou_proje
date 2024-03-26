using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Event_Panel_view :MonoBehaviour
{
    public GameObject mainPanel;
    public GameObject Opbutton;
    [SerializeField]GameObject InventoryPanel;
    public GameObject OptionPanel;

    void Start()
    {
        mainPanel.SetActive(true);
        OptionPanel.SetActive(false);
        Opbutton.SetActive(true);
        InventoryPanel.SetActive(false);
    }

    public void MainView()
    {
        mainPanel.SetActive(true);
        OptionPanel.SetActive(false);
        Opbutton.SetActive(true);
        InventoryPanel.SetActive(false);
    }


    public void OptionPanelView()
    {

        mainPanel.SetActive(true);
        OptionPanel.SetActive(true);
        Opbutton.SetActive(false);
        InventoryPanel.SetActive(false);

    }
    public void SubView()
    {
        mainPanel.SetActive(true);
        OptionPanel.SetActive(false);
        Opbutton.SetActive(false);
        InventoryPanel.SetActive(true);
        //GameObject.Find("Inventory").transform.position = Vector3.zero;
        //GameObject.Find("InventorySlotManager").transform.position = Vector3.zero;
        //GameObject.Find("SozaibakoSlotManager").transform.position = new Vector3(-4.4f, -7.94f, 0.0f);

    }
   
}

