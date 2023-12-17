using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class test1 : MonoBehaviour
{

    PlayerInfo player;
    void Start()
    {
        player = PlayerInfo.Instance;
        PlayerInfo.Instance.Health -= 50;
    }


    void Update()
    {
        Debug.Log(PlayerInfo.Instance.Hunger);
    }
}
