using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EventSceneControllerBase : MonoBehaviour
{
    [SerializeField]
    EventPanelBase eventPanel;
    [SerializeField]
    SceneObject sceneToGetBack;
    [SerializeField]
    Fading fading;
    [SerializeField]
    GameObject imageInMoveing;

    private void Awake()
    {
        
    }
    void Start()
    {
        eventPanel.SetRandomEvent();
    }


    public void RestartEvent()
    {
        //フェード終了時に呼ばれる
        fading.OnFadeEnd.AddListener(() =>
        {
            imageInMoveing.SetActive(true);
            StartCoroutine("HideMovingImage");
            
        });
        fading.Fade(Fading.type.FadeOut);

        
    }
    IEnumerator HideMovingImage()
    {
        yield return new WaitForSeconds(3);
        imageInMoveing.SetActive(false);
        fading.Fade(Fading.type.FadeIn);
        eventPanel.SetRandomEvent();
    }

    public void BackHome()
    {
        PlayerInfo.Instance.DoAction();
        SceneManager.LoadScene(sceneToGetBack);
    }

    

    

}
