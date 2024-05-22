using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialController : MonoBehaviour
{
    [SerializeField]
    TextControl textControl;
    [SerializeField]
    List<TextAsset> textAssets;

    private void Start()
    {
        textControl.ResetTextData();
        textControl.ClickEventAfterTextsEnd.RemoveAllListeners();
        AddTextDataToTextControl(0);
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
