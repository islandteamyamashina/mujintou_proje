using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Event_Text : Text_Method
{
     public EventData eventData;
    [SerializeField] Text titleObject;
    public Event_Manage event_Manage;

    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("eventData��" + event_Manage.start_event_num + "�ł�");
        eventData = event_Manage.eventDatas[event_Manage.now_event_num];
        Text_Disply(event_Manage.eventDatas[event_Manage.now_event_num].Main_Text);
        Debug.Log("eventData��" + event_Manage.start_event_num + "�ł�");
        Debug.Log(event_Manage.eventDatas[event_Manage.now_event_num].Main_Text);
        Title_Disply(event_Manage.eventDatas[event_Manage.now_event_num].Event_Title);
    }

    // Update is called once per frame
    void Update()
    {
    }

    //�e�L�X�g�\��
    void Title_Disply(string text)
    {
        string sentence = text;
        titleObject.text = sentence;
    }

}
