using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_BG_Disply : Image_Method 
{
     EventData eventData;
    public Event_Manage event_Manage;

    // Start is called before the first frame update
    void Start()
    {       
    }

    // Update is called once per frame
    void Update()
    {
        eventData = event_Manage.eventDatas[event_Manage.now_event_num];
        //�w�i��`��
        PutImage(eventData.Event_BG);
    }
    public void DisplayBG()
    {
    }

}
