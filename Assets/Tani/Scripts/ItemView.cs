using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ItemView : MonoBehaviour
{
    [SerializeField]Image item_Image = null;
    [SerializeField] Text discription = null;
    [SerializeField] Text amount = null;
    [SerializeField] Button use_Button = null;
    Items item = null;

    Button.ButtonClickedEvent ButtonClickedEvent;
    void Start()
    {
        ButtonClickedEvent = new Button.ButtonClickedEvent();
        ButtonClickedEvent.AddListener(Clicked);
        use_Button.onClick = ButtonClickedEvent;
    }

    private void Update()
    {
        if(item != null)
        {
            amount.text = $"Å~{PlayerInfo.Instance.GetItemAmount(item.item_ID)}";
        }
    }

    public void SetViewItem(Items set_item)
    {
        if(set_item != null)
        {
            item = set_item;
            item_Image.sprite = set_item.icon;
            item_Image.color = new Color(item_Image.color.r, item_Image.color.g, item_Image.color.b, 1);
            discription.text = set_item.Discription;
            

        }
        else
        {
            item = null;
            item_Image.sprite = null;
            item_Image.color = new Color(item_Image.color.r, item_Image.color.g, item_Image.color.b, 0);
            discription.text = null;
            amount.text = null;
        }
    }

    void Clicked()
    {
        if (item == null) return;
        if (item.canUse)
        {
            PlayerInfo.Instance.UseItem(item.item_ID);
            Debug.Log("Use Item");
        }
        else
        {
            return;
        }
    }

}
