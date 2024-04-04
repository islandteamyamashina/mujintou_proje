using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(EventTrigger)),RequireComponent((typeof(Selectable)))]
public class Slot : MonoBehaviour,ISelectHandler,IDeselectHandler
{
    [HideInInspector]
    static public string slot_tag_name = "Slot";
    public int Slot_index { get; set; } = -1;
    public SlotManager Affiliation { get; set; } = null;
    [SerializeField]
    Image item_icon_object = null;
    [SerializeField]
    public bool can_place_item = true;

    [SerializeField]
    Image selectedImage;
    [SerializeField]
    Text amout_text;

    //Slotクラスは所属先であるSlotManagerへの参照と自身を表すインデックスのみを保持し
    //、アイテムのデータは所属先のManagerが持つ

    bool dragging_item_exist = false;
    [SerializeField]
    int default_icon_canvas_sortinglayer = 3;
    [SerializeField]
    int dragging_icon_canvas_sortinglayer = 4;

   

    private void Awake()
    {
        item_icon_object.canvas.sortingOrder =  default_icon_canvas_sortinglayer;

    }
    void Start()
    {
        if (Slot_index == -1) { Debug.Log("Slot Index Erorr"); }
        #region EventTrigger
        EventTrigger eventTrigger = gameObject.GetComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        EventTrigger.Entry entry1 = new EventTrigger.Entry();
        EventTrigger.Entry entry2 = new EventTrigger.Entry();
        EventTrigger.Entry entry3 = new EventTrigger.Entry();

        entry.eventID = EventTriggerType.PointerClick;
        entry1.eventID = EventTriggerType.BeginDrag;
        entry2.eventID = EventTriggerType.EndDrag;
        entry3.eventID = EventTriggerType.Drag;

        entry.callback.AddListener((data) => { OnSlotSelected(); });
        entry1.callback.AddListener((data) => { OnSlotStartDrag(); });
        entry2.callback.AddListener((data) => { OnSlotEndDrag(); });
        entry3.callback.AddListener((data) => { OnSlotDragging(); });

        eventTrigger.triggers.Add(entry);
        eventTrigger.triggers.Add(entry1);
        eventTrigger.triggers.Add(entry2);
        eventTrigger.triggers.Add(entry3);
        #endregion
        gameObject.tag = slot_tag_name;
    }

    public void SetIcon(Sprite icon , int alpha = 255)
    {
        if (icon)
        {
            item_icon_object.sprite = icon;
            item_icon_object.color = new Color(255, 255, 255, alpha / 255.0f);
        }
        else
        {
            item_icon_object.sprite = null;
            item_icon_object.color = new Color(255, 255, 255, 0);
        }
    }
    
    public void SetAmoutText(int? amount)
    {
        amout_text.text = amount.HasValue ? $"{amount.Value}" : "";
    }

    void OnSlotSelected()
    {
        
        print($"slotIndex : {Slot_index},Item : {Affiliation.GetSlotItem(Slot_index).Value.id},Count : {Affiliation.GetSlotItem(Slot_index).Value.amount}");
        
        if (Input.GetMouseButtonUp(1) && Affiliation.GetSlotItem(Slot_index).Value.id != Items.Item_ID.EmptyObject)
        {
            Affiliation.SlotPartition(Slot_index);
        }
        

    }
    
    void OnSlotStartDrag()
    {

        if(Affiliation.GetSlotItem(Slot_index).Value.id != Items.Item_ID.EmptyObject)
        {
            dragging_item_exist = true;
        }
        item_icon_object.canvas.sortingOrder = dragging_icon_canvas_sortinglayer;
        amout_text.gameObject.SetActive(false);
    }

    void OnSlotDragging()
    {
        if (dragging_item_exist)
        {
            item_icon_object.gameObject.transform.position =
                Input.mousePosition;
        }

        
    }

    void OnSlotEndDrag()
    {

        
        item_icon_object.canvas.sortingOrder = default_icon_canvas_sortinglayer;

        if (dragging_item_exist)
        {
            dragging_item_exist = false;
            Slot near = Affiliation.GetNearestSlot(item_icon_object.gameObject.transform.position);
            if (near)
            {
                SlotManager.MoveItem(this, near);
            }
        }
        

        item_icon_object.transform.localPosition = Vector3.zero;
        amout_text.gameObject.SetActive(true);

    }

    public void OnDeselect(BaseEventData eventData)
    {
        if (selectedImage)
        {
            selectedImage.gameObject.SetActive(false);
            print("deselected");
        }
    }

    public void OnSelect(BaseEventData eventData)
    {
        if (selectedImage)
        {
            selectedImage.gameObject.SetActive(true);
            print("selected");
        }
    }
}
