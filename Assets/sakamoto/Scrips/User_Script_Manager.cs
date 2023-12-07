using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace NovelGame
{
    public class User_Script_Manager : MonoBehaviour
    {
        [SerializeField] TextAsset _textFile;

        // ���͒��̕��i�����ł͂P�s���Ɓj�����Ă������߂̃��X�g
        List<string> _sentences = new List<string>();

        void Awake()
        {
            // �e�L�X�g�t�@�C���̒��g���A�P�s�����X�g�ɓ���Ă���
            StringReader reader = new StringReader(_textFile.text);
            while (reader.Peek() != -1)
            {
                string line = reader.ReadLine();
                _sentences.Add(line);
            }
        }

        // ���݂̍s�̕����擾����
        public string Get_Current_Sentence()
        {
            return _sentences[Game_Manager.Instance.lineNumber];
        }

        // �������߂��ǂ���
        public bool IsStatement(string sentence)
        {
            if (sentence[0] == '&')
            {
                return true;
            }
            return false;
        }

        // ���߂����s����
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