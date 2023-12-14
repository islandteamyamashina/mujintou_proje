using NovelGame;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class Sentakusi_Maneger : Event_Text_Controler
{
    [SerializeField] TextMeshProUGUI _EventTextObject;

    [SerializeField] TextMeshProUGUI _sentakusiTextObject1;
    [SerializeField] TextMeshProUGUI _sentakusiTextObject2;
    [SerializeField] TextMeshProUGUI _sentakusiTextObject3;

    //[SerializeField] TextMeshProUGUI _eventTextObject;
    [SerializeField] GameObject _sentakusi1;
    [SerializeField] GameObject _sentakusi2;
    [SerializeField] GameObject _sentakusi3;

    // Start is called before the first frame update

    public void Push_Sentakusi1()
    {
        Display_Event_Text(5);
        _sentakusi2.SetActive(false);
        _sentakusi3.SetActive(false);
    }

    public void Push_Sentakusi2()
    {
        Display_Event_Text(10);
        _sentakusi1.SetActive(false);
        _sentakusi3.SetActive(false);
    }

    public void Push_Sentakusi3()
    {
        Display_Event_Text(15);
        _sentakusi1.SetActive(false);
        _sentakusi2.SetActive(false);
    }

    void Display_Event_Text(int Line_Num)
    {
        string sentence = Game_Manager.Instance.userScriptManager.Get_Choice_Current_Sentence(Line_Num);
        _EventTextObject.text = sentence;
    } 
     void Update()
    {
        Disply_One_Character(_EventTextObject);
    }

   public void Set_Sentakusi_Words(string Words1, string Words2, string Words3)
    {
        _sentakusiTextObject1.text = Words1;
        _sentakusiTextObject2.text = Words2;
        _sentakusiTextObject3.text = Words3;
    }

}
