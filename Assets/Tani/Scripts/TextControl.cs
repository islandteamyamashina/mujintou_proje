using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TextControl : MonoBehaviour
{
    [SerializeField, Header("テキストを表示するオブジェクト")]
    GameObject TextObject;
    Text text;
    

    [SerializeField,Header("文字の増やす間隔")]
    float interval = 0.15f;

    [SerializeField]List<string> strs;
    int str_Count = 0;
    int str_page = 0;
    float time_sum = 0;
    void Start()
    {
        text = GetComponent<Text>();
        EventTrigger eventTrigger = GetComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerClick;
        entry.callback.AddListener((data) => { OnClick(); });
        eventTrigger.triggers.Add(entry);
    }

    // Update is called once per frame
    void Update()
    {
        time_sum += Time.deltaTime;
        if(time_sum > interval)
        {
            time_sum = 0;
            str_Count++;
        }
        text.text = strs[str_page][..str_Count];


    }
    void OnClick()
    {
        
        str_page++;
        if(str_page != strs.Count)
        {
            str_Count = 0;
            time_sum = 0;
        }
        else
        {
            str_page = strs.Count - 1;
        }
        
    }
}
