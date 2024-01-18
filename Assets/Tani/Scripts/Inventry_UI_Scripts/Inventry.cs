using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventry : SingletonMonoBehaviour<Inventry>
{
    [SerializeField] private List<Items> Item_Datas;



    protected override void Awake() 
    {
        base.Awake();
    }

    void Start()
    {

        if (Item_Datas.Count != (int)Items.Item_ID.Item_Max)
        {
            Debug.Log("アイテムデータに登録された個数が一致しません");
        }


        
    }

    public Items GetItemData(Items.Item_ID id)
    {
        foreach (var n in Item_Datas)
        {
            if (n.item_ID == id) return n;
        }

        return null;
    }

    public void OnSlotSelected(int slotIndex)
    {
        Debug.Log($"slotindex : {slotIndex}");
        
    }

}
