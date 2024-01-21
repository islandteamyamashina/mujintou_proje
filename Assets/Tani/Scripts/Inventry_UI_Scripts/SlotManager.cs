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
            Slot slot = null;
            if (!gameObject.transform.GetChild(i).gameObject.TryGetComponent<Slot>(out slot))
            {
                Debug.Log("Error at SlotManager");
            }
            _Slots[slot.GetSlotIndex()] = slot;
            

        }
    }
    void Start()
    {



    }

    public void OnItemChanged(int index)
    {
        _Slots[index].SetItemToSlot(Inventry.Instance.GetItemData(PlayerInfo.Instance.GetItem(index)));
    }

    private int? GetNullSlotIndex()
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            if (!_Slots[i].SlotHasItem())
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

    public int GetSlotNum()
    {
        return transform.childCount;
    }

}
