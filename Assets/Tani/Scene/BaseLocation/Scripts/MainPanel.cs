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
        //ƒpƒlƒ‹ŠÖŒW

        //GameObject.Find("BGM_ob").GetComponent<AudioSource>().clip = Audiovolume.instance.audioClipsBGM[1];
        //GameObject.Find("BGM_ob").GetComponent<AudioSource>().Play();
        
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
