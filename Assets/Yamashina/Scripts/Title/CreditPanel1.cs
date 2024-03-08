using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditPanel1 : MonoBehaviour
{
    public GameObject AllButtonStopImage;
    public GameObject ContinueButtonStopImage;

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
        GameObject.Find("InventoryPanel").transform.position = new Vector3(375.4f, -1039f, 0.0f);
        ContinueButtonStopImage.SetActive(false);   
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

        AllButtonStopImage.SetActive(true);
    }
    public virtual void CreditView() 
    {
        mainPanel.SetActive(true);
        subPanel.SetActive(false);
        OptionPanel.SetActive(true);
        QuitPanel.SetActive(false);
        startPanel.SetActive(false);

        AllButtonStopImage.SetActive(true);
    }
    public void QuitView()
    {
        mainPanel.SetActive(true);
        subPanel.SetActive(false);
        OptionPanel.SetActive(false);
        QuitPanel.SetActive(true);
        startPanel.SetActive(false);

        AllButtonStopImage.SetActive(true);

    }
    public void startView() 
    {
        mainPanel.SetActive(true);
        subPanel.SetActive(false);
        OptionPanel.SetActive(false);
        QuitPanel.SetActive(false);
        startPanel.SetActive(true);

        AllButtonStopImage.SetActive(true);
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

            AllButtonStopImage.SetActive(false);
        }


    }
}

