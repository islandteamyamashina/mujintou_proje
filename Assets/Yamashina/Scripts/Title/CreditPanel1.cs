using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

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
        GameObject.Find("InventoryUIPanel").transform.position = new Vector3(375.4f, -1039f, 0.0f);
        GameObject.Find("MaintoInventoryPanel").transform.position = new Vector3(375.4f, -1039f, 0.0f);
        //GameObject.Find("MaintoInventoryPanel").transform.position = Vector3.zero;

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
        ContinueButtonStopImage.SetActive(false);
        GameObject.Find("InventoryManager").transform.position = new Vector3(375.4f, -1039f, 0.0f);

        AllButtonStopImage.SetActive(true);
    }
    public  virtual void InventoryView()
    {
        //mainPanel.SetActive(false);
        //subPanel.SetActive(false);
        //OptionPanel.SetActive(false);

        //GameObject.Find("Inventory").transform.position = Vector3.zero;
        GameObject.Find("InventorySlotManager").transform.position = Vector3.zero;
        GameObject.Find("InventoryUIPanel").transform.position = Vector3.zero;
        GameObject.Find("MaintoInventoryPanel").transform.position = Vector3.zero;
        //inventory = GameObject.Find("Inventory");

        //newbutton.SetActive(false); 
        //wakimizu_tabu.SetActive(false);
    }
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
  

}

