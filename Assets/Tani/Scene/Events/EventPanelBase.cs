using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;


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
    UnityAction[] actions;
    private void Awake()
    {
        event_text_control = event_text.gameObject.GetComponent<TextControl>();

      

        actions = new UnityAction[] { SelectChoise0, SelectChoise1, SelectChoise2 };
    }

    void Start()
    {

    }

    public void SetEvent(int index)
    {

    }
    //リストの中のランダムなイベントを実行
    public  void SetRandomEvent()
    {
        probability_sum = 0;
        int[] modifiedProbabilities = new int[EventList.Count];
        for (int i = 0; i < EventList.Count; i++)
        {
            int modi = (int)(EventList[i].probability * EventProbabilityMultiplier(EventList[i].scene_id));
            modifiedProbabilities[i] = modi;
            probability_sum += modi;
        }
        int random_int = Mathf.CeilToInt(Random.value * probability_sum);
        int range_min = 0;
        int range_max = 0;
        int index = 0;
        while (true)
        {
            range_min = range_max;
            range_max += modifiedProbabilities[index];
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
        if (!data)
        {
            Debug.LogError("Event data is null");
            return;
        }
        if (!CanEventExcute(data.scene_id))
        {
            SetRandomEvent();
            return;
        }
        


        event_text_control.EndEvent.RemoveAllListeners();
        event_text_control.ClickEventAfterTextsEnd.RemoveAllListeners();

     

        
        



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
            if(buttons.transform.GetChild(i).childCount >=2)
              buttons.transform.GetChild(i).GetChild(1).gameObject.GetComponent<Text>().text = $"行動値 : {data.results[i].required_action_value}";

            if (data.callBackType == EventCallBackType.Normal)
            {
                buttons.transform.GetChild(i).gameObject.GetComponent<Button>().onClick.AddListener(actions[i]);
            }
            else
            {

            }

          
            buttons.transform.GetChild(i).GetComponent<Button>().interactable =
                    PlayerInfo.Instance.ActionValue >= data.results[i].required_action_value;
        }


      

        //テキストが終わるまでボタンを非表示に
        buttons_prefab_parent.gameObject.SetActive(false);


    }

    float EventProbabilityMultiplier(int scene_id)
    {
        PlayerInfo info = PlayerInfo.Instance;
        switch (scene_id)
        {
            case 3:
                if (PlayerInfo.Instance.Day.day >= 10)
                {
                    return 1.5f;
                }
                return 1;
            case 1000:
                return info.weather == PlayerInfo.Weather.Sunny ? 1 : 0;
            case 1100:
                return info.weather == PlayerInfo.Weather.Rainy ? 1 : 0;
            case 1200:
                return info.weather == PlayerInfo.Weather.Cloudy ? 1 : 0;
            case 1005:
                if(info.Day.day >= 10 && info.Thirst <= 20)
                {
                    return 15;
                }
                else
                {
                    return 0;
                }
            case 1011:
                if (info.Day.day >= 10 && info.Thirst <= 20)
                {
                    return 15;
                }
                else
                {
                    return 0;
                }
            case 1010:
                return info.weather == PlayerInfo.Weather.Rainy ? 1 : 0;
            case 1004:
                return info.weather == PlayerInfo.Weather.Sunny ? 1 : 0;
            case 3005:
                return info.weather == PlayerInfo.Weather.Rainy ? 1 : 0;
            case 3010:
                return info.weather == PlayerInfo.Weather.Rainy ? 1 : 0;
            case 4011:
                return info.weather == PlayerInfo.Weather.Rainy ? 1 : 0;
            case 4013:
                return info.weather == PlayerInfo.Weather.Rainy ? 1 : 0;
            case 4012:
                return info.weather == PlayerInfo.Weather.Sunny ? 1 : 0;
            case 6010:
                return info.weather == PlayerInfo.Weather.Rainy ? 1 : 0;
            default:
                return 1;
        }
    }

    bool CanEventExcute(int scene_id)
    {
        switch (scene_id)
        {
            case 3:
                return PlayerInfo.Instance.Health >= 50;
            default:
                return true;
        }
    }

    

   

    public void ShowButtons()
    {
        
        buttons_prefab_parent.gameObject.SetActive(true);
        event_text_control.EndEvent.RemoveListener(ShowButtons);
        
    }



    public void ChoiseSelected(int index)
    {
        PlayerInfo.Instance.SetInventryLock(true);
        Destroy(buttons_prefab_parent.gameObject.transform.GetChild(0).gameObject);
        buttons_prefab_parent.gameObject.SetActive(false);
        event_text_control.EndEvent.RemoveAllListeners();
        ChoiseResult result;

        result = EventList.Find(n => n.scene_id == current_event_scene_id).results[index];

      


        event_text_control.ResetTextData();
        if (result.result_text.Trim().Length != 0)
            event_text_control.AddTextData(result.result_text);


        PlayerInfo info = PlayerInfo.Instance;
        //ステータスの増減を表す文字列

        var prev_health = info.Health;
        var prev_hunger = info.Hunger;
        var prev_thirst = info.Thirst;
        var prev_action = info.ActionValue;

        int health_change = Mathf.RoundToInt(Random.Range(result.health_change_min, result.health_change_max));
        int hunger_change = Mathf.RoundToInt(Random.Range(result.hunger_change_min, result.hunger_change_max));
        int thirst_change = Mathf.RoundToInt(Random.Range(result.thirst_change_min, result.thirst_change_max));


        info.Health += health_change;
        info.Hunger += hunger_change;
        info.Thirst += thirst_change;
        info.ActionValue -= result.required_action_value;

        string status_change =
            $"体力 : {prev_health} ⇒ {info.Health}\n" +
            $"水分 : {prev_thirst} ⇒ {info.Thirst}\n" +
            $"空腹 : {prev_hunger} ⇒ {info.Hunger}\n" +
            $"行動値 : {prev_action} ⇒ {info.ActionValue}";
        event_text_control.AddTextData(status_change);


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
                    if (PlayerInfo.Instance.Inventry.GetNullSlot())
                    {
                        result_text += PlayerInfo.Instance.Inventry.GetItemName(n.id) + $"を{num}個獲得!\n";
                        event_text_control.EndEvent.AddListener(() => info.Inventry.GetItem(n.id, num, true));
                    }
                    else
                    {
                        result_text += PlayerInfo.Instance.Inventry.GetItemName(n.id) + $"{num}個は持ち切れなかった!\n";
                    }
                    
                    
                }
            }
            event_text_control.AddTextData(result_text);
        }
        
       event_text_control.ClickEventAfterTextsEnd.AddListener(ONEndEvent);
       

    }

    void ONEndEvent()
    {
        event_text_control.ClickEventAfterTextsEnd.RemoveListener(ONEndEvent);
        PlayerInfo.Instance.SetInventryLock(false);


        StartEvent(endEventData);
    }

   
     void SelectChoise0() { ChoiseSelected(0); }
    void SelectChoise1() { ChoiseSelected(1); }
    void SelectChoise2() { ChoiseSelected(2); }


    

}
