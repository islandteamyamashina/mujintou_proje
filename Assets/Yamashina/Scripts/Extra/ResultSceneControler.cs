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
    RawImage RawImage;
    [SerializeField] GameObject action;
    [SerializeField]
    GameObject ActionValueImagePrefab;
    private void Awake()
    {
        Debug.Log(PlayerInfo.Instance.Day.day);
        Txt_day.text = PlayerInfo.Instance.Day.day.ToString() + " ����";
        if (PlayerInfo.Instance.Health <= 0)
        {
            Debug.Log(PlayerInfo.Instance.Health);
            Txt_deador.text = "�E�o���s";

        }
        if (PlayerInfo.Instance.Health > 0)
        {
            Txt_deador.text = "�E�o����";

        }
        Debug.Log(PlayerInfo.Instance.FirstItemId);
        int ID =PlayerInfo.Instance.FirstItemId;
        string name = PlayerInfo.Instance.Inventry.GetItemName((Items.Item_ID)ID);
        Special.text = "�ŏ��Ɏ�ɓ��ꂽ�A�C�e����" + name;
        Instantiate(ActionValueImagePrefab, action.gameObject.transform);

    }

    private void Start()
    {

        Invoke(nameof(ReToTitle), 5.5f);

    }
    public static void Capture(string path)
    {
        string directory = Path.GetDirectoryName(path);

        if (!Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
        }

        string extension = Path.GetExtension(path).ToLower();

        switch (extension)
        {
            case ".jpg":
            case ".jpeg":
                File.WriteAllBytes(path, ScreenCapture.CaptureScreenshotAsTexture().EncodeToJPG());
                break;
            case ".png":
                ScreenCapture.CaptureScreenshot(path);
                break;
            case ".tga":
                File.WriteAllBytes(path, ScreenCapture.CaptureScreenshotAsTexture().EncodeToTGA());
                break;
        }
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
        Capture("screenshot/test.png");
    }
    public void Display()
    {
        File.ReadAllBytes("screenshot/test.png");
    }
}


// Start is called before the first frame update


