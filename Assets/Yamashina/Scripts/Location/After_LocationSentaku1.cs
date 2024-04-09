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
    [SerializeField] SceneObject[] nextScene;
    [SerializeField] Button Syupatsu;
    private int num;



    void Start()
    {
        newPanel.SetActive(false); // パネルを表示する
        eventTriggerKawabe.enabled = true;
        eventTrigger_Doukutu.enabled = true;
        eventTrigger_Forest.enabled = true;
        eventTrigger_Kaigan.enabled = true;
        eventTrigger_Kakou.enabled = true;
        eventTrigger_Sangaku.enabled = true;
        button_Kawabe.enabled = true;
        button_Forest.enabled = true;
        button_Kaigan.enabled = true;
        button_Kakou.enabled = true;
        button_Doukutu.enabled = true;
        button_Sangaku.enabled = true;


    }
    public void OnClick()
    {
        // マウスの左クリックを検知

        ShowNewPanel(); // 新しいUIパネル(After_locationsentakuパネルを表示
                        //  text.SetActive(true);
        eventTriggerKawabe.enabled = false;
        eventTrigger_Doukutu.enabled = false;
        eventTrigger_Forest.enabled = false;
        eventTrigger_Kaigan.enabled = false;
        eventTrigger_Kakou.enabled = false;
        eventTrigger_Sangaku.enabled = false;
        //ボタン関連
        button_Kawabe.enabled = false;
        button_Forest.enabled = false;
        button_Kaigan.enabled = false;
        button_Kakou.enabled = false;
        button_Doukutu.enabled = false;
        button_Sangaku.enabled = false;
    }



    
    public void Sentakuplaces()
    {
       
        if(button_Doukutu.onClick != null) 
        {
            num = 0;
            if (Syupatsu.onClick != null)
            {
                SceneManager.LoadScene(nextScene[num]);
            }
        }
        if(button_Forest.onClick != null)
        {
            num = 1;
            if (Syupatsu.onClick != null)
            {
                SceneManager.LoadScene(nextScene[num]);
            }
        }
        if (button_Forest.onClick != null)
        {
            num = 2;
            if (Syupatsu.onClick != null)
            {
                SceneManager.LoadScene(nextScene[num]);
            }
        }

    }



                        


// 新しいUIパネルを表示する関数
public void ShowNewPanel()
    {
        newPanel.SetActive(true); // パネルを表示する


    }
}
