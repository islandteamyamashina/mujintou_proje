using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour
{

    private void Start()
    {
        image.SetActive(false); 
    }
    [SerializeField] Fade fade;
    [SerializeField] Text Text;

    [SerializeField]Button continueButton;
    [SerializeField] CreditPanel1 CreditPanel1;
    [SerializeField] GameObject image;
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
            image.SetActive(true);

            string colorString = "#999999"; // 赤色の16進数文字列
            Color newColor;
            ColorUtility.TryParseHtmlString(colorString, out newColor); // 新しくColorを作成
            Text.color = newColor;

        }
        else
        {
            DataManager.Instance.Load();
            fade.scene_name_num = num;
            fade.feadout_f = true;
            image.SetActive(false);


        }
    }

}

