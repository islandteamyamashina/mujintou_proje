using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MyScriptable/Create EventData")]
public class EventData : ScriptableObject
{
    [Header("�C�x���g�t���O")]
    public bool Event_Flag;
    [Header("�C�x���g�i���o�[")]
    public int Event_Num;
    [Header("�w�i")]
    public Sprite Event_BG;
    [Header("�C�x���g�C���X�g")]
    public Sprite Event_Ilast;
    [Header("�C�x���g�^�C�g��")]
    public string Event_Title;
    [Header("�����ꏊ")]
    public int Place;
    [Header("�m���̏d��")]
    public int Probability;
    [Header("��������")]
    public int Conditions;
    [Header("�e�L�X�g�{��")]
    public string Main_Text;
    [Header("�I�����P")]
    public string Sentakusi1;
    [Header("�I�����Q")]
    public string Sentakusi2;
    [Header("�L�����Z��")]
    public string Cancel;
    [Header("�I����1����1")]
    public string Sentakusi1_Result1;
    [Header("�I����1����1�m��")]
    public int Sentakusi1_Result1_Probability;

    //[Header("�΂̎擾�� max")]
    //public int 1_1GetRope_max;
    //[Header("�΂̎擾�� min")]
    //public int GetRope_min;
    //[Header("�}�̎擾�� max")]
    //public int GetRope_max;
    //[Header("�}�̎擾�� min")]
    //public int GetRope_min;
    //[Header("�������J�j�̎擾�� max")]
    //public int GetRope_max;
    //[Header("�������J�j�̎擾�� min")]
    //public int GetRope_min;
    //[Header("���������L�̎擾�� max")]
    //public int GetRope_max;
    //[Header("���������L�̎擾�� min")]
    //public int GetRope_min;
    //[Header("�R�R�i�b�c�̎擾�� max")]
    //public int GetRope_max;
    //[Header("�R�R�i�b�c�̎擾�� min")]
    //public int GetRope_min;
    //[Header("��̃{�g���̎擾�� max")]
    //public int GetRope_max;
    //[Header("��̃{�g���̎擾�� min")]
    //public int GetRope_min;
    //[Header("�{���{���̓�̎擾�� max")]
    //public int GetRope_max;
    //[Header("�{���{���̓�̎擾�� min")]
    //public int GetRope_min;
    //[Header("���V�K���̎擾�� max")]
    //public int GetRope_max;
    //[Header("���V�K���̎擾�� min")]
    //public int GetRope_min;
    //[Header("�t���[�c�̎擾�� max")]
    //public int GetRope_max;
    //[Header("�t���[�c�̎擾�� min")]
    //public int GetRope_min;
    //[Header("���Ԃ�ȃC���̎擾�� max")]
    //public int GetRope_max;
    //[Header("���Ԃ�ȃC���̎擾�� min")]
    //public int GetRope_min;
    //[Header("�{���z�̎擾�� max")]
    //public int GetRope_max;
    //[Header("�{���z�̎擾�� min")]
    //public int GetRope_min;

    [Header("�I����1����2")]
    public string Sentakusi1_Result2;
    [Header("�I����1����2�m��")]
    public int Sentakusi1_Result2_Probability;
    [Header("�I����1����3")]
    public string Sentakusi1_Result3;
    [Header("�I����1����3�m��")]
    public int Sentakusi1_Result3_Probability;
    [Header("�I����1����4")]
    public string Sentakusi1_Result4;
    [Header("�I����1����4�m��")]
    public int Sentakusi1_Result4_Probability;
    [Header("�I����1����5")]
    public string Sentakusi1_Result5;
    [Header("�I����1����5�m��")]
    public int Sentakusi1_Result5_Probability;
    [Header("�I����2����1")]
    public string Sentakusi2_Result1;
    [Header("�I����2����1�m��")]
    public int Sentakusi2_Result1_Probability;
    [Header("�I����2����2")]
    public string Sentakusi2_Result2;
    [Header("�I����2����2�m��")]
    public int Sentakusi2_Result2_Probability;
    [Header("�I����2����3")]
    public string Sentakusi2_Result3;
    [Header("�I����2����3�m��")]
    public int Sentakusi2_Result3_Probability;
    [Header("�I����2����4")]
    public string Sentakusi2_Result4;
    [Header("�I����2����4�m��")]
    public int Sentakusi2_Result4_Probability;
    [Header("�I����2����5")]
    public string Sentakusi2_Result5;
    [Header("�I����2����5�m��")]
    public int Sentakusi2_Result5_Probability;
    [Header("�L�����Z������")]
    public string Cancel_Result;
}
