using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

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
    [SerializeField] public GameObject Text_screen;
    public string gamepath;
    public string timeStamp;
    string screenShotPath;

    private void Awake()
    {
        fade.Fade(Fading.type.FadeIn);
        Debug.Log(PlayerInfo.Instance.Day.day);
        Txt_day.text = PlayerInfo.Instance.Day.day.ToString() + " 日";
        if (PlayerInfo.Instance.Health <= 0)
        {
            Debug.Log(PlayerInfo.Instance.Health);
            Txt_deador.text = "生還 失敗";

        }
        if (PlayerInfo.Instance.Health > 0)
        {
            Txt_deador.text = "生還 成功";

        }
        Debug.Log(PlayerInfo.Instance.FirstItemId);
        int ID = PlayerInfo.Instance.FirstItemId;
        string name = PlayerInfo.Instance.Inventry.GetItemName((Items.Item_ID)ID);
        ItemImage.sprite = SlotManager.GetItemData((Items.Item_ID)PlayerInfo.Instance.FirstItemId).icon;
            Special.text = name;
        //Instantiate(ActionValueImagePrefab, action.gameObject.transform);
        Text_screen.SetActive(false);

    }

    private void Start()
    {

        Invoke(nameof(ReToTitle), 10f);

    }
    public string Capture()
    {
        DateTime date = DateTime.Now;
        timeStamp = date.ToString("yyyy-MM-dd-HH-mm-ss-fff");
        string path = "";

        // プロジェクトファイル直下に作成
        path = "screenshot/" + timeStamp + ".png";


        return path;
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


    public void Capture_button()
    {
        Text_screen.SetActive(true);

        screenShotPath = Capture();

        // ファイルとして保存するならFile.WriteAllBytes()を実行
        ScreenCapture.CaptureScreenshot(screenShotPath);



    }
    //public void Display()
    //{
    //    File.ReadAllBytes("screenshot/test.png");
    //}
}


// Start is called before the first frame update


