using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventry : SingletonMonoBehaviour<Inventry>
{
    [SerializeField] private List<Items> Item_Datas;
    [SerializeField] private GameObject slot_manager_object;
    [SerializeField] private GameObject mouse_image_object;
    [HideInInspector] public SlotManager slot_manager;

    private (Items item, int? _slot_index) dragging_item_data;
    private Image dragging_item_image = null;

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
        dragging_item_image = mouse_image_object.GetComponent<Image>();
        mouse_image_object.SetActive(false);
        dragging_item_data.item = null;
        dragging_item_data._slot_index = null;
        if (Item_Datas.Count != (int)Items.Item_ID.Item_Max)
        {
            Debug.Log("アイテムデータに登録された個数が一致しません");
        }

    }
    private void Update()
    {
        if (dragging_item_image.sprite)
        {
            mouse_image_object.transform.position = Input.mousePosition;
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

    public void OnItemDropInSlot()
    {

    }
    public void SetDraggingItem(Items dragged_item,int? index)
    {
       if(dragged_item && index.HasValue)
        {
            mouse_image_object.SetActive(true);
            dragging_item_data.item = dragged_item;
            dragging_item_data._slot_index = (int)index;
            dragging_item_image.sprite = dragged_item.icon;
        }
        else
        {
            mouse_image_object.SetActive(false);
            mouse_image_object.transform.position = new Vector3(-1000, -1000, 0);
            dragging_item_data.item = null;
            dragging_item_data._slot_index = null;
            dragging_item_image.sprite = null;
        }
    }

    public (Items item,int? index) GetDraggingData()
    {
        return dragging_item_data;
    }
}
