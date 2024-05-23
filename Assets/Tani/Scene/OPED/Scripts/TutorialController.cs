using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialController : MonoBehaviour
{
    [SerializeField]
    TextControl textControl;
    [SerializeField]
    List<TextAsset> textAssets;
    [SerializeField]
    SceneObject NextScene;

    private void Start()
    {
        //ŽÄ“c’Ç‰Á•ª//
        var fade = GetComponent<Fading>();
        fade.Fade(Fading.type.FadeIn);
        anotherBGMPlayer ABP = GameObject.FindAnyObjectByType(typeof(anotherBGMPlayer)).GetComponent<anotherBGMPlayer>();
        StartCoroutine(ABP.FadeInAudio(3, 4));
        //‚±‚±‚Ü‚Å//
        textControl.ResetTextData();
        textControl.ClickEventAfterTextsEnd.RemoveAllListeners();
        AddTextDataToTextControl(0);
        textControl.ClickEventAfterTextsEnd.AddListener(() =>
        {
            textControl.ClickEventAfterTextsEnd.RemoveAllListeners();
           
            var fade =GetComponent<Fading>();
            print(fade);
            fade.fading_time = 1.5f;
            fade.Fade(Fading.type.FadeOut);
            fade.OnFadeEnd.AddListener(()=> SceneManager.LoadScene(NextScene));
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
