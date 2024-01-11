using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KyotenToOtherspace : CreditPanel1
{
    public GameObject InventoryPanel;
    public GameObject TakibiPanel;
    public GameObject WakimizuPanel;
    public GameObject cookingPanel;


    // Start is called before the first frame update
    void Start()
    {
        mainPanel.SetActive(true);
        subPanel.SetActive(false);
        OptionPanel.SetActive(false);
        InventoryPanel.SetActive(false);
        TakibiPanel.SetActive(false);
        WakimizuPanel.SetActive(false);
        cookingPanel.SetActive(false);
    }

    // Update is called once per frame
    public override void MainView()
    {
        mainPanel.SetActive(true);
        subPanel.SetActive(false);
        OptionPanel.SetActive(false);
        InventoryPanel.SetActive(false);
        TakibiPanel.SetActive(false);
        WakimizuPanel.SetActive(false);
        cookingPanel.SetActive(false);

    }

    public override void SubView()
    {
        mainPanel.SetActive(false);
        subPanel.SetActive(true);
        OptionPanel.SetActive(false);
        InventoryPanel.SetActive(false);
        TakibiPanel.SetActive(false);
        WakimizuPanel.SetActive(false);
        cookingPanel.SetActive(false);


    }
    public override void CreditView()
    {
        mainPanel.SetActive(false);
        subPanel.SetActive(false);
        OptionPanel.SetActive(true);
        InventoryPanel.SetActive(false);
        TakibiPanel.SetActive(false);
        WakimizuPanel.SetActive(false);
        cookingPanel.SetActive(false);

    }

    public void InventoryView()
    {
        mainPanel.SetActive(false);
        subPanel.SetActive(false);
        OptionPanel.SetActive(false);
        cookingPanel.SetActive(false);
        InventoryPanel.SetActive(true);
        TakibiPanel.SetActive(false);
        WakimizuPanel.SetActive(false);

    }
    public void WakimizuView()
    {
        mainPanel.SetActive(false);
        subPanel.SetActive(false);
        OptionPanel.SetActive(false);
        cookingPanel.SetActive(false);
        InventoryPanel.SetActive(false);
        TakibiPanel.SetActive(false);
        WakimizuPanel.SetActive(true);

    }
    public void TakibiView()
    {
        mainPanel.SetActive(false);
        subPanel.SetActive(false);
        OptionPanel.SetActive(false);
        cookingPanel.SetActive(false);
        InventoryPanel.SetActive(false);
        TakibiPanel.SetActive(true);
        WakimizuPanel.SetActive(false);

    }
    public void CookingView()
    {
        mainPanel.SetActive(false);
        subPanel.SetActive(false);
        OptionPanel.SetActive(false);
        cookingPanel.SetActive(true);
        InventoryPanel.SetActive(false);
        TakibiPanel.SetActive(false);
        WakimizuPanel.SetActive(false);

    }
}


