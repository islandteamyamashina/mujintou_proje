using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditPanel1 : MonoBehaviour
{
    public GameObject Image;
    public GameObject mainPanel;
    public GameObject subPanel;
    public GameObject OptionPanel;
    public GameObject QuitPanel;
    void Start()
    {
        mainPanel.SetActive(true);
        subPanel.SetActive(false);
        OptionPanel.SetActive(false);
        QuitPanel.SetActive(false);
        Image.SetActive(false);
        
    }

    public virtual void MainView()
    {
        mainPanel.SetActive(true);
        subPanel.SetActive(false);
        OptionPanel.SetActive(false);
        QuitPanel.SetActive(false);

        Image.SetActive(false);
    }

    public virtual void SubView()
    {
        mainPanel.SetActive(false);
        subPanel.SetActive(true);
        OptionPanel.SetActive(false);
        QuitPanel.SetActive(false);

        Image.SetActive(false);
    }
    public virtual void CreditView() 
    {
        mainPanel.SetActive(false);
        subPanel.SetActive(false);
        OptionPanel.SetActive(true);
        QuitPanel.SetActive(false);

        Image.SetActive(false);
    }
    public void QuitView()
    {
        mainPanel.SetActive(true);
        subPanel.SetActive(false);
        OptionPanel.SetActive(false);
        QuitPanel.SetActive(true);

        Image.SetActive(true);

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OptionPanel.SetActive(false);
            mainPanel.SetActive(true);
            subPanel.SetActive(false);
            QuitPanel.SetActive(false);

            Image.SetActive(false);
        }


    }
}

