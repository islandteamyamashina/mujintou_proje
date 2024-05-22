using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;


public class checkText: MonoBehaviour
{
    //inspector field
    [SerializeField]
    List<EventDatas> EventList;
    [SerializeField] TextControl textControl;


    void Start()
    {
        for (int i = 0; i < EventList.Count; i++)
        {
            textControl.AddTextData(EventList[0].main_text);
            for (int j = 0; j < EventList[i].results.Count; j++)
            {
                textControl.AddTextData(EventList[i].results[j].choise_text);
                textControl.AddTextData(EventList[i].results[j].result_text);
            }
        }
    }


}
