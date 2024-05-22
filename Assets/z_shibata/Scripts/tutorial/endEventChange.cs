using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class endEventChange : MonoBehaviour
{
    [SerializeField] EventDatas newEndEventData;
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(SetEndEventData);
    }

    void SetEndEventData()
    {
        var eventPanelBase = GameData.FindAnyObjectByType(typeof(EventPanelBase)) as EventPanelBase;
        if (eventPanelBase != null)
        {
            eventPanelBase.GetType().GetField("endEventData", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).SetValue(eventPanelBase, newEndEventData);
        }
        else
        {
            Debug.LogError("EventPanelBase not found");
        }
    }
}
