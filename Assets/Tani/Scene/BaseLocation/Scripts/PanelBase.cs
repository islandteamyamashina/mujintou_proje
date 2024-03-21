using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelBase : MonoBehaviour
{

    [SerializeField]
    Canvas ownedMainCanvas;


    virtual protected void Awake()
    {

    }

    virtual protected void Start()
    {

    }


    virtual protected void Update()
    {
        
    }

    public void SetEnabled(bool enabled)
    {
        gameObject.SetActive(enabled);
    }

    public void SwitchEnabaled()
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }

    protected void SetSortOrder(OrderOfUI order)
    {
        ownedMainCanvas.overrideSorting = true;
        ownedMainCanvas.sortingOrder = (int)order;
    }

    protected enum OrderOfUI
    {
        MainPanel,
        NormalPanel,
        Inventry,
        PlayerStatus,
        Option,
    }
}
