using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class event_Text : TextControl
{
    [SerializeField] EventData eventData;
    [SerializeField] Text titleObject;
    public Event_Manage event_Manage;


    
    // Start is called before the first frame update
   protected override void Start()
    {
        //SetEventText();
        Debug.Log("�e�L�X�g�R���g���[�����ʂ���");
        base.Start();
        Debug.Log("�e�L�X�g�R���g���[�����ʂ���");
        eventData = event_Manage.eventDatas[event_Manage.now_event_num];
        Debug.Log(eventData.Main_Text);
        strs.Add(eventData.Main_Text);
        strs.Add("aaa");
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    //�e�L�X�g�\��
    void Title_Disply(string text)
    {
        string sentence = text;
        titleObject.text = sentence;
    }

    public void SetEventText()
    {
        //Debug.Log("eventData��" + event_Manage.start_event_num + "�ł�");
        eventData = event_Manage.eventDatas[event_Manage.now_event_num];
        //Text_Disply(eventData.Main_Text);
        //Debug.Log("eventData��" + event_Manage.start_event_num + "�ł�");
        //Debug.Log(eventData.Main_Text);
        Title_Disply(eventData.Event_Title);
    }

}
