using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace NovelGame
{
    public class User_Script_Manager : MonoBehaviour
    {
        [SerializeField] TextAsset _textFile;

        // 文章中の文（ここでは１行ごと）を入れておくためのリスト
        List<string> _sentences = new List<string>();

        void Awake()
        {
            // テキストファイルの中身を、１行ずつリストに入れておく
            StringReader reader = new StringReader(_textFile.text);
            while (reader.Peek() != -1)
            {
                string line = reader.ReadLine();
                _sentences.Add(line);
            }
        }

        // 現在の行の文を取得する
        public string Get_Current_Sentence()
        {
            return _sentences[Game_Manager.Instance.lineNumber];
        }

        // 文が命令かどうか
        public bool IsStatement(string sentence)
        {
            if (sentence[0] == '&')
            {
                return true;
            }
            return false;
        }

        // 命令を実行する
        public void ExecuteStatement(string sentence)
        {
            string[] words = sentence.Split(' ');
            switch (words[0])
            {
                case "&img":
                    Game_Manager.Instance.imageManager.PutImage(words[1], words[2]);
                    break;
                case "&rmimg":
                    Game_Manager.Instance.imageManager.Remove_Image(words[1]);
                    break;
            }
        }
    }
}