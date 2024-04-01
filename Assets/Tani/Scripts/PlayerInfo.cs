using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;


public class PlayerInfo : SingletonMonoBehaviour<PlayerInfo>
{

    public (int day,bool isDayTime) Day
    {
        get
        {
            if (day % 2 == 0) return (day / 2, true);
            else return (day / 2, false);
        }

        private set
        {
            day = value.Item1;
        }


    }
    public Weather weather { get; set; }

    [Header("��Ԉُ�ɂ��e���l")]
    [SerializeField]private int _Max_Poisoned_Damage = 5;
    [SerializeField] private int _Min_Poisoned_Damage = 5;

    [SerializeField] private int _Max_Hungry_Effect = 5;
    [SerializeField] private int _Min_Hungry_Effect = 3;

    [SerializeField] private int _Max_Thirsty_Effect = 5;
    [SerializeField] private int _Min_Thirsty_Effect = 3;

    [SerializeField] private int _Max_HungryAndThirsty_Damage = 10;
    [SerializeField] private int _Min_HungryAndThirsty_Damage = 8;

    [Space]

    
    [Header("�X�e�[�^�X�̏����l�ő�l")]
    [SerializeField]private int _Init_Player_Health = 50;
    [SerializeField] private int _Init_Player_Hunger = 50;
    [SerializeField] private int _Init_Player_Thirst = 50;

    [SerializeField] private int _Max_Player_Health = 100;
    [SerializeField] private int _Max_Player_Hunger = 100;

    [SerializeField] private int _Max_Player_Thirst = 100;
    [SerializeField] private int _Max_Player_Luck = 100;

    [Space, Header("���̑�")]
    [SerializeField, Tooltip("�s�����Ƃɑ�����N�����l")] private int water_gain = 5;
    [SerializeField, Tooltip("�s�����ƂɌ��镰�Βl")] private int fire_decrease = 5;

    [Space]
    [Header("�e�X�g��")]
    [SerializeField] private Text status_text;
    [SerializeField] private Text condition_text;
    [SerializeField] private Text weather_text;
    [SerializeField] private Text day_text;
    [SerializeField] private Text action_value_text;
    [SerializeField] private List<TextureData> textureDatas;
    [SerializeField] private SlotManager inventry;
    [SerializeField] private SceneObject BadEnding;
    [SerializeField] private Fading fade;


    private int _player_Health;
    private int _player_Hunger;
    private int _player_Thirst;
    private int _player_Luck;
    private int _player_current_action_value = 5;
    private int _player_max_action_value = 5;

    private uint _player_condition = 0;
    private int water_value = 0;
    private int fire_value = 0;
    private int day = 2;
    private List<Texture2D> cursor_textures;

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

    public int StartArea { get; set; } = 0;

    public SlotManager Inventry
    {
        get
        {
            return inventry;
        }

    }

    public int ActionValue
    {
        get
        {
            return _player_current_action_value;
        }
        set
        {
            _player_current_action_value = Mathf.Clamp(value,0,_player_max_action_value);
            OnActionValueChange.Invoke();
        }
    }

    public int MaxActionValue
    {
        get { return _player_max_action_value; }
        set
        {
            if(value > _player_current_action_value)
            {
                _player_max_action_value = value;
                OnMaxActionValueChange.Invoke();
            }
        }
    }

    public UnityEvent OnActionValueChange { get; } = new UnityEvent();

    public UnityEvent OnMaxActionValueChange { get; } = new UnityEvent();

    public enum Weather
    {
        Sunny,Cloudy,Rainy,
        Weather_Max
    }

    protected override void Awake()
    {
        base.Awake();
        this.Inventry.SwitchVisible();
        this.Inventry.SwitchVisible();

        DontDestroyOnLoad(gameObject);

    }

    private void Start()
    {
        _player_Health = _Init_Player_Health;
        _player_Hunger = _Init_Player_Hunger;
        _player_Thirst = _Init_Player_Thirst;
        _player_Luck = 0;

        OnActionValueChange.AddListener(() => { action_value_text.text = $"{ActionValue} / {MaxActionValue}"; });
        OnMaxActionValueChange.AddListener(() => { action_value_text.text = $"{ActionValue} / {MaxActionValue}"; });

        if (DataManager.Instance.DoesSaveExist())
        {
            LoadData();
            print("save exist");

        }
        else
        {
            print("save not exist");
        }

        cursor_textures = new List<Texture2D>();
        foreach (var n in textureDatas)
        {

            cursor_textures.Add(ResizeTexture(n.width, n.height, n.cursor));

        }



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
        if (status_text && condition_text)
        {
            if (weather_text && day_text)
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
                day_text.text = $"{Day.day}";
            }
        }


        if (Input.GetKeyDown(KeyCode.X))
        {

            Health = 100;
            Hunger = 100;
            Thirst = 100;
            SetMouseCursor(null);
            ResetCondition();
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

    //実行は行動値が減る毎にするか
    //行動値を残して休息した場合、マイナスの効果は受けず(体調不良による体力減少など)
    //プラスの効果湧き水が増えるなどは行動値分実行される
    //焚火値の減少は例外として
    public void DoAction()
    { 
    
        Fire -= fire_decrease;

        Water += water_gain;
        Day = (day + 1,true);
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


    static public Texture2D ResizeTexture(int new_x, int new_y, Texture2D src)
    {
        Texture2D resizedTexture = new Texture2D(new_x, new_y, TextureFormat.RGBA32, false);
        Graphics.ConvertTexture(src, resizedTexture);
        return resizedTexture;

    }

    public void SetMouseCursor(int? index)
    {
        if (index.HasValue)
        {
            if ((int)index >= 0 && (int)index < cursor_textures.Count)
            {
                Cursor.SetCursor(cursor_textures[(int)index], Vector2.zero, CursorMode.ForceSoftware);
            }
            else Debug.LogError("Index OutOfRange");

        }
        else
        {
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        }
    }

    

    int GetFirstItem() { return first_item; }
 
    void SetFirstItem(int item) { first_item = item; }


    void LoadData()
    {
        SaveData data = DataManager.Instance.Load();
        _player_Health = data.player_health;
        _player_Hunger = data.player_hunger;
        _player_Thirst = data.player_thirst;
        _player_Luck = data.player_luck;
        _player_condition = data.player_condition;
        day = data.day;
        weather = (Weather)data.weather;
        water_value = data.water;
        fire_value = data.fire;
        ActionValue = data.action;
        MaxActionValue = data.max_action;
    }




    public void OnHover(int i)
    {
        SetMouseCursor(i);
    }
    public void OnUnhover()
    {
        SetMouseCursor(null);
    }

    public void AddCondition(int i)
    {
        AddPlayerCondition((Condition)i);
    }

    public void OnStartDrag()
    {
        print("drag");
    }

    public void OnDrop()
    {
        print("drop");
        
    }


}

[System.Serializable]
public class TextureData
{
    public Texture2D cursor;
    public int width;
    public int height;
}