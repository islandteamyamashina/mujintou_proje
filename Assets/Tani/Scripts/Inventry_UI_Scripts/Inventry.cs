using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventry : SingletonMonoBehaviour<Inventry>
{
    [SerializeField] private List<Items> Item_Datas;
    [SerializeField] private GameObject slot_manager_object;
    [HideInInspector] public SlotManager slot_manager;


    protected override void Awake() 
    {
        base.Awake();
        if(!slot_manager_object.TryGetComponent<SlotManager>(out slot_manager))
        {
            Debug.Log("Erorr Get Slot_Manager_");
        }
        
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
        Debug.Log($"slotindex : {slotIndex} , item_id : {slot_manager.GetSlots()[slotIndex].GetItem().item_ID}");
        
        
    }

    public void OnItemChanged(int index)
    {
        slot_manager.OnItemChanged(index);
    }

}
