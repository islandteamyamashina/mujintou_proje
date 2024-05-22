using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BL_Tu_2_SceneController : MonoBehaviour
{
    [SerializeField]
    TextControl textControl;
    [SerializeField]
    List<TextAsset> textAssets;
    [SerializeField]
    GameObject tips;
    [SerializeField]
    GameObject nextTips;
    [SerializeField]
    SceneObject nextScene;


    private void Start()
    {
        textControl.ResetTextData();
        textControl.ClickEventAfterTextsEnd.RemoveAllListeners();
        AddTextDataToTextControl(0);
        textControl.ClickEventAfterTextsEnd.AddListener(() =>
        {
            textControl.ClickEventAfterTextsEnd.RemoveAllListeners();
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            Instantiate(tips);

        });

        PlayerInfo.Instance.OnMaxActionValueChange.AddListener(MakeTips2);
    }

    void MakeTips2()
    {
        PlayerInfo.Instance.OnMaxActionValueChange.RemoveListener(MakeTips2);
        Instantiate(nextTips);
        PlayerInfo.Instance.Inventry.SwitchVisible();
    }

    public void NextText()
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
        textControl.ResetTextData();
        textControl.ResetTextData();
        textControl.ClickEventAfterTextsEnd.RemoveAllListeners();
        AddTextDataToTextControl(1);
        textControl.ClickEventAfterTextsEnd.AddListener(() =>
        {
            textControl.ClickEventAfterTextsEnd.RemoveAllListeners();
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            var fading = (Fading)GameObject.FindAnyObjectByType(typeof(Fading));
            fading.Fade(Fading.type.FadeOut);
            fading.OnFadeEnd.AddListener(() =>
            {
                SceneManager.LoadScene(nextScene);
            });

        });
    }
    
    

    void AddTextDataToTextControl(int index)
    {
        if (index > textAssets.Count)
        {
            Debug.LogError("index out of Range int textAssets");
            return;
        }

        textControl.ResetTextData();
        textControl.EndEvent.RemoveAllListeners();
        textControl.ClickEventAfterTextsEnd.RemoveAllListeners();

        string rawData = textAssets[index].text;
        string[] splitedText = rawData.Split(char.Parse("\n"));
        foreach (var text in splitedText)
        {
            textControl.AddTextData(text);
        }
    }
}
