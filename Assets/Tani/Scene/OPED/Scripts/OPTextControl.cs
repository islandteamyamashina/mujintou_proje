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
        [SerializeField]
        GameObject TextBG;

        TextControl textContol;
        ShakeUI shake;
        Fading fading;
        PlayerInfo info;

        //柴田追加分//
        [SerializeField] GameObject SEPlayer;
        [SerializeField] GameObject BGMPlayer;
        //ここまで//
        private void Start()
        {
            GameData.CanReturnTitle = false;
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
            //柴田追加分//
            BGMPlayer.GetComponent<anotherBGMPlayer>().StartCoroutine("FadeOutAudio",2);
            SEPlayer.GetComponent<anotherSoundPlayer>().ChooseSongs_SE(10);
            //ここまで//
            var info = new ShakeUI.ShakeInfo(3, 100, 5);
            info.OnShakeEnd.AddListener(() => {

                //柴田追加分//
                anotherBGMPlayer ABP = BGMPlayer.GetComponent<anotherBGMPlayer>();
                StartCoroutine(ABP.FadeInAudio(5, 2));
                //ここまで//

                var fade = (Fading)FindAnyObjectByType(typeof(Fading));
                fade.fading_time = 0.5f;
                fade.Fade(Fading.type.FadeOut);
                fade.OnFadeEnd.AddListener(() =>
                {
                    StartCoroutine(cf());
                });
            });
            shake.Shake(BG_image.gameObject, info);
            textContol.ClickEventAfterTextsEnd.RemoveAllListeners();
        }

        IEnumerator cf()
        {
            yield return null;
            BG_image.sprite = BG_images[1];
            var fade = (Fading)FindAnyObjectByType(typeof(Fading));
            fade.fading_time = 0.5f;
            fade.Fade(Fading.type.FadeIn);
            fade.OnFadeEnd.AddListener(() =>
            {

                AddTextDataToTextControl(1);
                textContol.ClickEventAfterTextsEnd.AddListener(EventAfterSecond);
                fade.fading_time = 3f;
            });

        }

        void EventAfterSecond()
        {
            textContol.ClickEventAfterTextsEnd.RemoveAllListeners();
            textContol.ResetTextData();
            AddTextDataToTextControl(2);
            textContol.ClickEventAfterTextsEnd.AddListener(() =>
            {
                textContol.ClickEventAfterTextsEnd.RemoveAllListeners();
                //柴田追加分//
                SEPlayer.GetComponent<anotherSoundPlayer>().ChooseSongs_SE(10);
                //ここまで//
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
            //柴田追加分//
            BGMPlayer.GetComponent<anotherBGMPlayer>().StartCoroutine("FadeOutAudio", 3);
            //ここまで//
            BG_image.sprite = BG_images[2];
            AddTextDataToTextControl(4);
            textContol.ClickEventAfterTextsEnd.AddListener(EventAfterForth);
        }

        void EventAfterForth()
        {
            ((OPSkipSystem)GameObject.FindAnyObjectByType(typeof(OPSkipSystem))).DestroySkipButton();
            textContol.ClickEventAfterTextsEnd.RemoveAllListeners();
            var choises = Instantiate<GameObject>(ChoiseButtonsPrefab, gameObject.transform);
            Button[] buttons = choises.GetComponentsInChildren<Button>();
            foreach (var button in buttons)
            {
                button.onClick.AddListener(() =>
                {
                    var item = button.gameObject.GetComponent<SpecialItemData>().specil_item_id;
                    PlayerInfo.Instance.FirstItemId = (int)item;
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
            TextBG.SetActive(false);
            yield return new WaitForSeconds(3);
            BG_image.sprite = BG_images[3];
            fading.Fade(Fading.type.FadeIn);
            //柴田追加分//
            anotherBGMPlayer ABP = BGMPlayer.GetComponent<anotherBGMPlayer>();
            StartCoroutine(ABP.FadeInAudio(6, 2));
            //ここまで//
            fading.OnFadeEnd.AddListener(() =>
            {
                AddTextDataToTextControl(6);
                textContol.ClickEventAfterTextsEnd.AddListener(EventAfterSixth);
                TextBG.SetActive(true);
            });
        }

        void EventAfterSixth()
        {
            //柴田追加分//
            fading.Fade(Fading.type.FadeOut);
            BGMPlayer.GetComponent<anotherBGMPlayer>().StartCoroutine("FadeOutAudio", 1);
            fading.OnFadeEnd.AddListener(() => 
            {
            //ここまで//
                SceneManager.LoadScene(next_scene);
            });
            
        }

        

    }
}

