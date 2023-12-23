using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SlotManager : MonoBehaviour
{
    private Slot[] _Slots = null;


    private void Awake()
    {
        _Slots = new Slot[gameObject.transform.childCount];
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            if (!gameObject.transform.GetChild(i).gameObject.TryGetComponent<Slot>(out _Slots[i]))
            {
                Debug.Log("Error at SlotManager");
            }

        }
    }
    void Start()
    {
        for(int i = 0; i < gameObject.transform.childCount; i++)
        {
            EventTrigger eventTrigger = _Slots[i].gameObject.GetComponent<EventTrigger>();
            EventTrigger.Entry entry = new EventTrigger.Entry();
            entry.eventID = EventTriggerType.PointerClick;
            entry.callback.AddListener((data) => { OnSlotSelected((int)i); });
            eventTrigger.triggers.Add(entry);
        }


        
    }

    public void OnItemsChanged()
    {
        //スロットをすべてクリア
        for(int i = 0; i < gameObject.transform.childCount; i++)
        {
            _Slots[i].SetItemToSlot(null);
        }
        //空いているスロットにデータを入れる
        PlayerInfo info = PlayerInfo.Instance;
        for(int i = 0; i < (int)Items.Item_ID.Item_Max; i++)
        {
            Debug.Log(info.GetItemAmount((Items.Item_ID)i));
            if (info.GetItemAmount((Items.Item_ID)i)  != 0)
            {
                int? slotIndex = GetNullSlotIndex();
                if(slotIndex.HasValue)
                {
                    _Slots[(int)slotIndex].SetItemToSlot(
                        EnventryManager.Instance.GetItemData((Items.Item_ID)i), info.GetItemAmount((Items.Item_ID)i));
                }
               
            }
        }
    }

    private int? GetNullSlotIndex()
    {
        for(int i =0;i < gameObject.transform.childCount; i++)
        {
            if(!_Slots[i].SlotHasItem())
            {
                return i;
            }
        }
        return null;
    }
    public Slot[] GetSlots()
    {
        return _Slots != null ? _Slots : null;
    }

    void OnSlotSelected(int slotIndex)
    {

    }
}
