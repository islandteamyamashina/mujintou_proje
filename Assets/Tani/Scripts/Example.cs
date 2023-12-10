using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Example : MonoBehaviour
{
   [SerializeField] 
    SceneObject scene;
    Text text;
    

    
    private void Start()
    {
        
        text = gameObject.GetComponent<Text>();
        
       //Trigger入手
        EventTrigger trigger = GetComponent<EventTrigger>();
        //関数を設定したいイベント
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerClick;
        EventTrigger.Entry entry1 = new EventTrigger.Entry();
        entry1.eventID = EventTriggerType.PointerEnter;
        EventTrigger.Entry entry2 = new EventTrigger.Entry();
        entry2.eventID = EventTriggerType.PointerExit;

        //イベントに関数を登録
        entry.callback.AddListener((data) => { ChangeScene((SceneObject)scene); });
        entry1.callback.AddListener((data) => { OnHovered(); });
        entry2.callback.AddListener((data) => { OnUnHovered(); });

        //トリガーにイベントを追加
        trigger.triggers.Add(entry);
        trigger.triggers.Add(entry1);
        trigger.triggers.Add(entry2);
        
        
    }

 

    public void ChangeScene(SceneObject scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void OnHovered()
    {
        text.fontSize = 87;
        Debug.Log(StaticExample.staticInt);
        StaticExample.staticInt++;
    }

    public void OnUnHovered()
    {
        text.fontSize = 70;
    }
}

