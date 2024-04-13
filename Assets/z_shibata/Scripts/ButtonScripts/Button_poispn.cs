using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button_poispn : MonoBehaviour
{
    Button button;
    [SerializeField, Range(0, 1)] float poisonProbability = 0.5f;
    void Start()
    {
        button = GetComponent<Button>();
        //クリック後ボトル-1、指定％で毒状態
        bool poison = Random.value <= poisonProbability;
        if(poison)
        {
           gameObject.GetComponent<Button>().onClick.AddListener(() =>
                 { PlayerInfo.Instance.AddPlayerCondition(PlayerInfo.Condition.Poisoned); });
            
        }        
    }
}

