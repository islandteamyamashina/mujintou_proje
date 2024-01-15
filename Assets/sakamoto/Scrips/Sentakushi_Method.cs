
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Sentakushi_Method : Event_Text
{
    [SerializeField] Text _sentakusiTextObject1;
    [SerializeField] Text _sentakusiTextObject2;
    [SerializeField] Text _sentakusiTextObject3;

    //[SerializeField] TextMeshProUGUI _eventTextObject;
    [SerializeField] GameObject _sentakusi1;
    [SerializeField] GameObject _sentakusi2;
    [SerializeField] GameObject _sentakusi3;

    int[] Result_tam;
    int Result_Num;
    bool GoToLoadScene;
    // Start is called before the first frame update

    private void Start()
    {
        Result_Num = 0;
        Set_Sentakusi_Words(eventData.Sentakusi1, eventData.Sentakusi2, eventData.Cancel);
        GoToLoadScene = false;
    }
    private void Update()
    {
        if (GoToLoadScene)
        {
            if (Input.GetMouseButton(0))
            {
                SceneManager.LoadScene("Event_Load");
            }
        }
    }
    public void Push_Sentakusi1()
    {
        Choise_Result1();
        if (Result_Num == 1)
        {
            Text_Disply(eventData.Sentakusi1_Result1);

            //int tnp = Random.Range(eventData.GetRope_min, eventData.GetRope_max);
            //for (int i = 0; i < tnp; i++)
            //{
            //    Debug.Log("ボロボロのロープを手に入れた。");
            //}

        }
        if (Result_Num == 2)
        {
            Text_Disply(eventData.Sentakusi1_Result2);
        }
        if (Result_Num == 3)
        {
            Text_Disply(eventData.Sentakusi1_Result3);
        }
        if (Result_Num == 4)
        {
            Text_Disply(eventData.Sentakusi1_Result4);
        }
        if (Result_Num == 5)
        {
            Text_Disply(eventData.Sentakusi1_Result5);
        }
        _sentakusi2.SetActive(false);
        _sentakusi3.SetActive(false);
        GoToLoadScene = true;
    }

    public void Push_Sentakusi2()
    {
        Choise_Result2();
        if (Result_Num == 1)
        {
            Text_Disply(eventData.Sentakusi2_Result1);
        }
        if (Result_Num == 2)
        {
            Text_Disply(eventData.Sentakusi2_Result2);
        }
        if (Result_Num == 3)
        {
            Text_Disply(eventData.Sentakusi2_Result3);
        }
        if (Result_Num == 4)
        {
            Text_Disply(eventData.Sentakusi2_Result4);
        }
        if (Result_Num == 5)
        {
            Text_Disply(eventData.Sentakusi2_Result5);
        }
        _sentakusi1.SetActive(false);
        _sentakusi3.SetActive(false);
        GoToLoadScene = true;
    }

    public void Push_Sentakusi3()
    {
        Text_Disply(eventData.Cancel_Result);
        _sentakusi1.SetActive(false);
        _sentakusi2.SetActive(false);
        GoToLoadScene = true;
    }

    public void Set_Sentakusi_Words(string Words1, string Words2, string Words3)
    {
        _sentakusiTextObject1.text = Words1;
        _sentakusiTextObject2.text = Words2;
        _sentakusiTextObject3.text = Words3;
    }

    //選択肢１を押したとき
    void Choise_Result1()
    {
        int Max_Probability = eventData.Sentakusi1_Result1_Probability + eventData.Sentakusi1_Result2_Probability + eventData.Sentakusi1_Result3_Probability +
                                eventData.Sentakusi1_Result4_Probability + eventData.Sentakusi1_Result5_Probability;

        Result_tam = new int[Max_Probability];

        for (int i = 0; i < Max_Probability; i++)
        {
            if (i < eventData.Sentakusi1_Result1_Probability)
            {
                Result_tam[i] = 1;
            }
            else if (i < eventData.Sentakusi1_Result1_Probability + eventData.Sentakusi1_Result2_Probability)
            {
                Result_tam[i] = 2;
            }
            else if (i < eventData.Sentakusi1_Result1_Probability + eventData.Sentakusi1_Result2_Probability + eventData.Sentakusi1_Result3_Probability)
            {
                Result_tam[i] = 3;
            }
            else if (i < eventData.Sentakusi1_Result1_Probability + eventData.Sentakusi1_Result2_Probability + eventData.Sentakusi1_Result3_Probability + eventData.Sentakusi1_Result4_Probability)
            {
                Result_tam[i] = 4;
            }
            else if (i < eventData.Sentakusi1_Result1_Probability + eventData.Sentakusi1_Result2_Probability + eventData.Sentakusi1_Result3_Probability + eventData.Sentakusi1_Result4_Probability + eventData.Sentakusi1_Result5_Probability)
            {
                Result_tam[i] = 5;
            }
        }
        int Result_num_tnp = Random.Range(0, Max_Probability);
        Result_Num = Result_tam[Result_num_tnp];
    }

    //選択肢2を押したとき
    void Choise_Result2()
    {
        int Max_Probability = eventData.Sentakusi2_Result1_Probability + eventData.Sentakusi2_Result2_Probability + eventData.Sentakusi2_Result3_Probability +
                                eventData.Sentakusi2_Result4_Probability + eventData.Sentakusi2_Result5_Probability;

        Result_tam = new int[Max_Probability];

        for (int i = 0; i < Max_Probability; i++)
        {
            if (i < eventData.Sentakusi2_Result1_Probability)
            {
                Result_tam[i] = 1;
            }
            else if (i < eventData.Sentakusi2_Result1_Probability + eventData.Sentakusi2_Result2_Probability)
            {
                Result_tam[i] = 2;
            }
            else if (i < eventData.Sentakusi2_Result1_Probability + eventData.Sentakusi2_Result2_Probability + eventData.Sentakusi2_Result3_Probability)
            {
                Result_tam[i] = 3;
            }
            else if (i < eventData.Sentakusi2_Result1_Probability + eventData.Sentakusi2_Result2_Probability + eventData.Sentakusi2_Result3_Probability + eventData.Sentakusi2_Result4_Probability)
            {
                Result_tam[i] = 4;
            }
            else if (i < eventData.Sentakusi2_Result1_Probability + eventData.Sentakusi2_Result2_Probability + eventData.Sentakusi2_Result3_Probability + eventData.Sentakusi2_Result4_Probability + eventData.Sentakusi2_Result5_Probability)
            {
                Result_tam[i] = 5;
            }
        }
        int Result_num_tnp = Random.Range(0, Max_Probability);
        Result_Num = Result_tam[Result_num_tnp];
    }
}
