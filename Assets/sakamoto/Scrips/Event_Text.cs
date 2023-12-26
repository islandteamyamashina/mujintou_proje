using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Event_Text : Text_Method
{
    [SerializeField] public EventData eventData;
    [SerializeField] Text titleObject;

    // Start is called before the first frame update
    void Start()
    {
        Text_Disply(eventData.Main_Text);
        Title_Disply(eventData.Event_Title);
    }

    // Update is called once per frame
    void Update()
    {

    }

    //テキスト表示
    void Title_Disply(string text)
    {
        string sentence = text;
        titleObject.text = sentence;
    }

}
