using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Event_Ilast_Disply : Image_Method
{
    [SerializeField] EventData eventData;
    // Start is called before the first frame update
    void Start()
    {
        //イベントイラストを描写
        PutImage(eventData.Event_Ilast);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
