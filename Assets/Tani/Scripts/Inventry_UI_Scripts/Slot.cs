using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(EventTrigger))]
public class Slot : MonoBehaviour
{
    [HideInInspector]
    static public string slot_tag_name = "Slot";
    public int Slot_index { get; set; } = -1;
    public SlotManager Affiliation { get; set; } = null;
    [SerializeField]
    Image item_icon_object = null;

    //Slotクラスは所属先であるSlotManagerへの参照と自身を表すインデックスのみを保持し
    //、アイテムのデータは所属先のManagerが持つ


    private void Awake()
    {
        

    }
    void Start()
    {
        if (Slot_index == -1) { Debug.Log("Slot Index Erorr"); }
        EventTrigger eventTrigger = gameObject.GetComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        EventTrigger.Entry entry1 = new EventTrigger.Entry();
        EventTrigger.Entry entry2 = new EventTrigger.Entry();

        entry.eventID = EventTriggerType.PointerClick;
        entry1.eventID = EventTriggerType.BeginDrag;
        entry2.eventID = EventTriggerType.EndDrag;

        entry.callback.AddListener((data) => { OnSlotSelected(); });
        entry1.callback.AddListener((data) => { OnSlotStartDrag(); });
        entry2.callback.AddListener((data) => { OnSlotEndDrag(); });
        eventTrigger.triggers.Add(entry);
        eventTrigger.triggers.Add(entry1);
        eventTrigger.triggers.Add(entry2);

        gameObject.tag = slot_tag_name;
    }

    public void SetIcon(Sprite icon)
    {
        if (icon)
        {
            item_icon_object.sprite = icon;
            item_icon_object.color = new Color(255, 255, 255, 255);
        }
        else
        {
            item_icon_object.sprite = null;
            item_icon_object.color = new Color(255, 255, 255, 0);
        }

        
    }
    

    void OnSlotSelected()
    {
        
        print($"selected : {Slot_index}");
        

    }
    
    void OnSlotStartDrag()
    {
        Debug.Log($"Begin Drag : {Slot_index}");

    }

    void OnSlotEndDrag()
    {
        print($"End Drag : {Slot_index}");
    }


}
