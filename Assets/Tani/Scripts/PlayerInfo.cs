using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : SingletonMonoBehaviour<PlayerInfo>
{
    public int Day { get; set; }
    public Weather weather { get; set; }

    [SerializeField] private int _Max_Poisoned_Damage = 5;
    [SerializeField] private int _Min_Poisoned_Damage = 5;

    [SerializeField] private int _Max_Hungry_Effect = 5;
    [SerializeField] private int _Min_Hungry_Effect = 3;

    [SerializeField] private int _Max_Thirsty_Effect = 5;
    [SerializeField] private int _Min_Thirsty_Effect = 3;

    [SerializeField] private int _Max_HungryAndThirsty_Damage = 10;
    [SerializeField] private int _Min_HungryAndThirsty_Damage = 8;

    private int _Init_Player_Health = 50;
    private int _Init_Player_Hunger = 50;
    private int _Init_Player_Thirst = 50;

    private int _Max_Player_Health = 100;
    private int _Max_Player_Hunger = 100;

    private int _Max_Player_Thirst = 100;
    private int _Max_Player_Luck = 100;

    private int _player_Health;
    private int _player_Hunger;
    private int _player_Thirst;
    private int _player_Luck;

    private uint _player_condition = 0;

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


    public enum Weather
    {
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

    }
    private void Update()
    {

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
                        Thirst -= decrease_hunger;
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
}