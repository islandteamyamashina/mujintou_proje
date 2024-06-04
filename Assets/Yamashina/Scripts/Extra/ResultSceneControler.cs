using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultSceneControler : MonoBehaviour
{



    [SerializeField]
    SceneObject title;
    [SerializeField]
    RawImage RawImage;

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
        Capture("screenshot/test.png");
    }
    public void Display()
    {
        File.ReadAllBytes("screenshot/test.png");
    }
}


// Start is called before the first frame update


