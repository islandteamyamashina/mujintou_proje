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

    Items.Item_ID current_id = Items.Item_ID.Item_Max;

    private void FixedUpdate()
    {
        if (SlotManager.selectedItem.slotManager)
        {
            //指定したスロットにアイテムがなければreturn
            if (!SlotManager.selectedItem.slotManager.GetSlotItem(SlotManager.selectedItem.index).HasValue) return;
            
            Items.Item_ID id = SlotManager.selectedItem.slotManager.GetSlotItem(SlotManager.selectedItem.index).Value.id;
            //idがemptyならreturn
            if (id == Items.Item_ID.EmptyObject) return;

            var item_data = SlotManager.GetItemData(id);
            
            //idが同じならreturnl
            if (item_data.item_ID == current_id) return;

            if (item_data.canUse)
            {
                effect_text.text = (item_data.Health_Change > 0 ? $"体力 : +{item_data.Health_Change}" : $"体力 : {item_data.Health_Change}") +" "+
                               (item_data.Hunger_Change > 0 ? $"食料 : +{item_data.Hunger_Change}" : $"食料 : {item_data.Hunger_Change}" ) + " " +
                               (item_data.Thirst_Chage > 0 ? $"水分 : +{item_data.Thirst_Chage}" : $"水分 : {item_data.Thirst_Chage}") + "\n" +
                                item_data.extra_effect;

            }
            else
            {
                effect_text.text = "使用できない";
            }

            discription_text.text = item_data.Discription;
            icon_image.sprite = item_data.icon;
            icon_image.color = new Color(1, 1, 1, 1);
            ItemName.text = item_data.item_name;

            current_id = item_data.item_ID;
        }
        else
        {

            effect_text.text = null;
            discription_text.text = null;
            ItemName.text = null;
            icon_image.sprite = null;
            icon_image.color = new Color(1, 1, 1, 0);
        }
    }


}
