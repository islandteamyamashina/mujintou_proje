using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObj_Item")]
public class SO_Item : ScriptableObject
{
    public int itemID;
    public int stackCount;
    public string itemName;
    public string itemInfo;
    public bool isCraftingItem;
    [Header("必要なアイテムのID")]
    public int firstID;
    public int secondID,ThirdID;
    [Header("必要な個数")]
    public int fItemCount;
    public int sItemCount, tItemCount;

    public int GetItemID()
    {
        return itemID;
    }
    public int GetStackCount()
    {
        return stackCount;
    }
}
