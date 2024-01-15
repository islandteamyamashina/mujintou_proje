using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_Ilast_Disply : Image_Method
{
   
    public Event_Manage event_Manage;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
       // eventData = event_Manage.eventDatas[event_Manage.now_event_num];
        //”wŒi‚ð•`ŽÊ
        PutImage(event_Manage.eventDatas[event_Manage.now_event_num].Event_Ilast);
    }
    public void DisplayIlast()
    {
    }

}
