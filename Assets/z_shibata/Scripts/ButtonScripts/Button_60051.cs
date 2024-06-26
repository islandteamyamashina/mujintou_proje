using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button_60051 : MonoBehaviour
{
    Button button;
    void Start()
    {
        button = GetComponent<Button>();
        //アイテム判別してボタンを消す
        if(PlayerInfo.Instance.Inventry.GetItemAmount(Items.Item_ID.item_craft_water) >= 1 || PlayerInfo.Instance.Inventry.GetItemAmount(Items.Item_ID.item_craft_water2) >= 1)
        {
            button.interactable = true;
        }
        else if (PlayerInfo.Instance.Inventry.GetItemAmount(Items.Item_ID.item_craft_water) < 1 || PlayerInfo.Instance.Inventry.GetItemAmount(Items.Item_ID.item_craft_water2) < 1)
        {
            button.interactable = false;
        }

        //使ったアイテムを減らす処理
        if (PlayerInfo.Instance.Inventry.GetItemAmount(Items.Item_ID.item_craft_water) >= 1)
        {
            gameObject.GetComponent<Button>().onClick.AddListener(() =>
            { PlayerInfo.Instance.Inventry.UseItem(Items.Item_ID.item_craft_water); });
        }
        else if(PlayerInfo.Instance.Inventry.GetItemAmount(Items.Item_ID.item_craft_water2) >= 1 && PlayerInfo.Instance.Inventry.GetItemAmount(Items.Item_ID.item_craft_water) < 1)
        {
            gameObject.GetComponent<Button>().onClick.AddListener(() =>
            { PlayerInfo.Instance.Inventry.UseItem(Items.Item_ID.item_craft_water2); });
        }

        
    }

}
