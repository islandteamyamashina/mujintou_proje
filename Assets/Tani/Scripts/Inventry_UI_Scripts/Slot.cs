using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour
{
    private Image _image;
    private Items _item;
    [SerializeField] private int _slot_Index = -1;

    //private void Awake()
    //{
    //    _image = gameObject.transform.GetChild(0).gameObject.GetComponent<Image>();
    //    _item = Inventry.Instance.GetItemData(Items.Item_ID.EmptyObject);

    //}
    //void Start()
    //{
    //    if (_slot_Index == -1) { Debug.Log("Slot Index Erorr"); }
    //    EventTrigger eventTrigger = gameObject.GetComponent<EventTrigger>();
    //    EventTrigger.Entry entry = new EventTrigger.Entry();
    //    EventTrigger.Entry entry1 = new EventTrigger.Entry();
    //    EventTrigger.Entry entry2 = new EventTrigger.Entry();

    //    entry.eventID = EventTriggerType.PointerClick;
    //    entry1.eventID = EventTriggerType.BeginDrag;
    //    entry2.eventID = EventTriggerType.Drop;

    //    entry.callback.AddListener((data) => { OnSlotSelected(_slot_Index); });
    //    entry1.callback.AddListener((data) => { OnSlotStartDrag(_slot_Index); });
    //    entry2.callback.AddListener((data) => { OnSlotDrop(_slot_Index); });
    //    eventTrigger.triggers.Add(entry);
    //    eventTrigger.triggers.Add(entry1);
    //    eventTrigger.triggers.Add(entry2);
    //}


    //public void SetItemToSlot(Items inItem)
    //{

    //    if (inItem.item_ID != Items.Item_ID.EmptyObject)
    //    {
    //        _item = inItem;
    //        _image.sprite = inItem.icon;
    //        _image.color = new Color(_image.color.r, _image.color.g, _image.color.b, 1);
    //    }
    //    else
    //    {
    //        _item = inItem;
    //        _image.sprite = null;
    //        _image.color = new Color(_image.color.r, _image.color.g, _image.color.b, 0);
    //    }
    //}

    //public bool SlotHasItem()
    //{
    //    return _item.item_ID != Items.Item_ID.EmptyObject;
    //}

    //public Items GetItem()
    //{
    //    return _item;
    //}

    //public void OnSlotSelected(int slotIndex)
    //{
    //    Inventry.Instance.OnSlotSelected(slotIndex);
    //}
    //public int GetSlotIndex() { return _slot_Index; }

    //public void OnSlotStartDrag(int index)
    //{
    //    Debug.Log($"Begin Drag : {index}");
    //    Inventry.Instance.SetDraggingItem(_item, _slot_Index);
    //    SetItemToSlot(Inventry.Instance.GetItemData(Items.Item_ID.EmptyObject));


    //}

    //public void OnSlotDrop(int index)
    //{
    //    Debug.Log($"Drop : {index}");
    //    Inventry.Instance.slot_manager.GetSlots()[(int)Inventry.Instance.GetDraggingData().index]
    //        .SetItemToSlot(Inventry.Instance.GetDraggingData().item);

    //}
}
