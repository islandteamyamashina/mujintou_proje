using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CookingPanel : PanelBase
{
    [SerializeField]
    List<Text> discriptions;
    [SerializeField]
    CraftSlots craftslots;
    protected override void Awake()
    {
        OnStateChange.AddListener((enable) =>
        {

            if (enable)
            {
                PlayerInfo.Instance.Inventry.SetVisible(true);
                gameObject.SetActive(true);


            }
        });
    }
    protected override void Start()
    {

        SetSortOrder(OrderOfUI.NormalPanel);    
    }


    protected override void Update()
    {
        if (gameObject.activeSelf && !PlayerInfo.Instance.Inventry.GetVisibility())
        {
            gameObject.SetActive(false);

        }

        for (int i = 0; i < discriptions.Count; i++)
        {
            var data = craftslots.GetSlotItem(i);
            if (!data.HasValue) return;

            if (data.Value.id != Items.Item_ID.EmptyObject)
            {
                discriptions[i].text = SlotManager.GetItemData(data.Value.id).item_name;
            }
            else
            {
                discriptions[i].text = "";
            }
        }
    }
}
