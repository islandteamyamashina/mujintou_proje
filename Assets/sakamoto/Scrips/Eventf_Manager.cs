using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_Manage : MonoBehaviour
{
    [SerializeField] public EventData[] eventDatas;
    [SerializeField] public NewItem[] newItem;
    public int start_event_num;
    public int now_event_num;
    [SerializeField] int start_area;
    // Start is called before the first frame update
    void Awake()
    {
        if (start_area == 0)
        {
            start_event_num = Random.Range(-1, 2) + 1;
            //Debug.Log("start_num‚Í" + start_event_num + "‚Å‚·");
            if (start_event_num > 2)
            {
                start_event_num = 2;
            }
        }
        if (start_area == 1)
        {
            start_event_num = Random.Range(13, 16) + 1;
            //Debug.Log("start_num‚Í" + start_event_num + "‚Å‚·");
            if (start_event_num > 16)
            {
                start_event_num = 16;
            }
        }
        now_event_num = start_event_num;
        now_event_num = 18;
        Debug.Log(eventDatas[start_event_num].Main_Text);
    }

    // Update is called once per frame
    void Update()
    {

    }


}
