using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


namespace NovelGame
{
    public class Event_Text_Controler : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI _eventTextObject;
        int _displayed_Sentence_Length;
        int _sentence_Lenght;
        float _time;
        float _feed_Time;


        // Start is called before the first frame update
        void Start()
        {
            _time = 0f;
            _feed_Time = 0.05f;

            // 最初の行のテキストを表示、または命令を実行
            string statement = Game_Manager.Instance.userScriptManager.Get_Current_Sentence();
            if (Game_Manager.Instance.userScriptManager.IsStatement(statement))
            {
                Game_Manager.Instance.userScriptManager.ExecuteStatement(statement);
                Game_Manager.Instance.mainTextController.Go_To_The_Next_Line();
            }
            Game_Manager.Instance.mainTextController.Display_Text();

        }

        // Update is called once per frame
        void Update()
        {
            _time += Time.deltaTime;
            if (_time >= _feed_Time)
            {
                _time -= _feed_Time;
                if (!Game_Manager.Instance.mainTextController.CanGoToTheNextLine())
                {
                    _displayed_Sentence_Length++;
                    _eventTextObject.maxVisibleCharacters = _displayed_Sentence_Length;
                }
            }
        }
    }
}