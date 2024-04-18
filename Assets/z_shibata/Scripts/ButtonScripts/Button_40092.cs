using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Button_40092 : MonoBehaviour
{
    EventSceneControllerBase event_controller;
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(event_controller.GoVolcano);
    }
}
