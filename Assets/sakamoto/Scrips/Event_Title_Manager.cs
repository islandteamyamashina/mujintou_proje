using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


namespace NovelGame
{
    public class Title_Manager : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI _titleTxstObject;

        // Update is called once per frame
        void Start()
        {
            Display_Event_Title();
        }


        // �^�C�g����\��
        public void Display_Event_Title()
        {
            string sentence = Game_Manager.Instance.userScriptManager.Get_Choice_Current_Sentence(0);
            _titleTxstObject.text = sentence;
        }
    }
}