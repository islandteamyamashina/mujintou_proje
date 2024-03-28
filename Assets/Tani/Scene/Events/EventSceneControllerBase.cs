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

    private void Awake()
    {
        
    }
    void Start()
    {
        eventPanel.SetRandomEvent();
    }


    public void RestartEvent()
    {
        eventPanel.SetRandomEvent();
    }

    public void BackHome()
    {
        PlayerInfo.Instance.DoAction();
        SceneManager.LoadScene(sceneToGetBack);
    }
}
