using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_BG_Disply : Image_Method
{
    [SerializeField] EventData eventData;
    // Start is called before the first frame update
    void Start()
    {
        //”wŒi‚ð•`ŽÊ
        PutImage(eventData.Event_BG);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
