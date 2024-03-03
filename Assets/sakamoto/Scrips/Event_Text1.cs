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
        Debug.Log("テキストコントローラが通った");
        base.Start();
        Debug.Log("テキストコントローラが通った");
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

    //テキスト表示
    void Title_Disply(string text)
    {
        string sentence = text;
        titleObject.text = sentence;
    }

    public void SetEventText()
    {
        //Debug.Log("eventDataは" + event_Manage.start_event_num + "です");
        eventData = event_Manage.eventDatas[event_Manage.now_event_num];
        //Text_Disply(eventData.Main_Text);
        //Debug.Log("eventDataは" + event_Manage.start_event_num + "です");
        //Debug.Log(eventData.Main_Text);
        Title_Disply(eventData.Event_Title);
    }

}
