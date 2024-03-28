using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestPanel : PanelBase
{
    [SerializeField]
    Button rest_button;
    [SerializeField]
    bool isDayTime = true;
    protected override void Start()
    {

        SetSortOrder(OrderOfUI.NormalPanel);
        rest_button.onClick.AddListener(Rest);
    }


    protected override void Update()
    {

    }

    void Rest()
    {

        PlayerInfo.Instance.DoAction();
        PlayerInfo.Instance.Health += 30;
        PlayerInfo.Instance.Hunger -= 30;
        PlayerInfo.Instance.Thirst -= 40;
        PlayerInfo.Instance.ActionValue = PlayerInfo.Instance.MaxActionValue;
        if (isDayTime)
        {
            GameObject.FindWithTag("GameController").GetComponent<BaseLocationDaytimeController>().ChangeBaseLocation();
        }
        else
        {
            GameObject.FindWithTag("GameController").GetComponent<BaseLocationNightController>().ChangeBaseLocation();
        }
        
    }

}
