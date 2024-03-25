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
        eventPanel.SetRandomEvent();
    }

    public void OnEndEvent()
    {
       
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
