using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MyScriptable/Create EventData")]
public class EventData : ScriptableObject
{
    [Header("イベントID")]
    public int Event_ID;
    [Header("背景")]
    public Sprite Event_BG;
    [Header("イベントイラスト")]
    public Sprite Event_Ilast;
    [Header("イベントタイトル")]
    public string Event_Title;
    [Header("テキスト本文")]
    public string Main_Text;
    [Header("選択肢１")]
    public string Sentakusi1;
    [Header("選択肢２")]
    public string Sentakusi2;
    [Header("キャンセル")]
    public string Cancel;
    [Header("選択肢1結果")]
    public string Sentakusi1_Result1;
    [Header("選択肢1条件ID")]
    public int Sentakusi1_Zyouken;
    [Header("選択肢1条件の個数")]
    public int Sentakusi1_Zyouken_num;
    [Header("報酬アイテムID")]
    public int Sentakusi1_Reward1;
    [Header("報酬アイテムの個数")]
    public int Sentakusi1_Reward1_num;
    [Header("報酬アイテムID")]
    public int Sentakusi1_Reward2;
    [Header("報酬アイテムの個数")]
    public int Sentakusi1_Reward2_num;
    [Header("報酬アイテムID")]
    public int Sentakusi1_Reward3;
    [Header("報酬アイテムの個数")]
    public int Sentakusi1_Reward3_num;
    [Header("報酬アイテムID")]
    public int Sentakusi1_Reward4;
    [Header("報酬アイテムの個数")]
    public int Sentakusi1_Reward4_num;
    [Header("報酬アイテムID")]
    public int Sentakusi1_Reward5;
    [Header("報酬アイテムの個数")]
    public int Sentakusi1_Reward5_num;
    [Header("報酬アイテムID")]
    public int Sentakusi1_Reward6;
    [Header("報酬アイテムの個数")]
    public int Sentakusi1_Reward6_num;
    [Header("次のイベントID")]
    public int Sentakusi1_Next_Ivent_ID;
    [Header("選択肢2結果1")]
    public string Sentakusi2_Result1;
    [Header("選択肢2条件ID")]
    public int Sentakusi2_Zyouken;
    [Header("選択肢2条件の個数")]
    public int Sentakusi2_Zyouken_num;
    [Header("報酬アイテムID")]
    public int Sentakusi2_Reward;
    [Header("報酬アイテムの個数")]
    public int Sentakusi2_Reward_num;
    [Header("次のイベントID")]
    public int Sentakusi2_Next_Ivent_ID;
    [Header("キャンセル結果")]
    public string Cancel_Result;
    [Header("次のイベントID")]
    public int Cancel_Next_Ivent_ID;

#if UNITY_EDITOR
    public void SetEventData(int eventID, string eventTitle, string mainText, string sentakushi1, string sentakussi2, string cansel,
                            string sentakusi1Result1, int sentakusi1NextIventID, string sentakusi1Result2, int sentakusi2NextIventID,
                            string cancelResult, int cancelNextIventID)
    {
        this.Event_ID = eventID;
        this.Event_Title = eventTitle;
        this.Main_Text = mainText;
        this.Sentakusi1 = sentakushi1;
        this.Sentakusi2 = sentakussi2;
        this.Cancel = cansel;
        this.Sentakusi1_Result1 = sentakusi1Result1;
        this.Sentakusi1_Next_Ivent_ID = sentakusi1NextIventID;
        this.Sentakusi2_Result1 = sentakusi1Result2;
        this.Sentakusi2_Next_Ivent_ID = sentakusi2NextIventID;
        this.Cancel_Result = cancelResult; 
        this.Cancel_Next_Ivent_ID = cancelNextIventID;
    }
#endif
}
