using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Button_10112 : MonoBehaviour
{
    Button button;
    void Start()
    {
        button = GetComponent<Button>();
        button.interactable = PlayerInfo.Instance.Inventry.GetItemAmount(Items.Item_ID.item_craft_smoke) >= 1;
    }
}
