using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BL_Tu_SceneController : MonoBehaviour
{
    [SerializeField]
    TextControl textControl;
    [SerializeField]
    List<TextAsset> textAssets;
    [SerializeField]
    GameObject tips;


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
    }

    public void LastText()
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
        textControl.ResetTextData();
        textControl.ClickEventAfterTextsEnd.RemoveAllListeners();
        AddTextDataToTextControl(1);
        textControl.ClickEventAfterTextsEnd.AddListener(() =>
        {
            textControl.ClickEventAfterTextsEnd.RemoveAllListeners();
            gameObject.transform.GetChild(0).gameObject.SetActive(false);

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
