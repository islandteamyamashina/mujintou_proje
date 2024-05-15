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

        string colorString2 = "#4D4D4D"; // 赤色の16進数文字列
        Color newColor2;
        ColorUtility.TryParseHtmlString(colorString2, out newColor2); // 新しくColorを作成
        Text.color = newColor2;
       
            if (!DataManager.DoesSaveExist())
            {

                //image.SetActive(true);

                string colorString = "#999999"; // 赤色の16進数文字列
                Color newColor;
                ColorUtility.TryParseHtmlString(colorString, out newColor); // 新しくColorを作成
                Text.color = newColor;
                eventTrigger.enabled = false;
                continueButton.enabled = false;


            }
            
        

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
   [SerializeField] GameObject playerInfo;
    //[SerializeField] GameObject image;
    // Update is called once per frame
    public void Text_of_each_places(int num = 0)
    {
        if (!DataManager.DoesSaveExist())
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
        Instantiate(playerInfo);
        PlayerInfo.Instance.StartGame(true);

        fade.feadout_f = true;
        if (fade.feadout_f == false)
        {
            //PlayerInfo.Instance.gameObject.transform.GetChild(0).GetChild(0).gameObject.SetActive(true);

        }


        //SceneManager.sceneUnloaded += VolumeSave_loadsecene;




    }
    public void Continue(int num)
    {
        if (!DataManager.DoesSaveExist())
        {

            //image.SetActive(true);


            eventTrigger.enabled = false;
            continueButton.enabled = false;


        }
        else
        {
            fade.scene_name_num = num;
            Instantiate(playerInfo);
            PlayerInfo.Instance.StartGame(false);
            fade.feadout_f = true;
            if (fade.feadout_f == false)
            {
                //PlayerInfo.Instance.gameObject.transform.GetChild(0).GetChild(0).gameObject.SetActive(true);

            }

        }


        //public void VolumeSave_loadsecene(Scene scene)
        //{
        //    multiAudio.BgmSave();
        //    multiAudio.SeSave();
        //}

    }
    }

