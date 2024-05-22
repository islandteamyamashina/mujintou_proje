using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class goBase_Tutorial : MonoBehaviour
{
    EventSceneControllerBase event_controller;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(() =>
        { ((EventSceneControllerBase)GameObject.FindAnyObjectByType(typeof(EventSceneControllerBase))).GoTutorialBase(); });
    }

}
