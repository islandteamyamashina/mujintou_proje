using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CraftPanel : PanelBase
{
    [SerializeField]
    CraftSlots craftslots;
    [SerializeField]
    List<Text> discriptions;
    protected override  void Awake()
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
        for (int i = 0; i < discriptions.Count; i++)
        {
            discriptions[i].text = "";


        }

    }

    // Update is called once per frame
    protected override void Update()
    {
        if (gameObject.activeSelf && !PlayerInfo.Instance.Inventry.GetVisibility())
        {
            gameObject.SetActive(false);
        }
    }
    private void FixedUpdate()
    {
        for (int i = 0; i < discriptions.Count; i++)
        {
            var data = craftslots.GetSlotItem(i);
            if (!data.HasValue) return;
            
            if(data.Value.id != Items.Item_ID.EmptyObject)
            {
                discriptions[i].text = SlotManager.GetItemData(data.Value.id).item_name;
            }


        }
    }
}
