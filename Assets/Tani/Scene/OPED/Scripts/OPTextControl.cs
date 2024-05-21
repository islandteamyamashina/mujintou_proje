using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


namespace Opening
{
    [RequireComponent(typeof(TextControl))]
    [RequireComponent(typeof(ShakeUI))]
    [RequireComponent(typeof(Fading))]
    public class OPTextControl : MonoBehaviour
    {
        [SerializeField]
        List<TextAsset> textAssets;
        [SerializeField]
        Image BG_image;
        [SerializeField]
        List<Sprite> BG_images;
        [SerializeField]
        GameObject ChoiseButtonsPrefab;
        [SerializeField]
        GameObject PlayerPrefab;
        [SerializeField]
        SceneObject next_scene;

        TextControl textContol;
        ShakeUI shake;
        Fading fading;
        PlayerInfo info;
        private void Start()
        {

            shake = GetComponent<ShakeUI>();
            textContol = GetComponent<TextControl>();
            fading = GetComponent<Fading>();
            textContol.ResetTextData();
            AddTextDataToTextControl(0);
            textContol.ClickEventAfterTextsEnd.AddListener(EventAfterFirst);
            if (PlayerInfo.InstanceNullable)
            {
                PlayerInfo.Instance.DestroySelf();
            }
            Instantiate(PlayerPrefab);
            info = PlayerInfo.Instance;
            info.StartGame(true);

        }

        void AddTextDataToTextControl(int index)
        {
            if(index > textAssets.Count)
            {
                Debug.LogError("index out of Range int textAssets");
                return;
            }

            textContol.ResetTextData();
            textContol.EndEvent.RemoveAllListeners();
            textContol.ClickEventAfterTextsEnd.RemoveAllListeners();

            string rawData = textAssets[index].text;
            string[] splitedText = rawData.Split(char.Parse("\n"));
            foreach (var text in splitedText)
            {
                textContol.AddTextData(text);
            }
        }

        void EventAfterFirst()
        {
            var info = new ShakeUI.ShakeInfo(3, 100, 5);
            info.OnShakeEnd.AddListener(() => {
                BG_image.sprite = BG_images[1];
                AddTextDataToTextControl(1);
                textContol.ClickEventAfterTextsEnd.AddListener(EventAfterSecond);
            });
            shake.Shake(BG_image.gameObject, info);
            textContol.ClickEventAfterTextsEnd.RemoveAllListeners();
        }

        void EventAfterSecond()
        {
            textContol.ClickEventAfterTextsEnd.RemoveAllListeners();
            textContol.ResetTextData();
            AddTextDataToTextControl(2);
            textContol.ClickEventAfterTextsEnd.AddListener(() =>
            {
                textContol.ClickEventAfterTextsEnd.RemoveAllListeners();
                var info = new ShakeUI.ShakeInfo(3, 100, 5);
                info.OnShakeEnd.RemoveAllListeners();
                info.OnShakeEnd.AddListener(() =>
                {
                    BG_image.sprite = BG_images[1];
                    AddTextDataToTextControl(3);
                    textContol.ClickEventAfterTextsEnd.AddListener(EventAfterThird);
                });
                shake.Shake(BG_image.gameObject, info);
            });
        }

        void EventAfterThird()
        {
            textContol.ResetTextData();
            textContol.ClickEventAfterTextsEnd.RemoveAllListeners();
            BG_image.sprite = BG_images[2];
            AddTextDataToTextControl(4);
            textContol.ClickEventAfterTextsEnd.AddListener(EventAfterForth);
        }

        void EventAfterForth()
        {
            textContol.ClickEventAfterTextsEnd.RemoveAllListeners();
            var choises = Instantiate<GameObject>(ChoiseButtonsPrefab, gameObject.transform);
            Button[] buttons = choises.GetComponentsInChildren<Button>();
            foreach (var button in buttons)
            {
                button.onClick.AddListener(() =>
                {
                    var item = button.gameObject.GetComponent<SpecialItemData>().specil_item_id;
                    info.Inventry.GetItem(item, 1);
                    Destroy(choises);
                    textContol.ResetTextData();
                    AddTextDataToTextControl(5);
                    textContol.ClickEventAfterTextsEnd.AddListener(EventAfterFifth);
                });
            }
        }

        void EventAfterFifth()
        {
            textContol.ResetTextData();
            GetComponent<Text>().text = "";
            fading.SetFadeImageActivaton(true);
            StartCoroutine(EventAfterFifthCoroutine());
        }

        IEnumerator EventAfterFifthCoroutine()
        {
            yield return new WaitForSeconds(3);
            BG_image.sprite = BG_images[3];
            fading.Fade(Fading.type.FadeIn);
            fading.OnFadeEnd.AddListener(() =>
            {
                AddTextDataToTextControl(6);
                textContol.ClickEventAfterTextsEnd.AddListener(EventAfterSixth);
            });
        }

        void EventAfterSixth()
        {
            SceneManager.LoadScene(next_scene);
        }

        

    }
}

