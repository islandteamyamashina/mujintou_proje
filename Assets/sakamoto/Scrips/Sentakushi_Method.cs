
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;

public class Sentakushi_Method : Event_Text
{
    [SerializeField] Text _sentakusiTextObject1;
    [SerializeField] Text _sentakusiTextObject2;
    [SerializeField] Text _sentakusiTextObject3;

    //[SerializeField] TextMeshProUGUI _eventTextObject;
    [SerializeField] GameObject _sentakusi1;
    [SerializeField] GameObject _sentakusi2;
    [SerializeField] GameObject _sentakusi3;

    [SerializeField] string scene_Name;

    public Event_Ilast_Disply event_Ilast_Disply;
    public Event_BG_Disply event_BG_Disply;
    public Event_Text event_Text;
    public Event_Manage event_manage;

    int[] Result_tam;
    int Result_Num;
    bool GoToLoadScene;

    int Event_num;
    // Start is called before the first frame update

    private void Start()
    {
        Event_num = 0;
        Debug.Log(event_manage.start_event_num);
        Set_Sentakusi_Words(event_manage.eventDatas[event_manage.start_event_num].Sentakusi1, 
                            event_manage.eventDatas[event_manage.start_event_num].Sentakusi2, 
                            event_manage.eventDatas[event_manage.start_event_num].Cancel);
        _sentakusiSetActive(event_manage.start_event_num);
        GoToLoadScene = false;
    }
    private void Update()
    {
        if (GoToLoadScene)
        {
            if (Input.GetMouseButton(0))
            {
                Event_num++;
                event_Text.SetEventText();
                event_Ilast_Disply.SetEventIlast();
                event_BG_Disply.SetEventBG();
                Set_Sentakusi_Words(event_manage.eventDatas[event_manage.start_event_num].Sentakusi1,
                                    event_manage.eventDatas[event_manage.start_event_num].Sentakusi2,
                                    event_manage.eventDatas[event_manage.start_event_num].Cancel);

                _sentakusiSetActive(event_Manage.now_event_num);
                //_sentakusi1.SetActive(true);
                //_sentakusi2.SetActive(true);
                //_sentakusi3.SetActive(true);
                GoToLoadScene = false;
                if(Event_num == 3)
                {
                    SceneManager.LoadScene(scene_Name);
                }
                //PlayerInfo.Instance.Health
            }
        }
    }
    public void Push_Sentakusi1()
    {
        if (GoToLoadScene == false)
        {
            Text_Disply(event_manage.eventDatas[event_manage.now_event_num].Sentakusi1_Result1);
            getItem("Sentakusi1");
            //_sentakusi1.SetActive(false);
            _sentakusi2.SetActive(false);
            _sentakusi3.SetActive(false);
            GoToLoadScene = true;

            Debug.Log("変換前の体力は" + PlayerInfo.Instance.Health + "空腹度は" + PlayerInfo.Instance.Hunger + "水分は" + PlayerInfo.Instance.Thirst + "です");
            PlayerInfo.Instance.Health += event_manage.eventDatas[event_manage.now_event_num].Sentakusi1_health;
            PlayerInfo.Instance.Hunger += event_manage.eventDatas[event_manage.now_event_num].Sentakusi1_hunger;
            PlayerInfo.Instance.Thirst += event_manage.eventDatas[event_manage.now_event_num].Sentakusi1_warter;
            Debug.Log("変換後の体力は" + PlayerInfo.Instance.Health + "空腹度は" + PlayerInfo.Instance.Hunger + "水分は" + PlayerInfo.Instance.Thirst + "です");


            for (int i = 0; i < event_manage.eventDatas.Length; i++)
            {
                if (event_manage.eventDatas[event_manage.now_event_num].Sentakusi1_Next_Ivent_ID == event_manage.eventDatas[i].Event_ID)
                {
                    Debug.Log(event_manage.eventDatas[i].Event_ID);
                    event_manage.now_event_num = i;
                    Debug.Log(event_manage.eventDatas[event_manage.now_event_num].Event_ID);
                    break;
                }
            }

            GoToEnding();
        }
    }

