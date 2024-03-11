//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.EventSystems;
//using UnityEngine.UI;

//public class DraggingMouseImage : MonoBehaviour
//{
  
//    Image image;

//    void Start()
//    {
//        image = GetComponent<Image>();
//        EventTrigger eventTrigger = gameObject.GetComponent<EventTrigger>();
//        EventTrigger.Entry entry = new EventTrigger.Entry();
//        EventTrigger.Entry entry1 = new EventTrigger.Entry();
//        entry.eventID = EventTriggerType.Drop;
//        entry1.eventID = EventTriggerType.PointerClick;
//        entry.callback.AddListener((data) => { OnDragEnd(); });
//        entry1.callback.AddListener((data) => { OnClicked(); });
//        eventTrigger.triggers.Add(entry);
//        eventTrigger.triggers.Add(entry1);

//    }

//    // Update is called once per frame
//    void Update()
//    {
        
//    }
//    public void OnDragEnd()
//    {
//        Debug.Log("end drag");
//        Slot nearest_slot = null;
//        foreach(var n in Inventry.Instance.slot_manager.GetSlots())
//        {
//            if (nearest_slot)
//            {
//                if((n.transform.position - Input.mousePosition).magnitude
//                    < (nearest_slot.transform.position - Input.mousePosition).magnitude)
//                {
//                    nearest_slot = n;
//                }
//            }
//            else
//            {
//                nearest_slot = n;
//            }
//        }
//        if (Inventry.Instance.GetDraggingData().item)
//        {
//            if (nearest_slot.SlotHasItem())
//            {
//                Inventry.Instance.slot_manager.GetSlots()[(int)Inventry.Instance.GetDraggingData().index]
//                    .SetItemToSlot(nearest_slot.GetItem());
//                nearest_slot.SetItemToSlot(Inventry.Instance.GetDraggingData().item);
//            }
//            else
//            {
//                nearest_slot.SetItemToSlot(Inventry.Instance.GetDraggingData().item);
//            }
//        }
        
//        Inventry.Instance.SetDraggingItem(null, null);
//    }
//    public void OnClicked()
//    {
//        if(Inventry.Instance.GetDraggingData().item != null)
//        {
         
//            Slot nearest_slot = null;
//            foreach (var n in Inventry.Instance.slot_manager.GetSlots())
//            {
//                if (nearest_slot)
//                {
//                    if ((n.transform.position - Input.mousePosition).magnitude
//                        < (nearest_slot.transform.position - Input.mousePosition).magnitude)
//                    {
//                        nearest_slot = n;
//                    }
//                }
//                else
//                {
//                    nearest_slot = n;
//                }
//            }

//            if (Inventry.Instance.GetDraggingData().item)
//            {
//                if (nearest_slot.SlotHasItem())
//                {
//                    Inventry.Instance.slot_manager.GetSlots()[(int)Inventry.Instance.GetDraggingData().index]
//                        .SetItemToSlot(nearest_slot.GetItem());
//                    nearest_slot.SetItemToSlot(Inventry.Instance.GetDraggingData().item);
//                }
//                else
//                {
//                    nearest_slot.SetItemToSlot(Inventry.Instance.GetDraggingData().item);
//                }



                
//            }

//            Inventry.Instance.SetDraggingItem(null, null);
//        }
 
//    }
//}
