using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour
{

    private void Start()
    {
        eventTrigger.enabled = true;    
        //image.SetActive(false);
        
    }
    //[SerializeField] multiAudio multiAudio;
    [SerializeField] Fade fade;
    [SerializeField] Text Text;
    [SerializeField] EventTrigger eventTrigger;
    [SerializeField] Button continueButton;
    [SerializeField] CreditPanel1 CreditPanel1;
    //[SerializeField] GameObject image;
    // Update is called once per frame
    public void Text_of_each_places(int num = 0)
    {
        if (!DataManager.Instance.DoesSaveExist())
        {
            AfterStart();

        }
        else
        {
            CreditPanel1.startView();
        }



    }
    public void AfterStart(int num = 0)
    {
        SaveData saveData = new SaveData();
        saveData.MakeSaveData();
        DataManager.Instance.Save(saveData);
        fade.scene_name_num = num;
        fade.feadout_f = true;
        if (fade.feadout_f == false)
        {
            PlayerInfo.Instance.gameObject.transform.GetChild(0).gameObject.SetActive(true);

            //SceneManager.sceneUnloaded += VolumeSave_loadsecene;
        }



    }
    public void Continue(int num)
    {
        if (!DataManager.Instance.DoesSaveExist())
        {
            //image.SetActive(true);

            string colorString = "#999999"; // ê‘êFÇÃ16êiêîï∂éöóÒ
            Color newColor;
            ColorUtility.TryParseHtmlString(colorString, out newColor); // êVÇµÇ≠ColorÇçÏê¨
            Text.color = newColor;
            eventTrigger.enabled = false;

        }
        else
        {
            DataManager.Instance.Load();
            fade.scene_name_num = num;
            fade.feadout_f = true;
            //image.SetActive(false);
            if (fade.feadout_f == false)
            {
                PlayerInfo.Instance.gameObject.transform.GetChild(0).gameObject.SetActive(true);


            }

        }
    }
    //public void VolumeSave_loadsecene(Scene scene)
    //{
    //    multiAudio.BgmSave();
    //    multiAudio.SeSave();
    //}


}

