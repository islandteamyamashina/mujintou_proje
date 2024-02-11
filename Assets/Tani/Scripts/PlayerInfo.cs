using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfo : SingletonMonoBehaviour<PlayerInfo>
{
    public int Day { get; set; } = 0;
    public Weather weather { get; set; }

    [Header("状態異常による影響値")]
    [SerializeField]private int _Max_Poisoned_Damage = 5;
    [SerializeField] private int _Min_Poisoned_Damage = 5;

    [SerializeField] private int _Max_Hungry_Effect = 5;
    [SerializeField] private int _Min_Hungry_Effect = 3;

    [SerializeField] private int _Max_Thirsty_Effect = 5;
    [SerializeField] private int _Min_Thirsty_Effect = 3;

    [SerializeField] private int _Max_HungryAndThirsty_Damage = 10;
    [SerializeField] private int _Min_HungryAndThirsty_Damage = 8;

    [Space]

    
    [Header("ステータスの初期値最大値")]
    [SerializeField]private int _Init_Player_Health = 50;
    [SerializeField] private int _Init_Player_Hunger = 50;
    [SerializeField] private int _Init_Player_Thirst = 50;

    [SerializeField] private int _Max_Player_Health = 100;
    [SerializeField] private int _Max_Player_Hunger = 100;

    [SerializeField] private int _Max_Player_Thirst = 100;
    [SerializeField] private int _Max_Player_Luck = 100;

    [Space, Header("その他")]
    [SerializeField, Tooltip("行動ごとに増える湧き水値")] private int water_gain = 5;
    [SerializeField, Tooltip("行動ごとに減る焚火値")] private int fire_decrease = 5;

    [Space]
    [Header("テスト中")]
    [SerializeField] private Text status_text;
    [SerializeField] private Text condition_text;
    [SerializeField] private Text weather_text;
    [SerializeField] private Text day_text;


    private int _player_Health;
    private int _player_Hunger;
    private int _player_Thirst;
    private int _player_Luck;

    private uint _player_condition = 0;
    private int water_value = 0;
    private int fire_value = 0;

    [SerializeField] private int first_item = 0;

    public int Health
    {
        get { return _player_Health; }
        set
        {
            _player_Health = value;
            _player_Health = Mathf.Clamp(_player_Health,0, _Max_Player_Health);
        }
    }

    public int Hunger
    {
        get { return _player_Hunger; }
        set
        {
            _player_Hunger = value;
            _player_Hunger = Mathf.Clamp(_player_Hunger, 0, _Max_Player_Hunger);
        }
    }

    public int Thirst
    {
        get { return _player_Thirst; }
        set
        {
            _player_Thirst = value;
            _player_Thirst = Mathf.Clamp(_player_Thirst, 0, _Max_Player_Thirst);
        }
    }
    public int Luck
    {
        get { return _player_Luck;}
        set
        {
            _player_Luck = value;
            _player_Luck = Mathf.Clamp(_player_Luck, 0, _Max_Player_Luck);
        }
    }

    public int Water
    {
        get { return water_value; }
        set
        {
            water_value = value;
            water_value = Mathf.Clamp(water_value, 0, 100);
        }
    }
    public int Fire
    {
        get { return fire_value; }
        set
        {
            fire_value = value;
            fire_value = Mathf.Clamp(fire_value, 0, 100);
        }
    }

    public enum Weather
    {
        Sunny,Cloudy,Rainy,Snowy,Foggy,Windy,
        Weather_Max
    }

    protected override void Awake()
    {
        base.Awake();

        DontDestroyOnLoad(gameObject);

    }

    private void Start()
    {
        _player_Health = _Init_Player_Health;
        _player_Hunger = _Init_Player_Hunger;
        _player_Thirst = _Init_Player_Thirst;
        _player_Luck = 0;

        AddPlayerCondition(Condition.Hungry);
        AddPlayerCondition(Condition.Thirsty);

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SaveData saveData = new SaveData();
            saveData.MakeSaveData();
            Debug.Log($"{saveData.player_health},{saveData.player_hunger},{saveData.player_thirst}");
           DataManager.Instance.Save(saveData);
        }

        if (Input.GetKeyDown(KeyCode.X))
        {

            Health = 100;
            Hunger = 100;
            Thirst = 100;
        }

        if (status_text && condition_text)
        {
            if(weather_text && day_text)
            {
                status_text.text = $"Health : {_player_Health},Hunger : {_player_Hunger},Thirst : {_player_Thirst},Luck : {_player_Luck}";
                string str = "";
                for (int i = 0; i < (int)Condition.CONDIITON_MAX; i++)
                {
                    if (IsPlayerConditionEqualTo((Condition)i))
                    {
                        str += $"{(Condition)i},";
                    }
                }
               
                condition_text.text = str;

                weather_text.text = $"{weather}";
                day_text.text = $"Day : {Day}";
            }
        }
    
    }

    public enum Condition
    {
        Good, Poisoned, Thirsty, Hungry, ThirstyAndHungry, CONDIITON_MAX
    }


    public void AddPlayerCondition(Condition condition)
    {
        _player_condition |= (uint)1 << (int)condition;
    }

    public List<Condition> GetPlayerAllConditions()
    {
        List<Condition> conditions = new List<Condition>();
        for (int i = 0; i < (int)Condition.CONDIITON_MAX; i++)
        {
            if (IsPlayerConditionEqualTo((Condition)i))
            {
                conditions.Add((Condition)i);
            }
        }
        return conditions;
    }

    public bool IsPlayerConditionEqualTo(Condition condition)
    {
        return (_player_condition & ((uint)1 << (int)condition)) != 0;
    }

    public void ResetCondition()
    {
        _player_condition = 0;
    }

    public void EraseCondition(Condition condition)
    {
        _player_condition &= ~((uint)1 << (int)condition);
    }

    public void DoAction()
    {
        Fire -= fire_decrease;
        Water += water_gain;
        Day += 1;
        weather = (Weather)((int)Random.Range(0, (int)Weather.Weather_Max));
        if(IsPlayerConditionEqualTo(Condition.Hungry) &&
            IsPlayerConditionEqualTo(Condition.Thirsty))
        {
            AddPlayerCondition(Condition.ThirstyAndHungry);
        }
        else
        {
            EraseCondition(Condition.ThirstyAndHungry);
        }

        for (int i = 0; i < (int)Condition.CONDIITON_MAX; i++)
        {
            if (IsPlayerConditionEqualTo((Condition)i))
            {
                switch (i)
                {
                    case (int)Condition.Good:
                        Luck += 5;
                        break;
                    case (int)Condition.Poisoned:
                        int decrease_health = Random.Range(_Min_Poisoned_Damage, _Max_Poisoned_Damage + 1);
                        Health -= decrease_health;
                        break;
                    case (int)Condition.Hungry:
                        int decrease_thirst = Random.Range(_Min_Hungry_Effect, _Max_Hungry_Effect + 1);
                        Thirst -= decrease_thirst;
                        break;
                    case (int)Condition.Thirsty:
                        int decrease_hunger = Random.Range(_Min_Thirsty_Effect, _Max_Thirsty_Effect + 1);
                        Hunger -= decrease_hunger;
                        break;
                    case (int)Condition.ThirstyAndHungry:
                        decrease_health = Random.Range(_Min_HungryAndThirsty_Damage, _Max_HungryAndThirsty_Damage + 1);
                        Health -= decrease_health;
                        Luck = 30;
                        break;
                }
            }

        }
    }

    public uint GetConditionRawData()
    {
        return _player_condition;
    }
    
    public float GetStatusPercent(int index)
    {
        switch (index)
        {
            case 0:
                return (float)Health / (float)_Max_Player_Health;
            case 1:
                return (float)Hunger / (float)_Max_Player_Hunger;
            case 2:
                return (float)Thirst / (float)_Max_Player_Thirst;
            default:
                return 0;
        }
    }

    int GetFirstItem() { return first_item; }
    void SetFirstItem(int item) { first_item = item; }
}