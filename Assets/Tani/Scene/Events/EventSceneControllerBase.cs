using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventSceneControllerBase : MonoBehaviour
{
    [SerializeField]
    EventPanelBase eventPanel;
    [SerializeField]
    SceneObject sceneToGetBack;
    [SerializeField]
    EventDatas datas;
    private void Awake()
    {
        
    }
    void Start()
    {
        eventPanel.SetRandomEvent();
    }


    public void RestartEvent()
    {
        print("restart");
        eventPanel.SetRandomEvent();
    }

    public void BackHome()
    {
        print("back home");
        SceneManager.LoadScene(sceneToGetBack);
    }
}
