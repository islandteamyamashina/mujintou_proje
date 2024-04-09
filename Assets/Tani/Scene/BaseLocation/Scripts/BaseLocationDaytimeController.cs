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
    SceneObject scene;
    [SerializeField]
    SceneObject next_base_location;

    // Start is called before the first frame update
    void Start()
    {

        var fade =  ((Fading)GameObject.FindAnyObjectByType(typeof(Fading)));
        fade.Fade(Fading.type.FadeIn);
        var areaNameShow = (AreaNameText)GameObject.FindAnyObjectByType(typeof(AreaNameText));
        IEnumerator coroutine = areaNameShow.ShowAreaText();
        fade.OnFadeEnd.AddListener(() => { StartCoroutine(coroutine); });

     
    }


    void Update()
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

    public void NextScene()
    {
        var fade = ((Fading)GameObject.FindAnyObjectByType(typeof(Fading)));
        fade.Fade(Fading.type.FadeOut);
        fade.OnFadeEnd.AddListener(() => { SceneManager.LoadScene(scene); });
        
    }

    public void ChangeBaseLocation()
    {
        var fade = ((Fading)GameObject.FindAnyObjectByType(typeof(Fading)));
        fade.Fade(Fading.type.FadeOut);
        fade.OnFadeEnd.AddListener(() => { SceneManager.LoadScene(next_base_location); });
        
    }
    //BaseLocationDayTimeにシーンを統一
    //行動値が半分以上あれば朝、なければ夜
    //探索から帰って行動値が半分以上あれば再び探索にいける
    //朝は休息、夜は睡眠をすることができる
    //睡眠はしなければならないものー＞行動値回復と時間経過のみ
    //休息は行動値を半分消費し体力を半分回復
    //クラフトに行動値を仕様する
    //探索に行く日と探索に行くための準備をする日として差別化できる
}
