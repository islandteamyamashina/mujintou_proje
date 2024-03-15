using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    
  
    [SerializeField] Fade fade;


    [SerializeField] CreditPanel1 CreditPanel1;
    // Update is called once per frame
    public void Text_of_each_places(int num=0)
    {
        if (!DataManager.Instance.DoesSaveExist())
        {
            AfterStart();
            
        }
        else
        {
          CreditPanel1.startView();      }

        
               
    }
    public void AfterStart(int num=0)
    {
        SaveData saveData = new SaveData();
        saveData.MakeSaveData();
        DataManager.Instance.Save(saveData);

        fade.scene_name_num = num;
        fade.feadout_f = true;

    }
  

}

