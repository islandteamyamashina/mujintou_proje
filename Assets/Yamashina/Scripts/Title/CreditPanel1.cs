using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CreditPanel1 : MonoBehaviour
{
   
    //public GameObject UICanvas;
    public GameObject mainPanel;
    public GameObject subPanel;
    public GameObject OptionPanel;
    public GameObject QuitPanel;
    public GameObject startPanel;
    //public Button start;
    //public Button Continue;
    //public Button quit;
    //public Button Credit;
    //public Button option;
    [SerializeField] GameObject startButton;
    [SerializeField] GameObject ContinueButton;
    [SerializeField] GameObject quitButton;
    [SerializeField] GameObject CreditButton;
    [SerializeField] GameObject optionButton;

    //[SerializeField] EventTrigger eventTrigger_start;
    //[SerializeField] EventTrigger eventTrigger_quit;
    //[SerializeField] EventTrigger eventTrigger_Credit;
    //[SerializeField] EventTrigger eventTrigger_option;
    //[SerializeField] EventTrigger eventTrigger_Continue_;


    //public Button invenntory;
    //public Button ExitInventory;

    void Start()
    {
        mainPanel.SetActive(true);
        subPanel.SetActive(false);
        OptionPanel.SetActive(false);
        QuitPanel.SetActive(false);
        startPanel.SetActive(false);
        startButton.SetActive(true);   
        ContinueButton.SetActive(true);
        optionButton.SetActive(true);
        quitButton.SetActive(true); 
        CreditButton.SetActive(true);   
        
        //eventTrigger_start.enabled = true;
        //eventTrigger_quit.enabled = true;   
        //eventTrigger_option.enabled = true;     
        //eventTrigger_Credit.enabled = true;
        //eventTrigger_Continue_.enabled = true;  

        //ExitInventory.interactable = false;
        //invenntory.interactable = true;

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

        startButton.SetActive(true);
        ContinueButton.SetActive(true);
        optionButton.SetActive(true);
        quitButton.SetActive(true);
        CreditButton.SetActive(true);
        //GameObject.Find("InventoryUIPanel").transform.position = new Vector3(375.4f, -1039f, 0.0f);
        //GameObject.Find("SozaibakoPanel").transform.position = new Vector3(375.4f, -1039f, 0.0f);


       
        //eventTrigger_start.enabled = true;
        //eventTrigger_quit.enabled = true;
        //eventTrigger_option.enabled = true;
        //eventTrigger_Credit.enabled = true;
        //eventTrigger_Continue_.enabled = true;


    }

    public virtual void SubView()
    {
        mainPanel.SetActive(true);
        subPanel.SetActive(true);
        OptionPanel.SetActive(false);
        QuitPanel.SetActive(false);
        startPanel.SetActive(false);
        startButton.SetActive(false);
        ContinueButton.SetActive(false);
        optionButton.SetActive(false);
        quitButton.SetActive(false);
        CreditButton.SetActive(false);
        //eventTrigger_start.enabled = false;
        //eventTrigger_quit.enabled = false;
        //eventTrigger_option.enabled = false;
        //eventTrigger_Credit.enabled = false;
        //eventTrigger_Continue_.enabled = false;

    }
    public virtual void CreditView()
    {
        mainPanel.SetActive(true);
        subPanel.SetActive(false);
        OptionPanel.SetActive(true);
        QuitPanel.SetActive(false);
        startPanel.SetActive(false);
        //start.interactable = false;
        startButton.SetActive(false);
        ContinueButton.SetActive(false);
        optionButton.SetActive(false);
        quitButton.SetActive(false);
        CreditButton.SetActive(false);
        //Continue.interactable = false;
        //Credit.interactable = false;
        //quit.interactable = false;
        //option.interactable = false;
        //eventTrigger_start.enabled = false;
        //eventTrigger_quit.enabled = false;
        //eventTrigger_option.enabled = false;
        //eventTrigger_Credit.enabled = false;
        //eventTrigger_Continue_.enabled = false;

    }
    public void QuitView()
    {
        mainPanel.SetActive(true);
        subPanel.SetActive(false);
        OptionPanel.SetActive(false);
        QuitPanel.SetActive(true);
        startPanel.SetActive(false);
        //start.interactable = false;
        //Continue.interactable = false;
        //Credit.interactable = false;
        //quit.interactable = false;
        //option.interactable = false;
        startButton.SetActive(false);
        ContinueButton.SetActive(false);
        optionButton.SetActive(false);
        quitButton.SetActive(false);
        CreditButton.SetActive(false);

    }
    public void startView()
    {
        mainPanel.SetActive(true);
        subPanel.SetActive(false);
        OptionPanel.SetActive(false);
        QuitPanel.SetActive(false);
        startPanel.SetActive(true);
        //start.interactable = false;
        //Continue.interactable = false;
        //Credit.interactable = false;
        //option.interactable = false;
        //quit.interactable = false;
        startButton.SetActive(false);
        ContinueButton.SetActive(false);
        optionButton.SetActive(false);
        quitButton.SetActive(false);
        CreditButton.SetActive(false);

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
            //start.interactable = true;
            //Continue.interactable = true;
            //Credit.interactable = true;
            //quit.interactable = true;
            //option.interactable = true;
            startButton.SetActive(true);
            ContinueButton.SetActive(true);
            optionButton.SetActive(true);
            quitButton.SetActive(true);
            CreditButton.SetActive(true);

        }


    }
    //public virtual void SozaibakoView()
    //{


    //    GameObject.Find("SozaibakoSlotManager").transform.position = Vector3.zero;
    //    GameObject.Find("InventorySlotManager").transform.position = new Vector3(375.4f, -1039f, 0.0f);

    //    GameObject.Find("SozaibakoPanel").transform.position = new Vector3(375.4f, -1039f, 0.0f);



    //}


}

