using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CreditPanel1 : MonoBehaviour
{
    //パネル関係
    public GameObject mainPanel;
    public GameObject subPanel;
    public GameObject OptionPanel;
    public GameObject QuitPanel;
    public GameObject startPanel;

    //ゲームオブジェクトのボタン(Setactive)
    [SerializeField] GameObject startButton;
    [SerializeField] GameObject ContinueButton;
    [SerializeField] GameObject quitButton;
    [SerializeField] GameObject CreditButton;
    [SerializeField] GameObject optionButton;

    //ボタンのイベントトリガー関連
    [SerializeField] EventTrigger eventTrigger_start;
    [SerializeField] EventTrigger eventTrigger_quit;
    [SerializeField] EventTrigger eventTrigger_Credit;
    [SerializeField] EventTrigger eventTrigger_option;
    //[SerializeField] EventTrigger eventTrigger_Continue_;

    //ボタン機能関連（Interactive)
    public Button start;

    //public Button Continue;
    public Button quit;
    public Button Credit;
    public Button option;

    void Start()//始まるとき
    {
        //パネル関係
        mainPanel.SetActive(true);
        subPanel.SetActive(false);
        OptionPanel.SetActive(false);
        QuitPanel.SetActive(false);
        startPanel.SetActive(false);

        //ゲームオブジェクトのボタン(Setactive)
        startButton.SetActive(true);
        ContinueButton.SetActive(true);
        optionButton.SetActive(true);
        quitButton.SetActive(true);
        CreditButton.SetActive(true);

        //シングルトン
        PlayerInfo.Instance.gameObject.transform.GetChild(0).gameObject.SetActive(false);

        //ボタンのイベントトリガー関連
        eventTrigger_start.enabled = true;
        eventTrigger_quit.enabled = true;
        eventTrigger_option.enabled = true;
        eventTrigger_Credit.enabled = true;

        //ボタン機能関連（Interactive)
        start.interactable = true;  
        quit.interactable = true;   
        Credit.interactable = true; 
        option.interactable = true; 
        //eventTrigger_Continue_.enabled = true;

    }

    public virtual void MainView()//メイン画面のみ表示
    {
        if (startPanel.activeSelf)
        {
            StartSlideOut();
            startPanel.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            startPanel.SetActive(false);

        }
        if (subPanel.activeSelf)
        {
            StartSlideOut();
            subPanel.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            subPanel.SetActive(false);
            
        }
        if (OptionPanel.activeSelf)
        {
            StartSlideOut();
            OptionPanel.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            OptionPanel.SetActive(false);

        }
        if (QuitPanel.activeSelf)
        {
            StartSlideOut();
            QuitPanel.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            
            QuitPanel.SetActive(false);

        }
        //パネル関係
        mainPanel.SetActive(true);
        
        
       

        //ゲームオブジェクトのボタン(Setactive)
        startButton.SetActive(true);
        ContinueButton.SetActive(true);
        optionButton.SetActive(true);
        quitButton.SetActive(true);
        CreditButton.SetActive(true);
       
        //ボタンのイベントトリガー関連
        eventTrigger_start.enabled = true;
        eventTrigger_quit.enabled = true;
        eventTrigger_option.enabled = true;
        eventTrigger_Credit.enabled = true;

        //ボタン機能関連（Interactive)
        start.interactable = true;
        quit.interactable = true;
        Credit.interactable = true;
        option.interactable = true;
        
        
    }

    public virtual void SubView() //クレジット画面表示
    {
        //パネル関係
        mainPanel.SetActive(true);
        subPanel.SetActive(true);
        OptionPanel.SetActive(false);
        QuitPanel.SetActive(false);
        startPanel.SetActive(false);

        //ゲームオブジェクトのボタン(Setactive)
        startButton.SetActive(false);
        ContinueButton.SetActive(false);
        optionButton.SetActive(false);
        quitButton.SetActive(false);
        CreditButton.SetActive(true);

        //ボタンのイベントトリガー関連
        //eventTrigger_start.enabled = false;
        //eventTrigger_quit.enabled = false;
        //eventTrigger_option.enabled = false;
        eventTrigger_Credit.enabled = false;
        //eventTrigger_Continue_.enabled = false;

        //ボタン機能関連（Interactive)
        //start.interactable = false;
        //quit.interactable = false;
        Credit.interactable = false;
        //option.interactable = false;

        //パネル拡大する前（オプションパネル）
        if (subPanel.activeSelf)
        {
            subPanel.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            StartSlidein();
        }
    }

    public virtual void CreditView()//オプション表示
    {
        //パネル関係
        mainPanel.SetActive(true);
        subPanel.SetActive(false);
        OptionPanel.SetActive(true);
        QuitPanel.SetActive(false);
        startPanel.SetActive(false);

        //ゲームオブジェクトのボタン(Setactive)
        startButton.SetActive(false);
        ContinueButton.SetActive(false);
        optionButton.SetActive(true);
        quitButton.SetActive(false);
        CreditButton.SetActive(false);

        //ボタンのイベントトリガー関連
        //eventTrigger_start.enabled = false;
        //eventTrigger_quit.enabled = false;
        eventTrigger_option.enabled = false;
        //eventTrigger_Credit.enabled = false;
        //eventTrigger_Continue_.enabled = false;

        //ボタン機能関連（Interactive)
        //start.interactable = false;
        //Continue.interactable = false;
        //Credit.interactable = false;
        //quit.interactable = false;
        option.interactable = false;

        //パネル拡大する前（オプションパネル）
        if (OptionPanel.activeSelf)
        {
            OptionPanel.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            StartSlidein();
        }
    }

    public void QuitView()//終了画面表示
    {
        //パネル関係
        mainPanel.SetActive(true);
        subPanel.SetActive(false);
        OptionPanel.SetActive(false);
        QuitPanel.SetActive(true);
        startPanel.SetActive(false);

        //ゲームオブジェクトのボタン(Setactive)
        startButton.SetActive(false);
        ContinueButton.SetActive(false);
        optionButton.SetActive(false);
        quitButton.SetActive(true);
        CreditButton.SetActive(false);

        //ボタンのイベントトリガー関連
        //eventTrigger_start.enabled = false;
        eventTrigger_quit.enabled = false;
        //eventTrigger_option.enabled = false;
        //eventTrigger_Credit.enabled = false;
        //eventTrigger_Continue_.enabled = false;

        //ボタン機能関連（Interactive)
        //start.interactable = false;
        //Continue.interactable = false;
        //Credit.interactable = false;
        quit.interactable = false;
        //option.interactable = false;

        //パネル拡大する前（終了パネル）
        if (QuitPanel.activeSelf)
        {
            QuitPanel.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            StartSlidein();
        }
    }
    public void startView()//スタートパネル表示
    {
        //パネル関係
        mainPanel.SetActive(true);
        subPanel.SetActive(false);
        OptionPanel.SetActive(false);
        QuitPanel.SetActive(false);
        startPanel.SetActive(true);

        //ゲームオブジェクトのボタン(Setactive)
        startButton.SetActive(true);
        ContinueButton.SetActive(false);
        optionButton.SetActive(false);
        quitButton.SetActive(false);
        CreditButton.SetActive(false);

        //ボタンのイベントトリガー関連
        eventTrigger_start.enabled = false;
        //eventTrigger_quit.enabled = false;
        //eventTrigger_option.enabled = false;
        //eventTrigger_Credit.enabled = false;
        //eventTrigger_Continue_.enabled = false;

        //ボタン機能関連（Interactive)
        start.interactable = false;
        //Continue.interactable = false;
        //Credit.interactable = false;
        //option.interactable = false;
        //quit.interactable = false;

        //パネル拡大する前（スタートパネル）
        if (startPanel.activeSelf)
        {
            startPanel.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            StartSlidein();
        }
    }
    
    public void StartSlidein()//パネル拡大開始のための関数
    {
        StartCoroutine(ChangePaneltoBigSize());
    }

    //パネル拡大(汎用)
    public IEnumerator ChangePaneltoBigSize()
    {
        var size = 0f;
        var speed = 0.05f;
        var size2 = 0f;
        var size3 = 0f;
        var size4 = 0f;


        //パネル拡大（スタートパネル）

        while (size <= 1.0f && startPanel.activeSelf)
        {
            startPanel.transform.localScale = Vector3.Lerp(new Vector3(1.0f, 1.0f, 1.0f), new Vector3(1.5f, 1.5f, 1.5f), size);
            size += speed;

            yield return null;
        }
        //パネル拡大（オプションパネル）
        while (size2 <= 1.0f && OptionPanel.activeSelf)
        {
            OptionPanel.transform.localScale = Vector3.Lerp(new Vector3(0.5f, 0.5f, 0.5f), new Vector3(1.0f, 1.0f, 1.0f), size2);
            size2 += speed;

            yield return null;
        }
        //パネル拡大（クレジットパネル）

        while (size3 <= 1.0f && subPanel.activeSelf)
        {
            subPanel.transform.localScale = Vector3.Lerp(new Vector3(0.5f, 0.5f, 0.5f), new Vector3(1.0f, 1.0f, 1.0f), size3);
            size3 += speed;

            yield return null;
        }

        //パネル拡大（終了パネル）

        while (size4 <= 1.0f && QuitPanel.activeSelf)
        {
            QuitPanel.transform.localScale = Vector3.Lerp(new Vector3(0.5f, 0.5f, 0.5f), new Vector3(1.0f, 1.0f, 1.0f), size4);
            size4 += speed;

            yield return null;
        }

    }

    public void StartSlideOut()//パネル縮小開始のための関数
    {
        StartCoroutine(ChangePaneltoSmallSize());
    }

    //パネル縮小(汎用)
    public IEnumerator ChangePaneltoSmallSize()
    {
        var size = 0f;
        var speed = 0.05f;
        var size2 = 0f;
        var size3 = 0f;
        var size4 = 0f;


        //パネル縮小（スタートパネル）

        while (size <= 1.0f && startPanel.activeSelf)
        {
            startPanel.transform.localScale = Vector3.Lerp(new Vector3(1.5f, 1.5f, 1.5f), new Vector3(1.0f, 1.0f, 1.0f), size);
            size -= speed;

            yield return null;
        }
        //パネル縮小（オプションパネル）
        while (size2 <= 1.0f && OptionPanel.activeSelf)
        {
            OptionPanel.transform.localScale = Vector3.Lerp(new Vector3(1.0f, 1.0f, 1.0f), new Vector3(0.5f, 0.5f, 0.5f), size2);
            size2 -= speed;

            yield return null;
        }
        //パネル縮小（クレジットパネル）

        while (size3 <= 1.0f && subPanel.activeSelf)
        {
            subPanel.transform.localScale = Vector3.Lerp(new Vector3(1.0f, 1.0f, 1.0f), new Vector3(0.5f, 0.5f, 0.5f), size3);
            size3 -= speed;

            yield return null;
        }

        //パネル拡大（終了パネル）

        while (size4 <= 1.0f && QuitPanel.activeSelf)
        {
            QuitPanel.transform.localScale = Vector3.Lerp(new Vector3(1.0f, 1.0f, 1.0f), new Vector3(0.5f, 0.5f, 0.5f), size4);
            size4 -= speed;

            yield return null;
        }

    }
    void Update()
    {
        //escapeキー対応
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //パネル関係
            OptionPanel.SetActive(false);
            mainPanel.SetActive(true);
            subPanel.SetActive(false);
            QuitPanel.SetActive(false);
            startPanel.SetActive(false);

            //ゲームオブジェクトのボタン(Setactive)
            startButton.SetActive(true);
            ContinueButton.SetActive(true);
            optionButton.SetActive(true);
            quitButton.SetActive(true);
            CreditButton.SetActive(true);

            //ボタン機能関連（Interactive)
            start.interactable = true;
            //Continue.interactable = true;
            Credit.interactable = true;
            quit.interactable = true;
            option.interactable = true;
           
            //ボタンのイベントトリガー関連
            eventTrigger_start.enabled = true;
            eventTrigger_quit.enabled = true;
            eventTrigger_option.enabled = true;
            eventTrigger_Credit.enabled = true;
        }
    }
}

