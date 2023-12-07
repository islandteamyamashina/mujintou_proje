using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace NovelGame
{
    public class Main_Text_Controller : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI _mainTextObject;
        int _displayed_Sentence_Length;
        int _sentence_Lenght;
        float _time;
        float _feed_Time;

        // Start is called before the first frame update
        void Start()
        {
            _time = 0f;
            _feed_Time = 0.05f;

            // �ŏ��̍s�̃e�L�X�g��\���A�܂��͖��߂����s
            string statement = Game_Manager.Instance.userScriptManager.Get_Current_Sentence();
            if (Game_Manager.Instance.userScriptManager.IsStatement(statement))
            {
                Game_Manager.Instance.userScriptManager.ExecuteStatement(statement);
                Go_To_The_Next_Line();
            }
            Display_Text();
        }

        // Update is called once per frame
        void Update()
        {
            // ���͂��P�������\������
            _time += Time.deltaTime;
            if (_time >= _feed_Time)
            {
                _time -= _feed_Time;
                if (!CanGoToTheNextLine())
                {
                    _displayed_Sentence_Length++;
                    _mainTextObject.maxVisibleCharacters = _displayed_Sentence_Length;
                }
            }

            // �N���b�N���ꂽ�Ƃ��A���̍s�ֈړ�
            if (Input.GetMouseButtonUp(0))
            {
                if (CanGoToTheNextLine())
                {
                    Go_To_The_Next_Line();
                    Display_Text();
                }
                else
                {
                    _displayed_Sentence_Length = _sentence_Lenght;
                }
            }
        }

        // ���̍s�́A���ׂĂ̕������\������Ă��Ȃ���΁A�܂����̍s�֐i�ނ��Ƃ͂ł��Ȃ�
        public bool CanGoToTheNextLine()
        {
            string sentence = Game_Manager.Instance.userScriptManager.Get_Current_Sentence();
            _sentence_Lenght = sentence.Length;
            return (_displayed_Sentence_Length > sentence.Length);
        }

        // ���̍s�ֈړ�
        public void Go_To_The_Next_Line()
        {
            _displayed_Sentence_Length = 0;
            _time = 0f;
            _mainTextObject.maxVisibleCharacters = 0;
            Game_Manager.Instance.lineNumber++;
            string sentence = Game_Manager.Instance.userScriptManager.Get_Current_Sentence();
            if (Game_Manager.Instance.userScriptManager.IsStatement(sentence))
            {
                Game_Manager.Instance.userScriptManager.ExecuteStatement(sentence);
                Go_To_The_Next_Line();
            }
        }

        // �e�L�X�g��\��
        public void Display_Text()
        {
            string sentence = Game_Manager.Instance.userScriptManager.Get_Current_Sentence();
            _mainTextObject.text = sentence;
        }
    }
}