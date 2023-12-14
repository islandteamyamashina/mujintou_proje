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
    public float Sentakusi1_Result1_Probability;
    [Header("�I����1����2")]
    public string Sentakusi1_Result2;
    [Header("�I����1����2�m��")]
    public float Sentakusi1_Result2_Probability;
    [Header("�I����1����3")]
    public string Sentakusi1_Result3;
    [Header("�I����1����3�m��")]
    public float Sentakusi1_Result3_Probability;
    [Header("�I����1����4")]
    public string Sentakusi1_Result4;
    [Header("�I����1����4�m��")]
    public float Sentakusi1_Result4_Probability;
    [Header("�I����1����5")]
    public string Sentakusi1_Result5;
    [Header("�I����1����5�m��")]
    public float Sentakusi1_Result5_Probability;
    [Header("�I����2����1")]
    public string Sentakusi2_Result1;
    [Header("�I����2����1�m��")]
    public float Sentakusi2_Result1_Probability;
    [Header("�I����2����2")]
    public string Sentakusi2_Result2;
    [Header("�I����2����2�m��")]
    public float Sentakusi2_Result2_Probability;
    [Header("�I����2����3")]
    public string Sentakusi2_Result3;
    [Header("�I����2����3�m��")]
    public float Sentakusi2_Result3_Probability;
    [Header("�I����2����4")]
    public string Sentakusi2_Result4;
    [Header("�I����2����4�m��")]
    public float Sentakusi2_Result4_Probability;
    [Header("�I����2����5")]
    public string Sentakusi2_Result5;
    [Header("�I����2����5�m��")]
    public float Sentakusi2_Result5_Probability;
    [Header("�L�����Z������")]
    public string Cancel_Result;
}
