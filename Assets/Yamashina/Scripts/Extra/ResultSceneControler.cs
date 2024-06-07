using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using System.Text.RegularExpressions;

public class ResultSceneControler : MonoBehaviour
{



    [SerializeField]
    SceneObject title;
    [SerializeField] Text Txt_deador;
    [SerializeField] Text Txt_day;
    [SerializeField] Text Special;
    [SerializeField]
    Fading fade;
    //[SerializeField]
    //RawImage RawImage;
    //[SerializeField] GameObject action;
    //[SerializeField]
    //GameObject ActionValueImagePrefab;
    [SerializeField]
    Image ItemImage;
    [SerializeField] public  GameObject Text_screen;
    public string gamepath;
    public string timeStamp;
    string screenShotPath;
    bool isDisplayed;

    private void Awake()
    {
        fade.Fade(Fading.type.FadeIn);
        Debug.Log(PlayerInfo.Instance.Day.day);
        Txt_day.text = PlayerInfo.Instance.Day.day.ToString() + "日";
        //Txt_day.text = 20.ToString() + "日";
        if (PlayerInfo.Instance.Health <= 0)
        {
            Debug.Log(PlayerInfo.Instance.Health);
            Txt_deador.text = "失敗";

        }
        if (PlayerInfo.Instance.Health > 0)
        {
            Txt_deador.text = "成功";

        }
        Debug.Log(PlayerInfo.Instance.FirstItemId);
        int ID = PlayerInfo.Instance.FirstItemId;
        string name = PlayerInfo.Instance.Inventry.GetItemName((Items.Item_ID)ID);
        ItemImage.sprite = SlotManager.GetItemData((Items.Item_ID)PlayerInfo.Instance.FirstItemId).icon;
        Special.text = name;
        //Instantiate(ActionValueImagePrefab, action.gameObject.transform);
        //Text_screen.SetActive(false);

    }

    private void Start()
    {
        isDisplayed = false;
        //Text_screen.SetActive(false);
        Invoke(nameof(ReToTitle), 50f);

    }
    public static class ScreenshotCaptor
    {

        /// <summary>
        /// スクリーンショットを撮る
        /// </summary>
        public static IEnumerator Capture(string imageName = "image.png", Action callback = null)
        {

            DateTime date = DateTime.Now;
            imageName = date.ToString("yyyy-MM-dd-HH-mm-ss-fff");
             string path = "";

            // プロジェクトファイル直下に作成
            path = "screenshot/" + imageName + ".png";
            string imagePath = path;

            //iOS、Android実機の時はパスにApplication.persistentDataPathを追加
#if !UNITY_EDITOR && (UNITY_IOS || UNITY_ANDROID)
    imagePath = Path.Combine(Application.persistentDataPath, imageName);
#endif

            //前に撮ったスクショを削除
            File.Delete(imagePath);

            //スクリーンショットを撮る
            UnityEngine.ScreenCapture.CaptureScreenshot(imagePath);
            //スクリーンショットが保存されるまで待機(最大2秒)
            float latency = 0, latencyLimit = 2;
            while (latency < latencyLimit)
            {
                //ファイルが存在していればループ終了
                if (File.Exists(imagePath))
                {
                    break;
                }
                latency += Time.deltaTime;
                yield return null;
            }
            //待機時間が上限に達していたら警告表示(おそらくスクショが保存出来ていない時)
            if (latency >= latencyLimit)
            {
                Debug.LogWarning("待機時間が上限に達しました！正常にスクリーンショットが保存できていません！");
            }

            //コールバックが登録されていれば実行
            if (callback != null)
            {
                callback();
            }
        }
    }
    public void ReToTitle()
    {
        var loaded = SceneManager.LoadSceneAsync(title);
        loaded.allowSceneActivation = false;
        //プレイヤーの破壊をここに移動//
        if (PlayerInfo.InstanceNullable)
        {
            PlayerInfo.Instance.DestroySelf();
        }
        DataManager.ErasePlayerSaveData();
        //プレイヤーの破壊をここに移動//
        loaded.allowSceneActivation = true;

    }
    //public void Display()
    //{
    //    File.ReadAllBytes("screenshot/test.png");
    //}
    public void CaptureButtton()
    {

        StartCoroutine(
          ScreenshotCaptor.Capture(
            imageName: "Screenshot.png", 
    callback: Callback
          )
        );


    }

    //撮影完了時に実行される
    private void Callback()
    {
        Debug.Log("撮影完了");
        Text_screen.SetActive(true);
    }
}



// Start is called before the first frame update


