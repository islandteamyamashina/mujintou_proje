using NovelGame;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Sentakusi_Maneger : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _eventTxstObject;
    // Start is called before the first frame update

    public void Push_Sentakusi1()
    {
        Display_Event_Text(5);
    }

    public void Push_Sentakusi2()
    {
        Display_Event_Text(10);
    }

    public void Push_Sentakusi3()
    {
        Display_Event_Text(15);
    }

    void Display_Event_Text(int Line_Num)
    {
        string sentence = Game_Manager.Instance.userScriptManager.Get_Choice_Current_Sentence(Line_Num);
        _eventTxstObject.text = sentence;
    }
}
