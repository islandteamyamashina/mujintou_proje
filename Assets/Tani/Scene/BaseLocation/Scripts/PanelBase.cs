using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelBase : MonoBehaviour
{
    [SerializeField]
    GameObject parent;
    [SerializeField]
    Canvas ownedMainCanvas;

    public int SortOrder { get; protected set; } = 0;

    virtual protected void Awake()
    {

    }

    virtual protected void Start()
    {
        transform.SetParent(parent.transform);
        ownedMainCanvas.overrideSorting = true;
        ownedMainCanvas.sortingOrder = SortOrder;
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
}
