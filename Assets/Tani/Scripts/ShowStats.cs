using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowStats : MonoBehaviour
{
    Text text = null;
    
    
    void Start()
    {
        text = GetComponent<Text>();
    }



    private void Update()
    {
        text.text = "Health : " + PlayerInfo.Instance.Health + "  " +
                "Hunger : " + PlayerInfo.Instance.Hunger + "  " +
                "Thirst : " + PlayerInfo.Instance.Thirst;
    }
}
