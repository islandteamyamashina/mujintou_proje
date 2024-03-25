using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CreditPanel1 : MonoBehaviour
{
    public GameObject AllButtonStopImage;
    public GameObject ContinueButtonStopImage;
    //public GameObject UICanvas;
    public GameObject mainPanel;
    public GameObject subPanel;
    public GameObject OptionPanel;
    public GameObject QuitPanel;
    public GameObject startPanel;
    public Button start;
    public Button Continue;
    public Button quit;
    public Button Credit;
    public Button option;
    //public Button invenntory;
    //public Button ExitInventory;

    void Start()
    {
        mainPanel.SetActive(true);
        subPanel.SetActive(false);
        OptionPanel.SetActive(false);
        QuitPanel.SetActive(false);
        AllButtonStopImage.SetActive(false);
        startPanel.SetActive(false);
        ContinueButtonStopImage.SetActive(false);
        GameObject.Find("InventorySlotManager").transform.position = new Vector3(375.4f, -1039f, 0.0f);
       
        GameObject.Find("SozaibakoSlotManager").transform.position = new Vector3(-4.4f, -7.94f, 0.0f);

        //ExitInventory.interactable = false;
        //invenntory.interactable = true;
        GameObject.Find("PlayerPanel").transform.position = new Vector3(375.4f, -1039f, 0.0f);

        //GameObject.Find("SozaibakoPanel").transform.position = new Vector3(375.4f, -1039f, 0.0f);

        //inventory = GameObject.Find("Inventory");
        //inventory.SetActive(false);
        //  InventorySlot.SetActive(false);
        //UICanvas.SetActive(false);
    }

    public virtual void MainView()
    {
        mainPanel.SetActive(true);
        subPanel.SetActive(false);
        OptionPanel.SetActive(false);
        QuitPanel.SetActive(false);
        startPanel.SetActive(false);
        AllButtonStopImage.SetActive(false);
        ContinueButtonStopImage.SetActive(false);
        GameObject.Find("InventorySlotManager").transform.position = new Vector3(375.4f, -1039f, 0.0f);
        //GameObject.Find("InventoryUIPanel").transform.position = new Vector3(375.4f, -1039f, 0.0f);
        GameObject.Find("SozaibakoSlotManager").transform.position = new Vector3(-4.4f, -7.94f, 0.0f);
        //GameObject.Find("SozaibakoPanel").transform.position = new Vector3(375.4f, -1039f, 0.0f);


        start.interactable = true;
        Continue.interactable = true;
        Credit.interactable = true;
        quit.interactable = true;
        option.interactable = true;



    }

    public virtual void SubView()
    {
        mainPanel.SetActive(true);
        subPanel.SetActive(true);
        OptionPanel.SetActive(false);
        QuitPanel.SetActive(false);
        startPanel.SetActive(false);
        ContinueButtonStopImage.SetActive(false);

        AllButtonStopImage.SetActive(true);
    }
    public virtual void CreditView()
    {
        mainPanel.SetActive(true);
        subPanel.SetActive(false);
        OptionPanel.SetActive(true);
        QuitPanel.SetActive(false);
        startPanel.SetActive(false);
        ContinueButtonStopImage.SetActive(false);

        AllButtonStopImage.SetActive(true);
    }
    public void QuitView()
    {
        mainPanel.SetActive(true);
        subPanel.SetActive(false);
        OptionPanel.SetActive(false);
        QuitPanel.SetActive(true);
        startPanel.SetActive(false);
        ContinueButtonStopImage.SetActive(false);

        AllButtonStopImage.SetActive(true);

    }
    public void startView()
    {
        mainPanel.SetActive(true);
        subPanel.SetActive(false);
        OptionPanel.SetActive(false);
        QuitPanel.SetActive(false);
        startPanel.SetActive(true);
        start.interactable = false;
        Continue.interactable = false;
        Credit.interactable = false;
        option.interactable = false;
        quit.interactable = false;


    }
    //public virtual void InventoryView()
    //{
    //    //mainPanel.SetActive(false);
    //    //subPanel.SetActive(false);
    //    //OptionPanel.SetActive(false);

    //    //GameObject.Find("Inventory").transform.position = Vector3.zero;
    //    GameObject.Find("InventorySlotManager").transform.position = Vector3.zero;
       
    //    GameObject.Find("SozaibakoSlotManager").transform.position = new Vector3(-4.4f, -7.94f, 0.0f);
    //    //GameObject.Find("SozaibakoPanel").transform.position = new Vector3(375.4f, -1039f, 0.0f);


    //    //inventory = GameObject.Find("Inventory");

    //    //newbutton.SetActive(false); 
    //    //wakimizu_tabu.SetActive(false);
    //}
    //public void ToMainView()
    //{
    //    GameObject.Find("InventorySlotManager").transform.position = new Vector3(375.4f, -1039f, 0.0f);
      
    //    GameObject.Find("SozaibakoSlotManager").transform.position = new Vector3(-4.4f, -7.94f, 0.0f);
    //    //GameObject.Find("SozaibakoPanel").transform.position = Vector3.zero;


    //    //ExitInventory.interactable = false;
    //    //invenntory.interactable = true;
    //}
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OptionPanel.SetActive(false);
            mainPanel.SetActive(true);
            subPanel.SetActive(false);
            QuitPanel.SetActive(false);
            startPanel.SetActive(false);
            ContinueButtonStopImage.SetActive(false);

            AllButtonStopImage.SetActive(false);
        }


    }
    //public virtual void SozaibakoView()
    //{


    //    GameObject.Find("SozaibakoSlotManager").transform.position = Vector3.zero;
    //    GameObject.Find("InventorySlotManager").transform.position = new Vector3(375.4f, -1039f, 0.0f);

    //    GameObject.Find("SozaibakoPanel").transform.position = new Vector3(375.4f, -1039f, 0.0f);



    //}


}

