using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class After_LocationSentaku1 : MonoBehaviour
{
    public GameObject newPanel; // 新しいUIパネルへの参照
                                // public GameObject text;

    [SerializeField]
    string sceneName;


    void Start()
    {
        newPanel.SetActive(false); // パネルを表示する

    }
    public void OnClick()
    {
        // マウスの左クリックを検知

        ShowNewPanel(); // 新しいUIパネル(After_locationsentakuパネルを表示
                        //  text.SetActive(true);

    }



    public void yesnobutton(int num) //ここに引数を入れておくことでそれぞれのボタンごとにUnity側で引数を指定できる。
    {

        switch (num)
        {


            case 1: //押されたボタンのUnity側で設定された引数が1のだったとき
                Debug.Log("Aのボタンが押されたよ");
                SceneManager.LoadScene(sceneName);

                break;
            case 2: //押されたボタンのUnity側で設定された引数が2のだったとき
                Debug.Log("Bのボタンが押されたよ");
                newPanel.SetActive(false);
                break;

        }

    }


    // 新しいUIパネルを表示する関数
    public void ShowNewPanel()
    {
        newPanel.SetActive(true); // パネルを表示する

    }
}
