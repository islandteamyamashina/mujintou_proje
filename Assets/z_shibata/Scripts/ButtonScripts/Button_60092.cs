using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button_60092 : MonoBehaviour
{
    Button button;
    void Start()
    {
        button = GetComponent<Button>();
        button.interactable = PlayerInfo.Instance.Inventry.GetItemAmount(Items.Item_ID.item_craft_bakedBird) >= 1;

        gameObject.GetComponent<Button>().onClick.AddListener(() =>
        { PlayerInfo.Instance.Inventry.UseItem(Items.Item_ID.item_craft_bakedBird); });
    }
}
