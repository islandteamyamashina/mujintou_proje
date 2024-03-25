using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ContinueExploreButton : MonoBehaviour
{

    EventSceneControllerBase event_controller;
    void Start()
    {
        event_controller = GameObject.FindWithTag("GameController").GetComponent<EventSceneControllerBase>();
        GetComponent<Button>().onClick.RemoveAllListeners();
        GetComponent<Button>().onClick.AddListener(event_controller.RestartEvent);
    }

  
}
