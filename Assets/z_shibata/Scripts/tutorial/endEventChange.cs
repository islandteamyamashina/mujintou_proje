using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class endEventChange : MonoBehaviour
{
    [SerializeField] EventDatas newEndEventData;
    void Start()
    {
        GameData.FindAnyObjectByType(typeof(EventPanelBase)).GetComponent<EventPanelBase>().endEventData = newEndEventData;
    }
}
