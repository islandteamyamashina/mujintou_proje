using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class RouteSentaku : MonoBehaviour
{
    [SerializeField] Button Route1;
    [SerializeField] Button Route2;
    [SerializeField] GameObject Route1_text;
    [SerializeField] GameObject Route2_text;
    [SerializeField] GameObject BG_cover;
    [SerializeField] TextControl textControl;
 
    Color color;
    Color normalColor = new Color(1.0f, 1.0f, 1.0f, 0.0f);
    Color highlightColor = new Color(1.0f, 1.0f, 1.0f, 1.0f);

    //[SerializeField, Header("inventory�}�l�[�W���[�擾���Ă�")] InventoryManagerVer cpInventoryManager;
    //[SerializeField] GetItemManager GetItemManager;

    public Event_BG_Disply event_BG_Disply;
    public Event_Text event_Text;
    public Event_Manage event_manage;

    int next_num_tnp;//�ЂƂO�̃C�x���g�i���o�[

    // Start is called before the first frame update

    //ChatGPT��
    void Start()
    {
        Route1.image.color = Route2.image.color = normalColor;
        Route1_text.SetActive(false);
        Route2_text.SetActive(false);

        if (PlayerInfo.Instance.Inventry.GetItemAmount((Items.Item_ID)event_manage.eventDatas[event_manage.now_event_num].Sentakusi1_Zyouken) >= event_manage.eventDatas[event_manage.now_event_num].Sentakusi1_Zyouken_num || event_manage.eventDatas[event_manage.now_event_num].Sentakusi1_Zyouken_num == 0)
        {
            // Route1�Ƀ}�E�X�I�[�o�[���̃C�x���g��ǉ�
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
            // Route2�Ƀ}�E�X�I�[�o�[���̃C�x���g��ǉ�
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
    public void ChoiseRoute1()
    {
        textControl.ResetTextData();
        StartCoroutine(appearBGcover());
        getItems(event_manage.eventDatas[event_manage.now_event_num].Sentakusi1_Reward1, event_manage.eventDatas[event_manage.now_event_num].Sentakusi1_Reward1_num);
    }

    IEnumerator appearBGcover()
    {
        while (true)
        {
            Color BG_cover_color;
             BG_cover_color = BG_cover.GetComponent<Image>().color;
            BG_cover_color.a += 0.05f;
            BG_cover.GetComponent<Image>().color = BG_cover_color;
            if (BG_cover.GetComponent<Image>().color.a < 0.7f)
            {
                break;
            }
            yield return null;
        }
    }

    //�@�{���A�̗͕ω��A�A�C�e���Q�b�g�̏���

    void changCondirion()
    {
        int beforeHelth;
        int beforeHunger;
        int beforeThirst;
    }

    void getItems(int Item_ID, int get_num)
    {
        string Item_name;
        PlayerInfo.Instance.Inventry.GetItem((Items.Item_ID)Item_ID, get_num);
        Item_name = PlayerInfo.Instance.Inventry.GetItemName((Items.Item_ID)Item_ID);
        textControl.AddTextData($"{Item_name}��{get_num}��ɓ���܂����B");
    }
}
