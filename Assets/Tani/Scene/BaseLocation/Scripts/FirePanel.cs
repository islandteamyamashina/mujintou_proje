using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirePanel : PanelBase
{
    [SerializeField]
    Text fire_value_text;
    [SerializeField]
    Button AddFireButton;
    [SerializeField]
    Button MakeFireButton;
    [SerializeField]
    Button ToCookingButton;

    protected override void Start()
    {
        SetSortOrder(OrderOfUI.NormalPanel);    
    }

   
    protected override void Update()
    {
        fire_value_text.text = "���Βl : " + PlayerInfo.Instance.Fire.ToString();
        
        AddFireButton.interactable = PlayerInfo.Instance.Fire != 100 && PlayerInfo.Instance.Fire != 0;
        MakeFireButton.interactable = PlayerInfo.Instance.Fire == 0 && PlayerInfo.Instance.ActionValue >= 3;
        ToCookingButton.interactable = PlayerInfo.Instance.Fire != 0;
    }

    public void AddFire()
    {
        //�}����{����鏈��
        PlayerInfo.Instance.Fire += 10;
    }

    public void MakeFire()
    {
        //�}���O�{����鏈��
        var info = PlayerInfo.Instance;
        info.Health -= 20;
        info.Thirst -= 10;
        info.Hunger -= 10;
        info.Fire = 30;
        info.ActionValue -= 3;
    }
}
