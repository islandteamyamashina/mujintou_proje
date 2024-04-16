using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StroragePanel : PanelBase
{
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

    // Update is called once per frame
    protected override void Update()
    {
        if (gameObject.activeSelf && !PlayerInfo.Instance.Inventry.GetVisibility())
        {
            gameObject.SetActive(false);

        }
    }
}
