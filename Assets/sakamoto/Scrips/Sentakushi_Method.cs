
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

    public Event_Ilast_Disply event_Ilast_Disply;
    public Event_BG_Disply event_BG_Disply;
    public Event_Text event_Text;
    public Event_Manage event_manage;

    int[] Result_tam;
    int Result_Num;
    bool GoToLoadScene;
    // Start is called before the first frame update

    private void Start()
    {
        Set_Sentakusi_Words(eventData.Sentakusi1, eventData.Sentakusi2, eventData.Cancel);
        GoToLoadScene = false;
    }
    private void Update()
    {
        if (GoToLoadScene)
        {
            if (Input.GetMouseButton(0))
            {        
                event_Text.SetEventText();
                event_Ilast_Disply.SetEventIlast();
                event_BG_Disply.SetEventBG();

                _sentakusi1.SetActive(true);
                _sentakusi2.SetActive(true);
                _sentakusi3.SetActive(true);
                GoToLoadScene = false;
            }
        }
    }
    public void Push_Sentakusi1()
    {
        if (GoToLoadScene == false)
        {
            Text_Disply(eventData.Sentakusi1_Result1);

            //_sentakusi1.SetActive(false);
            _sentakusi2.SetActive(false);
            _sentakusi3.SetActive(false);
            GoToLoadScene = true;

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
        }
    }

    public void Push_Sentakusi2()
    {
        if (GoToLoadScene == false)
        {
            Text_Disply(eventData.Sentakusi2_Result1);
            _sentakusi1.SetActive(false);
            _sentakusi3.SetActive(false);
            GoToLoadScene = true;

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
        }
    }

    public void Push_Sentakusi3()
    {
        if (GoToLoadScene == false)
        {
            Text_Disply(eventData.Cancel_Result);
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

    
}
