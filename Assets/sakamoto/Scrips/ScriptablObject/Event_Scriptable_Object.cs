using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MyScriptable/Create EventData")]
public class EventData : ScriptableObject
{
    [Header("CxgID")]
    public int Event_ID;
    [Header("wi")]
    public Sprite Event_BG;
    [Header("CxgCXg")]
    public Sprite Event_Ilast;
    [Header("Cxg^Cg")]
    public string Event_Title;
    [Header("eLXg{¶")]
    public string Main_Text;
    [Header("IðP")]
    public string Sentakusi1;
    [Header("IðQ")]
    public string Sentakusi2;
    [Header("LZ")]
    public string Cancel;
    [Header("Ið1Ê")]
    public string Sentakusi1_Result1;
    [Header("Ið1ðID")]
    public int Sentakusi1_Zyouken;
    [Header("Ið1ðÌÂ")]
    public int Sentakusi1_Zyouken_num;
    [Header("ñVACeID")]
    public int Sentakusi1_Reward;
    [Header("ñVACeÌÂ")]
    public int Sentakusi1_Reward_num;
    [Header("ÌCxgID")]
    public int Sentakusi1_Next_Ivent_ID;
    [Header("Ið2Ê1")]
    public string Sentakusi2_Result1;
    [Header("Ið2ðID")]
    public int Sentakusi2_Zyouken;
    [Header("Ið2ðÌÂ")]
    public int Sentakusi2_Zyouken_num;
    [Header("ñVACeID")]
    public int Sentakusi2_Reward;
    [Header("ñVACeÌÂ")]
    public int Sentakusi2_Reward_num;
    [Header("ÌCxgID")]
    public int Sentakusi2_Next_Ivent_ID;
    [Header("LZÊ")]
    public string Cancel_Result;
    [Header("ÌCxgID")]
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
