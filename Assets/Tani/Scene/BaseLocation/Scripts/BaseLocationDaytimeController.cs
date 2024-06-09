using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BaseLocationDaytimeController : MonoBehaviour
{
    [SerializeField]
    List<PanelBase> panels;
    [SerializeField]
    SceneObject next_scene;
    [SerializeField]
    int pattern = 0;
    [SerializeField]
    GameObject BL_Tu_1_SceneControllerPrefab = null;
    [SerializeField]
    GameObject BL_Tu_2_SceneControllerPrefab = null;
    [SerializeField]
    GameObject BL_Tu_3_SceneControllerPrefab = null;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        PlayerInfo.Instance.SetInventryLock(false);
        switch (pattern)
        {

            case 0:
                GameData.CanReturnTitle = true;
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
                break;
            case 1:
                {
                    //tutorial ˆê‰ñ–Ú
                    var fade = ((Fading)GameObject.FindAnyObjectByType(typeof(Fading)));
                    fade.Fade(Fading.type.FadeIn);
                    Instantiate(BL_Tu_1_SceneControllerPrefab);
                    break;
                }
            case 2:
                {
                    PlayerInfo.Instance.DoAction();
                    var fade = ((Fading)GameObject.FindAnyObjectByType(typeof(Fading)));
                    fade.Fade(Fading.type.FadeIn);
                    Instantiate(BL_Tu_2_SceneControllerPrefab);
                    break;
                }
            case 3:
                {
                    var fade = ((Fading)GameObject.FindAnyObjectByType(typeof(Fading)));
                    fade.Fade(Fading.type.FadeIn);
                    Instantiate(BL_Tu_3_SceneControllerPrefab);
                    break;
                }

        }
       
    }


    void Update()
    {
        if (PlayerInfo.InstanceNullable == null) return;
        PlayerInfo.Instance.CheckPlayerDeath();
        if (Input.GetMouseButton(1))
        {
            DeactivateAllPanels();
            PlayerInfo.Instance.Inventry.SetVisible(false);
        }
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

        SceneManager.LoadScene(next_scene);
    }
}
   
