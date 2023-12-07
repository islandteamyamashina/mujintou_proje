using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Text_controler : MonoBehaviour
{

        [SerializeField] public Text gotext; // 新しいUIパネルへの参照

        public void Text_of_each_Location(int num)
    {
        switch (num)
        {
            case 1: //押されたボタンのUnity側で設定された引数が1のだったとき
                gotext.text = "森へ向かいますか";
                break;
            case 2: //押されたボタンのUnity側で設定された引数が1のだったとき
                gotext.text = "川辺へ向かいますか";
                break;
            case 3: //押されたボタンのUnity側で設定された引数が1のだったとき
                gotext.text = "洞窟へ向かいますか";
                break;
            case 4: //押されたボタンのUnity側で設定された引数が1のだったとき
                gotext.text = "火口へ向かいますか";
                break;
            case 5: //押されたボタンのUnity側で設定された引数が1のだったとき
                gotext.text = "山岳へ向かいますか";
                break;
            case 6: //押されたボタンのUnity側で設定された引数が1のだったとき
                gotext.text = "海岸へ向かいますか";
                break;

        }
    }
}