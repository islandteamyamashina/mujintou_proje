using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

//[RequireComponent(typeof(ButtonControlMethods))]
public class EventPanelBase : MonoBehaviour
{   
    //inspector field
    [SerializeField]
    Image event_view;
    [SerializeField]
    Text event_title;
    [SerializeField]
    Text event_text;
    [SerializeField]
    List<EventDatas> EventList;
    [SerializeField]
    Transform buttons_prefab_parent;
    [SerializeField]
    EventDatas endEventData;


    //private field
    int probability_sum = 0;
    int current_event_scene_id = 0;


    TextControl event_text_control;
    ButtonControlMethods button_methods;
    UnityAction[] actions;
    private void Awake()
    {
        button_methods = GetComponent<ButtonControlMethods>();
        event_text_control = event_text.gameObject.GetComponent<TextControl>();

      

        actions = new UnityAction[] { SelectChoise0, SelectChoise1, SelectChoise2 };
    }

    void Start()
    {
       // SetRandomEvent();
       
    }

    public void SetEvent(int index)
    {

    }
    //リストの中のランダムなイベントを実行
    public  void SetRandomEvent()
    {
        probability_sum = 0;
        foreach (var n in EventList)
        {
            probability_sum += n.probability;
        }
        int random_int = Mathf.CeilToInt(Random.value * probability_sum);
        int range_min = 0;
        int range_max = 0;
        int index = 0;
        while (true)
        {
            range_min = range_max;
            range_max += EventList[index].probability;
            if(random_int > range_min && random_int <= range_max)
            {
                break;
            }
            index++;
        }

        StartEvent(EventList[index]);
    }

    public enum EventCallBackType { Normal,Custom};
    public void StartEvent(EventDatas data)
    {
        print("StartEvent");
        event_text_control.EndEvent.RemoveAllListeners();
        event_text_control.ClickEventAfterTextsEnd.RemoveAllListeners();

     

        
        if (!data)
        {
            Debug.LogError("Event data is null");
            return;
        }



        //UIを適用
        current_event_scene_id = data.scene_id;
        event_view.sprite = data.event_view_sprite;
        event_title.text = data.event_title;

        event_text_control.ResetTextData();
        event_text_control.AddTextData(data.main_text);
        //テキスト終了時にボタンを表示
        event_text_control.EndEvent.AddListener(ShowButtons);
        //選択肢となるボタンを作成
        if(buttons_prefab_parent.childCount != 0)
        {
            DestroyImmediate(buttons_prefab_parent.GetChild(0).gameObject);
        }
        var buttons = Instantiate(data.buttons_prefab);
        buttons.transform.SetParent(buttons_prefab_parent);
        buttons.transform.localPosition = Vector3.zero;

        //ボタンのテキストを適用
        if(buttons.transform.childCount != data.results.Count)
        {
            Debug.LogError("button amount and results count not match");
            return;
        }

        for (int i = 0; i < buttons.transform.childCount; i++)
        {
            buttons.transform.GetChild(i).GetChild(0).gameObject.GetComponent<Text>().text = data.results[i].choise_text;
            if (data.callBackType == EventCallBackType.Normal)
            {
                buttons.transform.GetChild(i).gameObject.GetComponent<Button>().onClick.AddListener(actions[i]);
            }
            else
            {

            }
        }


      

        //テキストが終わるまでボタンを非表示に
        buttons_prefab_parent.gameObject.SetActive(false);


    }

   

    public void ShowButtons()
    {
        
        buttons_prefab_parent.gameObject.SetActive(true);
        event_text_control.EndEvent.RemoveListener(ShowButtons);
        
    }



    public void ChoiseSelected(int index)
    {
       
        Destroy(buttons_prefab_parent.gameObject.transform.GetChild(0).gameObject);
        buttons_prefab_parent.gameObject.SetActive(false);
        event_text_control.EndEvent.RemoveAllListeners();
        ChoiseResult result;

        result = EventList.Find(n => n.scene_id == current_event_scene_id).results[index];

      


        event_text_control.ResetTextData();
        if (result.result_text.Trim().Length != 0)
            event_text_control.AddTextData(result.result_text);


        PlayerInfo info = PlayerInfo.Instance;
        if (Mathf.Abs(result.health_change) + Mathf.Abs(result.hunger_change) + Mathf.Abs(result.thirst_change) != 0)
        {
            //ステータスの増減を表すもじれる

            var prev_health = info.Health;
            var prev_hunger = info.Hunger;
            var prev_thirst = info.Thirst;

            info.Health += result.health_change;
            info.Hunger += result.hunger_change;
            info.Thirst += result.thirst_change;

            string status_change =
                $"体力 : {prev_health} ⇒ {info.Health}\n" +
                $"水分 : {prev_thirst} ⇒ {info.Thirst}\n" +
                $"空腹 : {prev_hunger} ⇒ {info.Hunger}";
            event_text_control.AddTextData(status_change);
        }
        

        //獲得結果を表す文字列
        if (result.Gain_Items.Count != 0)
        {
            string result_text = string.Empty;
            foreach (var n in result.Gain_Items)
            {
                //このアイテムを取得できるか
                bool bGet = Random.value <= n.probability;
                if (bGet)
                {
                    //いくつ獲得できるか
                    int num = n.range_min + Mathf.CeilToInt(Random.value * (n.range_max - n.range_min));
                    if (info.Inventry.GetItem(n.id, num))
                    {
                        result_text += info.Inventry.GetItemName(n.id) + $"を{num}個獲得!\n";
                    }
                    else
                    {
                        result_text += info.Inventry.GetItemName(n.id) + $"{num}個は持ち切れなかった!\n";
                    }
                }
            }
            event_text_control.AddTextData(result_text);
        }
        
       event_text_control.ClickEventAfterTextsEnd.AddListener(ONEndEvent);


    }

    void ONEndEvent()
    {
        print("event end");
        event_text_control.ClickEventAfterTextsEnd.RemoveListener(ONEndEvent);
       
        StartEvent(endEventData);
    }

     void SelectChoise0() { ChoiseSelected(0); }
    void SelectChoise1() { ChoiseSelected(1); }
    void SelectChoise2() { ChoiseSelected(2); }


    

}
