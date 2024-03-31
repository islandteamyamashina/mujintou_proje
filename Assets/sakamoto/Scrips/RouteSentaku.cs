using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class RouteSentaku : MonoBehaviour
{
    [SerializeField] Button Route1;
    [SerializeField] Button Route2;
    [SerializeField] GameObject Route1_text;
    [SerializeField] GameObject Route2_text;

    Color color;
    Color normalColor = new Color(1.0f, 1.0f, 1.0f, 0.0f);
    Color highlightColor = new Color(1.0f, 1.0f, 1.0f, 1.0f);

    //[SerializeField, Header("inventoryマネージャー取得してね")] InventoryManagerVer cpInventoryManager;
    //[SerializeField] GetItemManager GetItemManager;

    public Event_BG_Disply event_BG_Disply;
    public Event_Text event_Text;
    public Event_Manage event_manage;

    int next_num_tnp;//ひとつ前のイベントナンバー

    // Start is called before the first frame update

    //ChatGPT作
    void Start()
    {
        Route1.image.color = Route2.image.color = normalColor;
        Route1_text.SetActive(false);
        Route2_text.SetActive(false);

        if (PlayerInfo.Instance.Inventry.GetItemAmount((Items.Item_ID)event_manage.eventDatas[event_manage.now_event_num].Sentakusi1_Zyouken) >= event_manage.eventDatas[event_manage.now_event_num].Sentakusi1_Zyouken_num || event_manage.eventDatas[event_manage.now_event_num].Sentakusi1_Zyouken_num == 0)
        {
            // Route1にマウスオーバー時のイベントを追加
            EventTrigger trigger1 = Route1.gameObject.AddComponent<EventTrigger>();
            trigger1.triggers.Add(new EventTrigger.Entry { eventID = EventTriggerType.PointerEnter });
            trigger1.triggers[0].callback.AddListener((data) => { OnRouteEnter(Route1); });
            trigger1.triggers.Add(new EventTrigger.Entry { eventID = EventTriggerType.PointerExit });
            trigger1.triggers[1].callback.AddListener((data) => { OnRouteExit(Route1); });
        }
        else
        {
            Route1.interactable = false;
        }

        if (PlayerInfo.Instance.Inventry.GetItemAmount((Items.Item_ID)event_manage.eventDatas[event_manage.now_event_num].Sentakusi2_Zyouken) >= event_manage.eventDatas[event_manage.now_event_num].Sentakusi2_Zyouken_num || event_manage.eventDatas[event_manage.now_event_num].Sentakusi1_Zyouken_num == 0)
        {
            // Route2にマウスオーバー時のイベントを追加
            EventTrigger trigger2 = Route2.gameObject.AddComponent<EventTrigger>();
            trigger2.triggers.Add(new EventTrigger.Entry { eventID = EventTriggerType.PointerEnter });
            trigger2.triggers[0].callback.AddListener((data) => { OnRouteEnter(Route2); });
            trigger2.triggers.Add(new EventTrigger.Entry { eventID = EventTriggerType.PointerExit });
            trigger2.triggers[1].callback.AddListener((data) => { OnRouteExit(Route2); });
        }
        else
        {
            Route2.interactable = false;
        }
    }

    void OnRouteEnter(Button button)
    {
        button.image.color = highlightColor;
        if(button == Route1)
        {
            Route1_text.SetActive(true);
        }
        if(button == Route2) 
        { 
            Route2_text.SetActive(true);
        }
    }

    void OnRouteExit(Button button)
    {
        button.image.color = normalColor;
        if (button == Route1)
        {
            Route1_text.SetActive(false);
        }
        if (button == Route2)
        {
            Route2_text.SetActive(false);
        }
    }
}
