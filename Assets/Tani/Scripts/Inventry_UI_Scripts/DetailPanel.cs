using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;

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
    [SerializeField]
    Button Use_Button;
    [SerializeField]
    List<Items.Item_ID> foodsForActionValueIncrease;

    Items.Item_ID current_id = Items.Item_ID.Item_Max;
    string foodUsageLogForActionValueIncrease_textName = "FoodUsageLog.txt";
    string fullPath;
    bool[] foodUsageLog = null;
    private void Awake()
    {
        fullPath = Application.streamingAssetsPath + "/Saves/" + foodUsageLogForActionValueIncrease_textName;
        foodUsageLog = new bool[foodsForActionValueIncrease.Count];
        Use_Button.onClick.AddListener(() => 
        { 
            SlotManager.selectedItem.slotManager.UseSlotItem(SlotManager.selectedItem.index);
            CheckFoodNotUsed(current_id);
        });
    }

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
            Use_Button.interactable = item_data.canUse ;
        }
        else
        {

            effect_text.text = null;
            discription_text.text = null;
            ItemName.text = null;
            icon_image.sprite = null;
            icon_image.color = new Color(1, 1, 1, 0);
            current_id = Items.Item_ID.Item_Max;
            Use_Button.interactable = false;
        }
    }

    //指定したアイテムが行動値を増加させるアイテムでかつ使ったことがなければtrue
    bool CheckFoodNotUsed(Items.Item_ID id)
    {
        if (!File.Exists(fullPath))
        {
            MakeFoodUsageLog(null);
        }
        string rawText = File.ReadAllText(fullPath);
        print(rawText);
        
        int start = 0;
        for(int i = 0;i < rawText.Length;i++)
        {
            if(rawText[i] ==char.Parse(":"))
            {
                if(int.Parse( rawText.AsSpan()[start..i]) ==(int)id)
                {
                    start = i + 1;
                    return int.Parse(rawText.AsSpan()[start..(start + 1)]) != 0;
                }
            }

            
            
        }

        return false;
    }
    void MakeFoodUsageLog(bool[] log)
    {
        if (log == null)
        {
            string text = string.Empty;
            foreach(Items.Item_ID id in foodsForActionValueIncrease)
            {
                text += ((int)id).ToString() + ":" + "1\n";
            }
            File.WriteAllText(fullPath, text);
            return;
        }

        string str = string.Empty;
       
        for (int i = 0; i < foodsForActionValueIncrease.Count; i++)
        {
            str += ((int)foodsForActionValueIncrease[i]).ToString() + ":" + $"{log[i]}\n";
        }
        return;

    }


}
