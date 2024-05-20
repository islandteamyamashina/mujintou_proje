using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class EDTextFlow : MonoBehaviour
{
    [SerializeField]
    List<TextAsset> textAssets;
    [SerializeField]
    List<Sprite> image_list;
    [SerializeField]
    Text text_obj;
    [SerializeField]
    TextControl textControl;
    [SerializeField]
    Image image_obj;
    [SerializeField]
    Image tall_image_obj;
    [SerializeField]
    Fading fade;
    [SerializeField]
    GameObject TextBG;
    [SerializeField]
    Image last_text;
    [SerializeField]
    SceneObject title;


    private void Awake()
    {
        if (PlayerInfo.InstanceNullable)
        {
            PlayerInfo.Instance.DestroySelf();
        }
        DataManager.ErasePlayerSaveData();
        tall_image_obj.gameObject.SetActive(false);
        TextBG.SetActive(false);
        fade.fading_time = 3f;
        fade.Fade(Fading.type.FadeIn);
        fade.OnFadeEnd.AddListener(() =>
        {
            TextBG.SetActive(true);
            fade.fading_time = 0.5f;
            AddTextDataToTextControl(0);
            textControl.ClickEventAfterTextsEnd.AddListener(() =>
            {
                textControl.ClickEventAfterTextsEnd.RemoveAllListeners();
                fade.Fade(Fading.type.FadeOut);
                fade.OnFadeEnd.AddListener(() =>
                {
                    StartCoroutine(f1());
                });
            });
        });
    }

    IEnumerator f1()
    {
        image_obj.sprite = image_list[1];
        fade.Fade(Fading.type.FadeIn);
        yield return null;
        fade.OnFadeEnd.AddListener(() =>
        {
            AddTextDataToTextControl(1);
            textControl.ClickEventAfterTextsEnd.AddListener(() =>
            {
                textControl.ClickEventAfterTextsEnd.RemoveAllListeners();
                fade.Fade(Fading.type.FadeOut);
                fade.OnFadeEnd.AddListener(() =>
                {
                    StartCoroutine(f2());
                });
            });
        });
    }

    IEnumerator f2()
    {
        tall_image_obj.gameObject.SetActive(true);
        fade.Fade(Fading.type.FadeIn);
        yield return null;
        fade.OnFadeEnd.AddListener(() =>
        {
           
            StartCoroutine(move());
        });
    }

    IEnumerator move()
    {
        yield return new WaitForSeconds(3f);
        TextBG.SetActive(false);
        while (true)
        {
            tall_image_obj.gameObject.transform.Translate(
                new Vector3(0, -200 * Time.deltaTime, 0));
            if(tall_image_obj.gameObject.transform.position.y <= -720)
            {
                break;
            }
            yield return null;
        }

        last_text.gameObject.SetActive(true);
        float alpha = 0;
        while (true)
        {
            var color = last_text.color;
            color.a = alpha;
            alpha += Time.deltaTime / 3.0f;
            last_text.color = color;
            if (color.a >= 1) break;
            yield return null;
        }
        var loaded = SceneManager.LoadSceneAsync(title);
        loaded.allowSceneActivation = false;
        yield return new WaitForSeconds(5f);
        loaded.allowSceneActivation = true;
        
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