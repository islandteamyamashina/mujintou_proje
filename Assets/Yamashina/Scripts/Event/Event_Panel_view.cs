using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Event_Panel_view :MonoBehaviour
{
    public GameObject mainPanel;
    //[SerializeField]GameObject InventoryPanel;
    public GameObject OptionPanel;

    void Start()
    {
        mainPanel.SetActive(true);
        SwitchVisibleOption();

        //InventoryPanel.SetActive(false);
    }

    public void MainView()
    {
        mainPanel.SetActive(true);
        SwitchVisibleOption();

        //InventoryPanel.SetActive(false);
    }


    public void OptionPanelView()
    {

        mainPanel.SetActive(true);
        SwitchVisibleOption();
        //InventoryPanel.SetActive(false);

    }
    public void SwitchVisibleOption()
    {
        OptionPanel.SetActive(!OptionPanel.activeSelf);
    }
    //public void SubView()
    //{
    //    mainPanel.SetActive(true);
    //    OptionPanel.SetActive(false);
    //    Opbutton.SetActive(false);
    //    //InventoryPanel.SetActive(true);
    //    //GameObject.Find("Inventory").transform.position = Vector3.zero;
    //    //GameObject.Find("InventorySlotManager").transform.position = Vector3.zero;
    //    //GameObject.Find("SozaibakoSlotManager").transform.position = new Vector3(-4.4f, -7.94f, 0.0f);

    //}
   
}