    public void Push_Sentakusi2()
    {
        if (GoToLoadScene == false)
        {
            Text_Disply(event_manage.eventDatas[event_manage.now_event_num].Sentakusi2_Result1);
            getItem("Sentakusi2");
            _sentakusi1.SetActive(false);
            _sentakusi3.SetActive(false);
            GoToLoadScene = true;

            Debug.Log("変換前の体力は" + PlayerInfo.Instance.Health + "空腹度は" + PlayerInfo.Instance.Hunger + "水分は" + PlayerInfo.Instance.Thirst + "です");
            PlayerInfo.Instance.Health -= event_manage.eventDatas[event_manage.now_event_num].Sentakusi2_health;
            PlayerInfo.Instance.Hunger -= event_manage.eventDatas[event_manage.now_event_num].Sentakusi2_hunger;
            PlayerInfo.Instance.Thirst -= event_manage.eventDatas[event_manage.now_event_num].Sentakusi2_warter;
            Debug.Log("変換後の体力は" + PlayerInfo.Instance.Health + "空腹度は" + PlayerInfo.Instance.Hunger + "水分は" + PlayerInfo.Instance.Thirst + "です");

            for (int i = 0; i < event_manage.eventDatas.Length; i++)
            {
                if (event_manage.eventDatas[event_manage.now_event_num].Sentakusi2_Next_Ivent_ID == event_manage.eventDatas[i].Event_ID)
                {
                    Debug.Log(event_manage.eventDatas[i].Event_ID);
                    event_manage.now_event_num = i;
                    Debug.Log(event_manage.eventDatas[event_manage.now_event_num].Event_ID);
                    break;
                }
            }

            GoToEnding();
        }
    }

    public void Push_Sentakusi3()
    {
        if (GoToLoadScene == false)
        {
            Text_Disply(event_manage.eventDatas[event_manage.now_event_num].Cancel_Result);
            _sentakusi1.SetActive(false);
            _sentakusi2.SetActive(false);
            GoToLoadScene = true;

            for (int i = 0; i < event_manage.eventDatas.Length; i++)
            {
                if (event_manage.eventDatas[event_manage.now_event_num].Cancel_Next_Ivent_ID == event_manage.eventDatas[i].Event_ID)
                {
                    Debug.Log(event_manage.eventDatas[i].Event_ID);
                    event_manage.now_event_num = i;
                    Debug.Log(event_manage.eventDatas[event_manage.now_event_num].Event_ID);
                    break;
                }
            }
        }
    }

    public void Set_Sentakusi_Words(string Words1, string Words2, string Words3)
    {
        _sentakusiTextObject1.text = Words1;
        _sentakusiTextObject2.text = Words2;
        _sentakusiTextObject3.text = Words3;
    }

