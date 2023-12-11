using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : SingletonMonoBehaviour<PlayerInfo>
{
    [SerializeField]
    private int _Init_Player_Health = 100;
    [SerializeField]
    private int _Init_Player_Hunger = 100;
    [SerializeField]
    private int _Init_Player_Thirst = 100;
    [SerializeField]
    private int _Max_Player_Health = 100;
    [SerializeField]
    private int _Max_Player_Hunger = 100;
    [SerializeField]
    private int _Max_Player_Thirst = 100;

    private int _player_Health;
    private int _player_Hunger;
    private int _player_Thirst;
    private int _player_Luck;

    
    protected override  void Awake() 
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
        
    }
    void Start()
    {
        _player_Health = _Init_Player_Health;
        _player_Hunger = _Init_Player_Hunger;
        _player_Thirst = _Init_Player_Thirst;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int Health
    {
        get { return _player_Health; }

        set
        {
            if (value >= _Max_Player_Health)
            {
                value = _Max_Player_Health;
            }
            else if (value < 0)
            {
                value = 0;
            }
            _player_Health = value;
        }
    }
    public int Hunger
    {
        get { return _player_Hunger; }

        set
        {
            if (value >= _Max_Player_Hunger)
            {
                value = _Max_Player_Hunger;
            }
            else if (value < 0)
            {
                value = 0;
            }
            _player_Hunger = value;
        }
    }
    public int Thirst
    {
        get { return _player_Thirst; }

        set
        {
            if (value >= _Max_Player_Thirst)
            {
                value = _Max_Player_Thirst;
            }
            else if (value < 0)
            {
                value = 0;
            }
            _player_Thirst = value;
        }
    }

    public int Luck
    {
        get { return _player_Luck; }
        set
        {
            if (Mathf.Abs(value) >= 100) Mathf.Clamp(value,-100,100);
            _player_Luck = value;
        }
    }
}
