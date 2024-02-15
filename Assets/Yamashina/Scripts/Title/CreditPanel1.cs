using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditPanel1 : MonoBehaviour
{
    public GameObject mainPanel;
    public GameObject subPanel;
    public GameObject OptionPanel;

    void Start()
    {
        mainPanel.SetActive(true);
        subPanel.SetActive(false);
        OptionPanel.SetActive(false);
        quitPanel();
    }

    public virtual void MainView()
    {
        mainPanel.SetActive(true);
        subPanel.SetActive(false);
        OptionPanel.SetActive(false);

    }

    public virtual void SubView()
    {
        mainPanel.SetActive(false);
        subPanel.SetActive(true);
        OptionPanel.SetActive(false);

    }
    public virtual void CreditView() 
    {
        mainPanel.SetActive(false);
        subPanel.SetActive(false);
        OptionPanel.SetActive(true);
    }
    public void quitPanel()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {



            MainView();


        }

    }
}
