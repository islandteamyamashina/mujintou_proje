using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NovelGame
{
    public class Game_Manager : MonoBehaviour
    {
        // 別のクラスからGameManagerの変数などを使えるようにするためのもの。（変更はできない）
        public static Game_Manager Instance { get; private set; }

        public User_Script_Manager userScriptManager;
        public Main_Text_Controller mainTextController;
        public Image_Manager imageManager;

        // ユーザスクリプトの、今の行の数値。クリック（タップ）のたびに1ずつ増える。
        [System.NonSerialized] public int lineNumber;

        void Awake()
        {
            // これで、別のクラスからGameManagerの変数などを使えるようになる。
            Instance = this;

            lineNumber = 0;
        }
    }
}