using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KyotenToOtherspace : CreditPanel1
{
 [SerializeField]  GameObject InventoryPanel;
    [SerializeField]  GameObject TakibiPanel;
    [SerializeField] GameObject WakimizuPanel;
    [SerializeField]  GameObject cookingPanel;
    [SerializeField] GameObject sleeppingPanel;
    [SerializeField] Prehubdelete prehubdelete;
    [SerializeField] GameObject prefab;
    //public GameObject takibi_tabu;
    //public GameObject wakimizu_tabu;
    public float takibi = 0;
    public bool takibi_f;
    //  [SerializeField] public Text takibi_number; // 新しいUIパネルへの参照

    //bool takibicheck = false;



    // Start is called before the first frame update
    void Start()
    {
       // prehubdelete.deletePrehub();
        mainPanel.SetActive(true);
        subPanel.SetActive(false);
        OptionPanel.SetActive(false);
        InventoryPanel.SetActive(false);
        TakibiPanel.SetActive(false);
        WakimizuPanel.SetActive(false);
        cookingPanel.SetActive(false);
        sleeppingPanel.SetActive(false);
        //takibi_tabu.SetActive(false);
        //wakimizu_tabu.SetActive(false);
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
        sleeppingPanel.SetActive(false);
        //takibi_tabu.SetActive(false);
        //wakimizu_tabu.SetActive (false);        

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
        sleeppingPanel.SetActive(false);
        //takibi_tabu.SetActive(false);
        //wakimizu_tabu.SetActive(false);


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
        sleeppingPanel.SetActive(false);
        cookingPanel.SetActive(false);
       
        //takibi_tabu.SetActive(false);
        //wakimizu_tabu.SetActive(false);

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
        sleeppingPanel.SetActive(false);
        Debug.Log("sleepingPanel消しました");
        cookingPanel.SetActive(false);
        
        //takibi_tabu.SetActive(false);
        //wakimizu_tabu.SetActive(false);

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
        sleeppingPanel.SetActive(false);
        cookingPanel.SetActive(false);
      
        //takibi_tabu.SetActive(false);
        //wakimizu_tabu.SetActive(false);

    }
    public void TakibiView()
    {
        //Debug.Log("takibi" + takibi);
        // if (!takibicheck)
        //{
        //if (Boolnumber())
        //{
        takibi_f = true;
        mainPanel.SetActive(false);
        subPanel.SetActive(false);
        OptionPanel.SetActive(false);
        cookingPanel.SetActive(false);
        InventoryPanel.SetActive(false);
        TakibiPanel.SetActive(true);
        WakimizuPanel.SetActive(false);
        sleeppingPanel.SetActive(false);
        cookingPanel.SetActive(false);
       
        //    takibi_tabu.SetActive(false);
        //    wakimizu_tabu.SetActive(false);
        //}
        //  }
        //else if (!takibicheck)
        //{
        //    MainView();

        //}

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
        sleeppingPanel.SetActive(false);
        cookingPanel.SetActive(false);
       
        //takibi_tabu.SetActive(false);
        //wakimizu_tabu.SetActive(false);



    }
    public void sleepingView()
    {
        Instantiate(prefab);

        mainPanel.SetActive(false);
        subPanel.SetActive(false);
        OptionPanel.SetActive(false);
        cookingPanel.SetActive(false);
        InventoryPanel.SetActive(false);
        TakibiPanel.SetActive(false);
        WakimizuPanel.SetActive(false);
        sleeppingPanel.SetActive(true);
        cookingPanel.SetActive(false);
       
        //takibi_tabu.SetActive(false);
        //wakimizu_tabu.SetActive(false);




    }
    //public void takibi_tabuPanel()
    //{
    //    mainPanel.SetActive(true);
    //    subPanel.SetActive(false);
    //    OptionPanel.SetActive(false);
    //    InventoryPanel.SetActive(false);
    //    TakibiPanel.SetActive(false);
    //    WakimizuPanel.SetActive(false);
    //    cookingPanel.SetActive(false);
    //    sleeppingPanel.SetActive(false);
    //    //takibi_tabu.SetActive(true);
    //    //wakimizu_tabu.SetActive(false);
    //    // takibi_number.text = "焚き火:" + takibi;

    //}
    //bool Boolnumber()
    //{


    //    if (takibi <=0)
    //    {
    //        takibicheck = true;
    //        takibi = 100;
    //        return true;
    //    }
    //    else 
    //    {
    //        takibicheck = false;
    //        return false;
    //    }
    //}

}



