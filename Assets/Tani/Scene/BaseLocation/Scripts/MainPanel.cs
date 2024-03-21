using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainPanel : PanelBase
{
    [SerializeField]
    Image MainBG;

    [SerializeField]
    List<Sprite> images;


    protected override void Awake()
    {
        
    }

    protected override void Start()
    {
        SetSortOrder(OrderOfUI.MainPanel);
    }

    // Update is called once per frame
    protected override void Update()
    {
        
    }

    public void ChageImage(int index)
    {

        MainBG.sprite = images[index];
    }
}
