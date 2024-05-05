using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaterPanel : PanelBase
{
    [SerializeField]
    Text water_value_text;
    [SerializeField]
    Text spring_water_text;
    [SerializeField]
    Button DrinkButton;
    [SerializeField]
    Button PourButton;
    [SerializeField]
    int waterAmountPerOnce = 10;

    PlayerInfo info;
    // Start is called before the first frame update
    protected override void Start()
    {
        info = PlayerInfo.Instance;
        SetSortOrder(OrderOfUI.NormalPanel);
        DrinkButton.onClick.AddListener(DrinkWater);
        PourButton.onClick.AddListener(PourWater);
        
    }

    
    protected override void Update()
    {
        int prev = info.Thirst;
        water_value_text.text = $"<b>{prev}% ÅÀ {Mathf.Clamp(prev + waterAmountPerOnce, 0, 100)}%</b>";
        spring_water_text.text = $"íôêÖ : {info.Water}";

        PourButton.interactable = PlayerInfo.Instance.Water >= 30 &&
                                    PlayerInfo.Instance.Inventry.GetItemAmount(Items.Item_ID.item_mat_bottle) >= 1;
        DrinkButton.interactable = info.Water >= waterAmountPerOnce;
    }

    void DrinkWater()
    {

        if(info.Thirst + waterAmountPerOnce >= 100)
        {
            info.Water -= 100 - info.Thirst;
            info.Thirst = 100;
        }
        else
        {
            info.Thirst += waterAmountPerOnce;
            info.Water -= waterAmountPerOnce;
        }
    }

    void PourWater()
    {
        PlayerInfo.Instance.Water -= 30;
        PlayerInfo.Instance.Inventry.UseItem(Items.Item_ID.item_mat_bottle);
        PlayerInfo.Instance.Inventry.GetItem(Items.Item_ID.item_craft_water,1);

    }

    
}
