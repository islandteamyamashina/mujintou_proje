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
        SortOrder = 0;
    }

    protected override void Start()
    {
        
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
