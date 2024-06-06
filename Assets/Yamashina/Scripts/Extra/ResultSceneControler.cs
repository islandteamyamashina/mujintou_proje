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
        Txt_day.text = PlayerInfo.Instance.Day.day.ToString() + " ��";
        if (PlayerInfo.Instance.Health <= 0)
        {
            Debug.Log(PlayerInfo.Instance.Health);
            Txt_deador.text = "���� ���s";

        }
        if (PlayerInfo.Instance.Health > 0)
        {
            Txt_deador.text = "���� ����";

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

        // �v���W�F�N�g�t�@�C�������ɍ쐬
        path = "screenshot/" + timeStamp + ".png";


        return path;
    }

    public void ReToTitle()
    {
        var loaded = SceneManager.LoadSceneAsync(title);
        loaded.allowSceneActivation = false;
        //�v���C���[�̔j��������Ɉړ�//
        if (PlayerInfo.InstanceNullable)
        {
            PlayerInfo.Instance.DestroySelf();
        }
        DataManager.ErasePlayerSaveData();
        //�v���C���[�̔j��������Ɉړ�//
        loaded.allowSceneActivation = true;

    }


    public void Capture_button()
    {
        Text_screen.SetActive(true);

        screenShotPath = Capture();

        // �t�@�C���Ƃ��ĕۑ�����Ȃ�File.WriteAllBytes()�����s
        ScreenCapture.CaptureScreenshot(screenShotPath);



    }
    //public void Display()
    //{
    //    File.ReadAllBytes("screenshot/test.png");
    //}
}


// Start is called before the first frame update


