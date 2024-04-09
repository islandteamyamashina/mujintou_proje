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
    //BaseLocationDayTime�ɃV�[���𓝈�
    //�s���l�������ȏ゠��Β��A�Ȃ���Ζ�
    //�T������A���čs���l�������ȏ゠��΍ĂђT���ɂ�����
    //���͋x���A��͐��������邱�Ƃ��ł���
    //�����͂��Ȃ���΂Ȃ�Ȃ����́[���s���l�񕜂Ǝ��Ԍo�߂̂�
    //�x���͍s���l�𔼕�����̗͂𔼕���
    //�N���t�g�ɍs���l���d�l����
    //�T���ɍs�����ƒT���ɍs�����߂̏�����������Ƃ��č��ʉ��ł���
}