    void _sentakusiSetActive(int event_num)
    {
        if (event_manage.eventDatas[event_num].Sentakusi1_Zyouken != 0)
        {
            for (int i = 0; i < event_manage.newItem.Length; i++)
            {
                if (event_manage.eventDatas[event_num].Sentakusi1_Zyouken == event_manage.newItem[i].ScriptalItem.itemID)
                {
                    Debug.Log("イベントIDは" + event_manage.newItem[i].ScriptalItem.itemID);
                    Debug.Log("条件の個数は" + event_manage.eventDatas[event_num].Sentakusi1_Zyouken_num);
                    Debug.Log("持っている個数は" + event_manage.newItem[i].CurrentStackCount);

                    if (event_manage.eventDatas[event_num].Sentakusi1_Zyouken_num <= event_manage.newItem[i].CurrentStackCount)
                    {

                        _sentakusi1.SetActive(true);
                        break;
                    }
                    else
                    {
                        _sentakusi1.SetActive(false);
                        break;
                    }
                }
            }
        }
        else
        {
            _sentakusi1.SetActive(true);
        }
        if (event_manage.eventDatas[event_num].Sentakusi2_Zyouken != 0)
        {
            for (int i = 0; i < event_manage.newItem.Length; i++)
            {
                if (event_manage.eventDatas[event_num].Sentakusi2_Zyouken == event_manage.newItem[i].ScriptalItem.itemID)
                {
                    if (event_manage.eventDatas[event_num].Sentakusi2_Zyouken_num <= event_manage.newItem[i].CurrentStackCount)
                    {
                        _sentakusi2.SetActive(true);
                    }
                    else
                    {
                        _sentakusi2.SetActive(false);
                    }
                }
            }
        }
        else
        {
            _sentakusi2.SetActive(true);
        }
        _sentakusi3.SetActive(true);
    }
    void getItem(string Sentakusi)
    {
        if (Sentakusi == "Sentakusi1")
        {
            if (event_manage.eventDatas[event_manage.now_event_num].Sentakusi1_Reward1 != 0)
            {
                for (int i = 0; i < event_manage.newItem.Length; i++)
                {
                    if (event_manage.eventDatas[event_manage.now_event_num].Sentakusi1_Reward1 == event_manage.newItem[i].ScriptalItem.itemID)
                    {
                        Debug.Log(event_manage.newItem[i].ScriptalItem.name + "をゲットしました");
                        for (int j = 0; j < event_manage.eventDatas[event_manage.now_event_num].Sentakusi1_Reward1_num; j++)
                        {
                            Debug.Log("get");
                        }
                    }
                }
            }
            if (event_manage.eventDatas[event_manage.now_event_num].Sentakusi1_Reward2 != 0)
            {
                for (int i = 0; i < event_manage.newItem.Length; i++)
                {
                    if (event_manage.eventDatas[event_manage.now_event_num].Sentakusi1_Reward2 == event_manage.newItem[i].ScriptalItem.itemID)
                    {
                        Debug.Log(event_manage.newItem[i].ScriptalItem.name + "をゲットしました");
                        for (int j = 0; j < event_manage.eventDatas[event_manage.now_event_num].Sentakusi1_Reward2_num; j++)
                        {
                            Debug.Log("get");
                        }
                    }
                }
            }
            if (event_manage.eventDatas[event_manage.now_event_num].Sentakusi1_Reward3 != 0)
            {
                for (int i = 0; i < event_manage.newItem.Length; i++)
                {
                    if (event_manage.eventDatas[event_manage.now_event_num].Sentakusi1_Reward3 == event_manage.newItem[i].ScriptalItem.itemID)
                    {
                        Debug.Log(event_manage.newItem[i].ScriptalItem.name + "をゲットしました");
                        for (int j = 0; j < event_manage.eventDatas[event_manage.now_event_num].Sentakusi1_Reward3_num; j++)
                        {
                            Debug.Log("get");
                        }
                    }
                }
            }
            
        }
        if (Sentakusi == "Sentakusi2")
        {
            if (event_manage.eventDatas[event_manage.now_event_num].Sentakusi2_Reward != 0)
            {
                for (int i = 0; i < event_manage.newItem.Length; i++)
                {
                    if (event_manage.eventDatas[event_manage.now_event_num].Sentakusi2_Reward == event_manage.newItem[i].ScriptalItem.itemID)
                    {
                        Debug.Log(event_manage.newItem[i].ScriptalItem.name + "をゲットしました");
                        for (int j = 0; j < event_manage.eventDatas[event_manage.now_event_num].Sentakusi2_Reward_num; j++)
                        {
                            Debug.Log("get");
                        }
                    }
                }
            }
            if (event_manage.eventDatas[event_manage.now_event_num].Sentakusi2_Reward2 != 0)
            {
                for (int i = 0; i < event_manage.newItem.Length; i++)
                {
                    if (event_manage.eventDatas[event_manage.now_event_num].Sentakusi2_Reward2 == event_manage.newItem[i].ScriptalItem.itemID)
                    {
                        Debug.Log(event_manage.newItem[i].ScriptalItem.name + "をゲットしました");
                        for (int j = 0; j < event_manage.eventDatas[event_manage.now_event_num].Sentakusi2_Reward2_num; j++)
                        {
                            Debug.Log("get");
                        }
                    }
                }
            }
            if (event_manage.eventDatas[event_manage.now_event_num].Sentakusi2_Reward3 != 0)
            {
                for (int i = 0; i < event_manage.newItem.Length; i++)
                {
                    if (event_manage.eventDatas[event_manage.now_event_num].Sentakusi2_Reward3 == event_manage.newItem[i].ScriptalItem.itemID)
                    {
                        Debug.Log(event_manage.newItem[i].ScriptalItem.name + "をゲットしました");
                        for (int j = 0; j < event_manage.eventDatas[event_manage.now_event_num].Sentakusi2_Reward3_num; j++)
                        {
                            Debug.Log("get");
                        }
                    }
                }
            }
        }

    }

    void GoToEnding()
    {
        //バッドエンド
        if(PlayerInfo.Instance.Health == 0)
        {
            Debug.Log("バッドエンド");
            SceneManager.LoadScene("BadEnd");
        }    
        //トゥルーエンド
        if(event_manage.now_event_num / 1000 == 0)
        {
            Debug.Log("トゥルーエンド");
            SceneManager.LoadScene("TrueEnd");
        }

    }
}
