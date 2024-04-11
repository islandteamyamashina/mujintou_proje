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
        //if (CreditPanel1 = null)
        //{
        //    CreditPanel1 = GameObject.FindAnyObjectByType<CreditPanel1>();
        //}
        //else
        //{
        //    Debug.Log("credit is not null");

        //}
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
        fade.scene_name_num = num;
        fade.feadout_f = true;
        if (fade.feadout_f == false)
        {
            PlayerInfo.Instance.StartGame(true);

            PlayerInfo.Instance.gameObject.transform.GetChild(0).gameObject.SetActive(true);

            //SceneManager.sceneUnloaded += VolumeSave_loadsecene;
        }



    }
    public void Continue(int num)
    {
        if (!DataManager.Instance.DoesSaveExist())
        {
            //image.SetActive(true);

            string colorString = "#999999"; // 赤色の16進数文字列
            Color newColor;
            ColorUtility.TryParseHtmlString(colorString, out newColor); // 新しくColorを作成
            Text.color = newColor;
            eventTrigger.enabled = false;

        }
        else if(DataManager.Instance.DoesSaveExist())
        { 
            fade.scene_name_num = num;
            fade.feadout_f = true;
            if (fade.feadout_f == false)
            {


                PlayerInfo.Instance.StartGame(false);

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

