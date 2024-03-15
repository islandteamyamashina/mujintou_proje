using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Selectable))]
public class PopupImage : MonoBehaviour,IDeselectHandler
{
    Selectable selectable;
    public Slot spawned_slot = null;
    [SerializeField]
    Button ReturnButton;
    [SerializeField]
    Button PartitionButton;
    [SerializeField]
    Button DeleteButton;

    void Start()
    {
        selectable = GetComponent<Selectable>();
        selectable.Select();
        if(spawned_slot.Affiliation.GetSlotItem(spawned_slot.Slot_index).Value.amount <= 1)
        {
            PartitionButton.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void OnDeselect(BaseEventData data)
    {
        Debug.Log("Deselected");
        Destroy(gameObject, 0.2f);
    }

    public void RetutnButtonDown()
    {
        print("return");
    }

    public void PartitionButtonDown()
    {
        print("Partition");
    }

    public void DeleteButtonDown()
    {
        print("Delete");
        spawned_slot.Affiliation.ClearSlot(spawned_slot.Slot_index);

    }
}
