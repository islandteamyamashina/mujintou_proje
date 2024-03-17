using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour
{
    
  
    [SerializeField] Fade fade;
    [SerializeField] Text Text;

    [SerializeField]Button continueButton;
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
    public void Continue(int num)
    {
        if (!DataManager.Instance.DoesSaveExist())
        {
            continueButton.interactable = false;
            string colorString = "#4D4D4D"; // ÔF‚Ì16i”•¶š—ñ
            Color newColor;
            ColorUtility.TryParseHtmlString(colorString, out newColor); // V‚µ‚­Color‚ğì¬
            Text.color = newColor;
        }
        else
        {
            DataManager.Instance.Load();
            fade.scene_name_num = num;
            fade.feadout_f = true;

        }
    }

}

