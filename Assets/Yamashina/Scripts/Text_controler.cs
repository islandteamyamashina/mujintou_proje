using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Text_controler : MonoBehaviour
{

        [SerializeField] public Text gotext; // �V����UI�p�l���ւ̎Q��

        public void Text_of_each_Location(int num)
    {
        switch (num)
        {
            case 1: //�����ꂽ�{�^����Unity���Őݒ肳�ꂽ������1�̂������Ƃ�
                gotext.text = "�X�֌������܂���";
                break;
            case 2: //�����ꂽ�{�^����Unity���Őݒ肳�ꂽ������1�̂������Ƃ�
                gotext.text = "��ӂ֌������܂���";
                break;
            case 3: //�����ꂽ�{�^����Unity���Őݒ肳�ꂽ������1�̂������Ƃ�
                gotext.text = "���A�֌������܂���";
                break;
            case 4: //�����ꂽ�{�^����Unity���Őݒ肳�ꂽ������1�̂������Ƃ�
                gotext.text = "�Ό��֌������܂���";
                break;
            case 5: //�����ꂽ�{�^����Unity���Őݒ肳�ꂽ������1�̂������Ƃ�
                gotext.text = "�R�x�֌������܂���";
                break;
            case 6: //�����ꂽ�{�^����Unity���Őݒ肳�ꂽ������1�̂������Ƃ�
                gotext.text = "�C�݂֌������܂���";
                break;

        }
    }
}