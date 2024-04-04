using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class After_LocationSentaku1 : MonoBehaviour
{
    public GameObject newPanel; // 新しいUIパネルへの参照
                                // public GameObject text;
                                // public KyotenToOtherspace kyotenToOtherspace;
    [SerializeField]
    string sceneName;
    [SerializeField] Fade fade;
    [SerializeField] EventTrigger eventTriggerKawabe;
    [SerializeField] EventTrigger eventTrigger_Forest;
    [SerializeField] EventTrigger eventTrigger_Kaigan;
    [SerializeField] EventTrigger eventTrigger_Doukutu;
    [SerializeField] EventTrigger eventTrigger_Sangaku;
    [SerializeField] EventTrigger eventTrigger_Kakou;
    [SerializeField] Button button_Kawabe;
    [SerializeField] Button button_Forest;
    [SerializeField] Button button_Kaigan;
    [SerializeField] Button button_Doukutu;
    [SerializeField] Button button_Sangaku;
    [SerializeField] Button button_Kakou;




    void Start()
    {
        newPanel.SetActive(false); // パネルを表示する
        eventTriggerKawabe.enabled = true;
        eventTrigger_Doukutu.enabled = true;
        button_Kawabe.enabled = true;
        button_Forest.enabled = true;
        button_Kaigan.enabled = true;
        button_Kakou.enabled = true;


    }
    public void OnClick()
    {
        // マウスの左クリックを検知

        ShowNewPanel(); // 新しいUIパネル(After_locationsentakuパネルを表示
                        //  text.SetActive(true);

    }



    public void yesnobutton(int num) //ここに引数を入れておくことでそれぞれのボタンごとにUnity側で引数を指定できる。
    {

        switch (num)
        {


            case 1: //押されたボタンのUnity側で設定された引数が1のだったとき
                Debug.Log("Aのボタンが押されたよ");
                fade.feadout_f = true;

                break;
            case 2: //押されたボタンのUnity側で設定された引数が2のだったとき
                Debug.Log("Bのボタンが押されたよ");
                newPanel.SetActive(false);
                //  kyotenToOtherspace.MainView();

                break;

        }

    }


    // 新しいUIパネルを表示する関数
    public void ShowNewPanel()
    {
        newPanel.SetActive(true); // パネルを表示する

    }
}
