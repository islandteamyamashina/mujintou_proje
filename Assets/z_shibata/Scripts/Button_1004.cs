using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Button_1004 : MonoBehaviour
{
    private void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(() =>
        { ((EventSceneControllerBase)GameObject.FindAnyObjectByType(typeof(EventSceneControllerBase))).BackHome();});
    }
}
