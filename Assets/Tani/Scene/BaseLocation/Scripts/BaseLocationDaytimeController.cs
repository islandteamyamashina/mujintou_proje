using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class BaseLocationDaytimeController : MonoBehaviour
{
    [SerializeField]
    List<PanelBase> panels;
    //[SerializeField]
    //SceneObject scene;
    [SerializeField]
    SceneObject next_base_location;

    // Start is called before the first frame update
    void Start()
    {
        PlayerInfo.Instance.SetUIVisibility(true);
        var fade =  ((Fading)GameObject.FindAnyObjectByType(typeof(Fading)));
        fade.Fade(Fading.type.FadeIn);
        var areaNameShow = (AreaNameText)GameObject.FindAnyObjectByType(typeof(AreaNameText));
        IEnumerator coroutine = areaNameShow.ShowAreaText();
        fade.OnFadeEnd.AddListener(() => { StartCoroutine(coroutine); });

     
    }


    void Update()
    {
     
    }
    private void Awake()
    {
        //((LockSystem)GameObject.FindAnyObjectByType(typeof(LockSystem))).gameObject.transform.parent.parent.gameObject.SetActive(true);
        //((LockSystem)GameObject.FindAnyObjectByType(typeof(LockSystem))).gameObject.transform.parent.parent.gameObject.SetActive(false);

    }

    public void ActivatePanelSingle(int index)
    {
        if (index >= panels.Count) return;
        DeactivateAllPanels();
        panels[index].SetEnabled(true);
    }

    public void ActivatePanelAdditive(int index)
    {
        if (index >= panels.Count) return;
        panels[index].SetEnabled(true);
    }

    public void DeactivatePanel(int index)
    {
        if (index >= panels.Count) return;
        panels[index].SetEnabled(false);
    }

    public void DeactivateAllPanels()
    {
        for (int i = 0; i < panels.Count; i++)
        {
            panels[i].SetEnabled(false);
        }
    }

    public void SwitchActive(int index)
    {
        if (index >= panels.Count) return;
        panels[index].SwitchEnabaled();
    }

    //public void NextScene()
    //{
    //    var fade = ((Fading)GameObject.FindAnyObjectByType(typeof(Fading)));
    //    fade.Fade(Fading.type.FadeOut);
    //    fade.OnFadeEnd.AddListener(() => { SceneManager.LoadScene(scene); });
        
    //}

    public void ChangeBaseLocation()
    {
        //var fade = ((Fading)GameObject.FindAnyObjectByType(typeof(Fading)));
        //fade.Fade(Fading.type.FadeOut);
        //fade.OnFadeEnd.AddListener(() => 
        //{
        //    PlayerInfo.Instance.SetWeatherIcon();
        //    SceneManager.LoadScene(next_base_location); 
        //});
        SceneManager.LoadScene(next_base_location);
    }
}
   
