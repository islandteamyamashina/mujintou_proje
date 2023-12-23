using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    private Image _image;
    private Items _item;
    private int _amount = 0;

    private void Awake()
    {
        _image = gameObject.transform.GetChild(0).gameObject.GetComponent<Image>();
        _item = null;
        _amount = 0;
    }
    void Start()
    {

    }


    public void SetItemToSlot(Items inItem,int num = 0)
    {
        
        if (inItem != null)
        {
            _item = inItem;
            _image.sprite = inItem.icon;
            _image.color = new Color(_image.color.r, _image.color.g, _image.color.b, 1);
            _amount = num;
        }
        else
        {
            _item = inItem;
            _image.sprite = null;
            _image.color = new Color(_image.color.r, _image.color.g, _image.color.b, 0);
            _amount = 0;
        }
    }

    public bool SlotHasItem()
    {
        return _item != null;
    }
}
