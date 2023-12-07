using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NovelGame
{
    public class Game_Manager : MonoBehaviour
    {
        // �ʂ̃N���X����GameManager�̕ϐ��Ȃǂ��g����悤�ɂ��邽�߂̂��́B�i�ύX�͂ł��Ȃ��j
        public static Game_Manager Instance { get; private set; }

        public User_Script_Manager userScriptManager;
        public Main_Text_Controller mainTextController;
        public Image_Manager imageManager;

        // ���[�U�X�N���v�g�́A���̍s�̐��l�B�N���b�N�i�^�b�v�j�̂��т�1��������B
        [System.NonSerialized] public int lineNumber;

        void Awake()
        {
            // ����ŁA�ʂ̃N���X����GameManager�̕ϐ��Ȃǂ��g����悤�ɂȂ�B
            Instance = this;

            lineNumber = 0;
        }
    }
}