using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetailPanel : MonoBehaviour
{
    [SerializeField]
    Text effect_text;
    [SerializeField]
    Text discription_text;
    [SerializeField]
    Text ItemName;
    [SerializeField]
    Image icon_image;

    Items.Item_ID current_id = Items.Item_ID.EmptyObject;

    private void FixedUpdate()
    {
        print(SlotManager.selectedItem);
        if (SlotManager.selectedItem.HasValue)
        {
            var item = SlotManager.selectedItem.Value;
            if (!item.slotManager.GetSlotItem(item.index).HasValue) return;
            
            Items.Item_ID id =  item.slotManager.GetSlotItem(item.index).Value.id;
            if (id == Items.Item_ID.EmptyObject) return;

            var item_data = Resources.Load($"{id}") as Items;
            if (item_data == null)
            {
                Debug.LogError($"Couldn't find Item Data : {id} in Resources");
                return;
            }
            if(item_data.item_ID != current_id)
            {
                effect_text.text = item_data.extra_effect;
                discription_text.text = item_data.Discription;
                icon_image.sprite = item_data.icon;
                current_id = item_data.item_ID;
                ItemName.text = item_data.item_name;
            }
        }
        else
        {
            effect_text.text = null;
            discription_text.text = null;
            ItemName.text = null;
            icon_image.sprite = null;
        }
    }


}
