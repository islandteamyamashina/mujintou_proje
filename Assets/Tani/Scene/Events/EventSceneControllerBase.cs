using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSceneControllerBase : MonoBehaviour
{
    [SerializeField]
    EventPanelBase eventPanel;
    [SerializeField]


    private void Awake()
    {
        
    }
    void Start()
    {
        eventPanel.StartEvent(1);
    }

    public void OnEndEvent()
    {
        eventPanel.StartEvent(1);
    }
    public void RestartEvent()
    {
        print("restart");
    }

    public void BackHome()
    {
        print("back home");
    }
}
