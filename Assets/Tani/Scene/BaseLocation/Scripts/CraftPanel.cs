using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftPanel : PanelBase
{
    // Start is called before the first frame update
    protected override void Start()
    {
        
        SetSortOrder(OrderOfUI.NormalPanel);
        OnStateChange.AddListener((enable) =>
        {
          
            PlayerInfo.Instance.Inventry.SetVisible(enable);
        });
    }

    // Update is called once per frame
    protected override void Update()
    {
        if (!PlayerInfo.Instance.Inventry.GetVisibility())
        {
            gameObject.SetActive(false);
        }
    }
}
