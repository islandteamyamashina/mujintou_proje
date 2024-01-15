using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MyScriptable/Create EventData")]
public class EventData : ScriptableObject
{
    [Header("イベントフラグ")]
    public bool Event_Flag;
    [Header("イベントナンバー")]
    public int Event_Num;
    [Header("背景")]
    public Sprite Event_BG;
    [Header("イベントイラスト")]
    public Sprite Event_Ilast;
    [Header("イベントタイトル")]
    public string Event_Title;
    [Header("発生場所")]
    public int Place;
    [Header("確率の重み")]
    public int Probability;
    [Header("発生条件")]
    public int Conditions;
    [Header("テキスト本文")]
    public string Main_Text;
    [Header("選択肢１")]
    public string Sentakusi1;
    [Header("選択肢２")]
    public string Sentakusi2;
    [Header("キャンセル")]
    public string Cancel;
    [Header("選択肢1結果1")]
    public string Sentakusi1_Result1;
    [Header("選択肢1結果1確率")]
    public int Sentakusi1_Result1_Probability;

    //[Header("石の取得数 max")]
    //public int 1_1GetRope_max;
    //[Header("石の取得数 min")]
    //public int GetRope_min;
    //[Header("枝の取得数 max")]
    //public int GetRope_max;
    //[Header("枝の取得数 min")]
    //public int GetRope_min;
    //[Header("小さいカニの取得数 max")]
    //public int GetRope_max;
    //[Header("小さいカニの取得数 min")]
    //public int GetRope_min;
    //[Header("小さい巻貝の取得数 max")]
    //public int GetRope_max;
    //[Header("小さい巻貝の取得数 min")]
    //public int GetRope_min;
    //[Header("ココナッツの取得数 max")]
    //public int GetRope_max;
    //[Header("ココナッツの取得数 min")]
    //public int GetRope_min;
    //[Header("空のボトルの取得数 max")]
    //public int GetRope_max;
    //[Header("空のボトルの取得数 min")]
    //public int GetRope_min;
    //[Header("ボロボロの縄の取得数 max")]
    //public int GetRope_max;
    //[Header("ボロボロの縄の取得数 min")]
    //public int GetRope_min;
    //[Header("ヤシガラの取得数 max")]
    //public int GetRope_max;
    //[Header("ヤシガラの取得数 min")]
    //public int GetRope_min;
    //[Header("フルーツの取得数 max")]
    //public int GetRope_max;
    //[Header("フルーツの取得数 min")]
    //public int GetRope_min;
    //[Header("小ぶりなイモの取得数 max")]
    //public int GetRope_max;
    //[Header("小ぶりなイモの取得数 min")]
    //public int GetRope_min;
    //[Header("ボロ布の取得数 max")]
    //public int GetRope_max;
    //[Header("ボロ布の取得数 min")]
    //public int GetRope_min;

    [Header("選択肢1結果2")]
    public string Sentakusi1_Result2;
    [Header("選択肢1結果2確率")]
    public int Sentakusi1_Result2_Probability;
    [Header("選択肢1結果3")]
    public string Sentakusi1_Result3;
    [Header("選択肢1結果3確率")]
    public int Sentakusi1_Result3_Probability;
    [Header("選択肢1結果4")]
    public string Sentakusi1_Result4;
    [Header("選択肢1結果4確率")]
    public int Sentakusi1_Result4_Probability;
    [Header("選択肢1結果5")]
    public string Sentakusi1_Result5;
    [Header("選択肢1結果5確率")]
    public int Sentakusi1_Result5_Probability;
    [Header("選択肢2結果1")]
    public string Sentakusi2_Result1;
    [Header("選択肢2結果1確率")]
    public int Sentakusi2_Result1_Probability;
    [Header("選択肢2結果2")]
    public string Sentakusi2_Result2;
    [Header("選択肢2結果2確率")]
    public int Sentakusi2_Result2_Probability;
    [Header("選択肢2結果3")]
    public string Sentakusi2_Result3;
    [Header("選択肢2結果3確率")]
    public int Sentakusi2_Result3_Probability;
    [Header("選択肢2結果4")]
    public string Sentakusi2_Result4;
    [Header("選択肢2結果4確率")]
    public int Sentakusi2_Result4_Probability;
    [Header("選択肢2結果5")]
    public string Sentakusi2_Result5;
    [Header("選択肢2結果5確率")]
    public int Sentakusi2_Result5_Probability;
    [Header("キャンセル結果")]
    public string Cancel_Result;
}
