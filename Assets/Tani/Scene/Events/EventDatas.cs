using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class GetItemData
{

    public Items.Item_ID id;
    [Header("確率"),Range(0,1)]
    public float probability = 1;
    public int range_min = 0;
    public int range_max = 1;
}

[System.Serializable]
public class ChoiseResult
{
    public string choise_text = string.Empty;
    public List<GetItemData> Gain_Items;
    public string result_text = null;
    public int health_change = 0;
    public int hunger_change = 0;
    public int thirst_change = 0;
    public int required_action_value = 1;

}

[CreateAssetMenu(fileName = "New Item", menuName = "ScriptableObject/Event Datas")]

public class EventDatas : ScriptableObject
{
    public string event_title = "イベント";
    public int scene_id = 0;
    public Sprite event_view_sprite;
    public int probability = 1;
    public string main_text = null;
    public EventPanelBase.EventCallBackType callBackType = EventPanelBase.EventCallBackType.Normal;
    public GameObject buttons_prefab;

    [Space(20)]
    public List<ChoiseResult> results;

    
}
