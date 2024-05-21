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
    [SerializeField]
    SceneObject next_base_location;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        if (PlayerInfo.Instance.Day.isDayTime)
        {
            var areaNameShow = (AreaNameText)GameObject.FindAnyObjectByType(typeof(AreaNameText));
            IEnumerator coroutine = areaNameShow.ShowAreaText();
            StartCoroutine(coroutine);
        }
        else
        {
            var fade = ((Fading)GameObject.FindAnyObjectByType(typeof(Fading)));
            fade.Fade(Fading.type.FadeIn);
        }



        for (int i = 0; i < panels.Count; i++)
        {
            ActivatePanelAdditive(i);
        }
        yield return null;
        DeactivateAllPanels();
        PlayerInfo.Instance.Inventry.SetVisible(false);
    }


    void Update()
    {
        PlayerInfo.Instance.CheckPlayerDeath();
    }
    private void Awake()
    {
        

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

        SceneManager.LoadScene(next_base_location);
    }
}
   
