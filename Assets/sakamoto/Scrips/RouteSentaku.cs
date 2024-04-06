using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class RouteSentaku : Event_Text
{
    [SerializeField] Button Route1;
    [SerializeField] Button Route2;
    [SerializeField] GameObject Route1_text;
    [SerializeField] GameObject Route2_text;
    [SerializeField] GameObject BG_cover;
    [SerializeField] GameObject Loadimage;

 
    Color color;
    Color normalColor = new Color(1.0f, 1.0f, 1.0f, 0.0f);
    Color highlightColor = new Color(1.0f, 1.0f, 1.0f, 1.0f);

    //[SerializeField, Header("inventoryマネージャー取得してね")] InventoryManagerVer cpInventoryManager;
    //[SerializeField] GetItemManager GetItemManager;

    public Event_BG_Disply event_BG_Disply;
    public Event_Text event_Text;
    public Event_Manage event_manage;

    int next_num_tnp;//次のイベントナンバー

    // Start is called before the first frame update

    //ChatGPT作
    void Start()
    {
        Route1.image.color = Route2.image.color = normalColor;
        Route1_text.SetActive(false);
        Route2_text.SetActive(false);

        if (PlayerInfo.Instance.Inventry.GetItemAmount((Items.Item_ID)event_manage.eventDatas[event_manage.now_event_num].Sentakusi1_Zyouken) >= event_manage.eventDatas[event_manage.now_event_num].Sentakusi1_Zyouken_num || event_manage.eventDatas[event_manage.now_event_num].Sentakusi1_Zyouken_num == 0)
        {
            // Route1にマウスオーバー時のイベントを追加
            EventTrigger trigger1 = Route1.gameObject.AddComponent<EventTrigger>();
            trigger1.triggers.Add(new EventTrigger.Entry { eventID = EventTriggerType.PointerEnter });
            trigger1.triggers[0].callback.AddListener((data) => { OnRouteEnter(Route1); });
            trigger1.triggers.Add(new EventTrigger.Entry { eventID = EventTriggerType.PointerExit });
            trigger1.triggers[1].callback.AddListener((data) => { OnRouteExit(Route1); });
        }
        else
        {
            Route1.interactable = false;
        }

        if (PlayerInfo.Instance.Inventry.GetItemAmount((Items.Item_ID)event_manage.eventDatas[event_manage.now_event_num].Sentakusi2_Zyouken) >= event_manage.eventDatas[event_manage.now_event_num].Sentakusi2_Zyouken_num || event_manage.eventDatas[event_manage.now_event_num].Sentakusi1_Zyouken_num == 0)
        {
            // Route2にマウスオーバー時のイベントを追加
            EventTrigger trigger2 = Route2.gameObject.AddComponent<EventTrigger>();
            trigger2.triggers.Add(new EventTrigger.Entry { eventID = EventTriggerType.PointerEnter });
            trigger2.triggers[0].callback.AddListener((data) => { OnRouteEnter(Route2); });
            trigger2.triggers.Add(new EventTrigger.Entry { eventID = EventTriggerType.PointerExit });
            trigger2.triggers[1].callback.AddListener((data) => { OnRouteExit(Route2); });
        }
        else
        {
            Route2.interactable = false;
        }
    }

    void OnRouteEnter(Button button)
    {
        button.image.color = highlightColor;
        if(button == Route1)
        {
            Route1_text.SetActive(true);
        }
        if(button == Route2) 
        { 
            Route2_text.SetActive(true);
        }
    }

    void OnRouteExit(Button button)
    {
        button.image.color = normalColor;
        if (button == Route1)
        {
            Route1_text.SetActive(false);
        }
        if (button == Route2)
        {
            Route2_text.SetActive(false);
        }
    }
    public void ChoiseRoute1()
    {
        textControl.ResetTextData();
        StartCoroutine(appearBGcover());
        addMainSentence(event_manage.eventDatas[event_manage.now_event_num].Sentakusi1_Result1);
        changCondirion(event_manage.eventDatas[event_manage.now_event_num].Sentakusi1_health, event_manage.eventDatas[event_manage.now_event_num].Sentakusi1_hunger, event_manage.eventDatas[event_manage.now_event_num].Sentakusi1_warter);
        getItems(event_manage.eventDatas[event_manage.now_event_num].Sentakusi1_Reward1, event_manage.eventDatas[event_manage.now_event_num].Sentakusi1_Reward1_num);
        next_num_tnp = event_manage.eventDatas[event_manage.now_event_num].Sentakusi1_Next_Ivent_ID;
        ID_change_Event_num();
        //ボタンの機能提出
        Route1.interactable = false; 
        Route2.interactable = false;
        textControl.ClickEventAfterTextsEnd.AddListener(Nextevent);
    }
    public void ChoiseRoute2()
    {
        textControl.ResetTextData();
        StartCoroutine(appearBGcover());
        addMainSentence(event_manage.eventDatas[event_manage.now_event_num].Sentakusi2_Result1);
        changCondirion(event_manage.eventDatas[event_manage.now_event_num].Sentakusi2_health, event_manage.eventDatas[event_manage.now_event_num].Sentakusi2_hunger, event_manage.eventDatas[event_manage.now_event_num].Sentakusi2_warter);
        getItems(event_manage.eventDatas[event_manage.now_event_num].Sentakusi2_Reward1, event_manage.eventDatas[event_manage.now_event_num].Sentakusi2_Reward1_num);
        next_num_tnp = event_manage.eventDatas[event_manage.now_event_num].Sentakusi2_Next_Ivent_ID;
        ID_change_Event_num();
        //ボタンの機能提出
        Route1.interactable = false; 
        Route2.interactable = false;
        textControl.ClickEventAfterTextsEnd.AddListener(Nextevent);
    }

    IEnumerator appearBGcover()
    {
        while (true)
        {
            Color BG_cover_color;
             BG_cover_color = BG_cover.GetComponent<Image>().color;
            BG_cover_color.a += 0.05f;
            BG_cover.GetComponent<Image>().color = BG_cover_color;
            if (BG_cover.GetComponent<Image>().color.a < 0.7f)
            {
                break;
            }
            yield return null;
        }
    }

    //　本文、体力変化、アイテムゲットの順番

    //本文書き換え
    void addMainSentence(string scentence)
    {
        textControl.AddTextData(scentence);
    }

    //コンディション書き換え
    void changCondirion(int helth, int hunger, int thirst)
    {
        int beforeHelth;
        int beforeHunger;
        int beforeThirst;
        //変化前の値をストック
        beforeHelth = PlayerInfo.Instance.Health;
        beforeHunger = PlayerInfo.Instance.Hunger;
        beforeThirst = PlayerInfo.Instance.Thirst;

        //体力変化
        PlayerInfo.Instance.Health += helth;
        PlayerInfo.Instance.Hunger += hunger;
        PlayerInfo.Instance.Thirst += thirst;

        textControl.AddTextData($"体力 　{beforeHelth} => {PlayerInfo.Instance.Health}\n" +
                                $"空腹度 {beforeHunger} => {PlayerInfo.Instance.Hunger}\n" +
                                $"水分 　{beforeThirst} => {PlayerInfo.Instance.Thirst}");
    }

    //アイテムゲット
    void getItems(int Item_ID, int get_num)
    {
        string Item_name;
        PlayerInfo.Instance.Inventry.GetItem((Items.Item_ID)Item_ID, get_num);
        Item_name = PlayerInfo.Instance.Inventry.GetItemName((Items.Item_ID)Item_ID);
        textControl.AddTextData($"{Item_name}を{get_num}つ手に入れました。");
    }

    //次のイベントに飛ばす
    void Nextevent()
    {
        nextEvent(next_num_tnp);
    }

    void nextEvent(int event_num)
    {
        Loadimage.SetActive(true);
        event_manage.now_event_num = event_num;
        //textControl.ResetTextData();
        textControl.ClickEventAfterTextsEnd.RemoveAllListeners();
        Invoke("ventStart", 2);
    }

    void ventStart()
    {
        Loadimage.SetActive(false);
        //textControl.AddTextData(event_manage.eventDatas[event_manage.now_event_num].Main_Text);
        SetEventText();
        //ボタンの機能再開
        Route1.interactable = true;
        Route2.interactable = true;
    }

    //イベントIDとリストのナンバーの紐づけ
    void ID_change_Event_num()
    {
        for (int i = 0; i < event_manage.eventDatas.Length; i++)
        {
            if (next_num_tnp == event_manage.eventDatas[i].Event_ID)
            {
                Debug.Log(event_manage.eventDatas[i].Event_ID);
                next_num_tnp = i;
                Debug.Log(event_manage.eventDatas[event_manage.now_event_num].Event_ID);
                break;
            }
        }

    }
}
