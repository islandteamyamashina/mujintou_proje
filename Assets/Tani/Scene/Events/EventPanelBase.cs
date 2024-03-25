using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;

[RequireComponent(typeof(ButtonControlMethods))]
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


    //private field
    int probability_sum = 0;
    int current_event_scene_id = 0;
    Text Choise_Text_1_Control;
    Text Choise_Text_2_Control;
    Text Choise_Text_3_Control;

    TextControl event_text_control;
    ButtonControlMethods button_methods;
    private void Awake()
    {
        button_methods = GetComponent<ButtonControlMethods>();
        event_text_control = event_text.gameObject.GetComponent<TextControl>();

        foreach (var n in EventList)
        {
            probability_sum += n.probability;
        }

        
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

        StartEvent(EventList[index].scene_id);
    }

    public void StartEvent(int scene_id)
    {
        //実行するイベントのデータ
        var starting = EventList.Find(n => n.scene_id == scene_id);
        if (!starting)
        {
            Debug.LogError("match scene id event not assigned");
            return;
        }
        //変数初期化
        Choise_Text_1_Control = Choise_Text_2_Control = Choise_Text_3_Control = null;
        //UIを適用
        current_event_scene_id = starting.scene_id;
        event_view.sprite = starting.event_view_sprite;
        event_title.text = starting.event_title;
        event_text_control.ResetTextData();
        event_text_control.AddTextData(starting.main_text);
        //選択肢となるボタンを作成
        while (buttons_prefab_parent.childCount != 0) Destroy(buttons_prefab_parent.GetChild(0).gameObject);
        var buttons = Instantiate(starting.buttons_prefab);
        buttons.transform.SetParent(buttons_prefab_parent);
        buttons.transform.localPosition = Vector3.zero;

        //ボタンのテキストを適用
        if (0 < buttons.transform.childCount)
        {
            Choise_Text_1_Control = buttons.transform.GetChild(0).GetChild(0).gameObject.GetComponent<Text>();
            Choise_Text_1_Control.text = starting.choise_text_1;

            Button.ButtonClickedEvent buttonClickedEvent = new Button.ButtonClickedEvent();
            buttonClickedEvent.AddListener(SelectChoise1);
            buttons.transform.GetChild(0).GetComponent<Button>().onClick = buttonClickedEvent; 
        }

        if (1 < buttons.transform.childCount)
        {
            Choise_Text_2_Control = buttons.transform.GetChild(1).GetChild(0).gameObject.GetComponent<Text>();
            Choise_Text_2_Control.text = starting.choise_text_2;

            Button.ButtonClickedEvent buttonClickedEvent = new Button.ButtonClickedEvent();
            buttonClickedEvent.AddListener(SelectChoise2);
            buttons.transform.GetChild(1).GetComponent<Button>().onClick = buttonClickedEvent;
        }

        if (2 < buttons.transform.childCount)
        {
            Choise_Text_3_Control = buttons.transform.GetChild(2).GetChild(0).gameObject.GetComponent<Text>();
            Choise_Text_3_Control.text = starting.choise_text_3;


            Button.ButtonClickedEvent buttonClickedEvent = new Button.ButtonClickedEvent();
            buttonClickedEvent.AddListener(SelectChoise3);
            buttons.transform.GetChild(2).GetComponent<Button>().onClick = buttonClickedEvent;


        }

        //テキストが終わるまでボタンを非表示に
        buttons_prefab_parent.gameObject.SetActive(false);


    }

    public void ShowButtons()
    {
        
     
        buttons_prefab_parent.gameObject.SetActive(true);
    }

    public void ChoiseSelected(int number)
    {
       
        Destroy(buttons_prefab_parent.gameObject.transform.GetChild(0).gameObject);
        ChoiseResult result;
        

        if (number == 1) result = EventList.Find(n => n.scene_id == current_event_scene_id).choise_result_1;
        else if (number == 2) result = EventList.Find(n => n.scene_id == current_event_scene_id).choise_result_2;
        else if(number == 3)result = EventList.Find(n => n.scene_id == current_event_scene_id).choise_result_3;
        else
        {
            Debug.LogError("ButtonNumberInvalid");
            return;
        }


        event_text_control.ResetTextData();
        if (result.result_text.Trim() != string.Empty)
            event_text_control.AddTextData(result.result_text);


        //ステータスの増減を表すもじれる
        PlayerInfo info = PlayerInfo.Instance;
        info.Health += result.health_change;
        info.Hunger += result.hunger_change;
        info.Thirst += result.thirst_change;

        string status_change =
            $"体力 : {info.Health - result.health_change} ⇒ {info.Health}\n" +
            $"水分 : {info.Thirst - result.thirst_change} ⇒ {info.Thirst}\n" +
            $"空腹 : {info.Hunger - result.hunger_change} ⇒ {info.Hunger}";
        event_text_control.AddTextData(status_change);

        //獲得結果を表す文字列
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

    public void SelectChoise1() { ChoiseSelected(1); }
    void SelectChoise2() { ChoiseSelected(2); }
    void SelectChoise3() { ChoiseSelected(3); }



}
