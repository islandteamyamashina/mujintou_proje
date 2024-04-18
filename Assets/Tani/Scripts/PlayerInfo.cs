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
    [SerializeField] private Image weather_image;
    [SerializeField] private List<Sprite> SunnyCloudyRainy;


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
    private List<Coroutine> coroutines = new List<Coroutine>();

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

    public void StartGame(bool override_current_data = false)
    {
        if (DataManager.Instance.DoesSaveExist())
        {
            
            print("save exist");
            if (override_current_data)
            {
                DataManager.Instance.InitializeSaveData();
            }
            LoadData();

        }
        else
        {
            print("save not exist");
            DataManager.Instance.Save(new SaveData());
            DataManager.Instance.InitializeSaveData();
            LoadData();
        }

        this.Inventry.SwitchVisible();
        this.inventry.SwitchVisible();


        Inventry.GetItem(Items.Item_ID.item_mat_coconut,3);
        Inventry.GetItem(Items.Item_ID.item_mat_magma, 3);
        Inventry.GetItem(Items.Item_ID.item_craft_onFireSet, 1);
        Inventry.GetItem(Items.Item_ID.item_special_lighter, 1);
        Inventry.GetItem((Items.Item_ID)34, 1);
        Inventry.GetItem(Items.Item_ID.item_mat_branch, 5,true);

       
        
    }

    protected override void Awake()
    {
        base.Awake();
        OnActionValueChange.AddListener(() => { action_value_text.text = $"{ActionValue} / {MaxActionValue}"; });
        OnMaxActionValueChange.AddListener(() => { action_value_text.text = $"{ActionValue} / {MaxActionValue}"; });

        

        DontDestroyOnLoad(gameObject);

    }

    private void Start()
    {
        StartGame(true);

        cursor_textures = new List<Texture2D>();
        foreach (var n in textureDatas)
        {

            cursor_textures.Add(ResizeTexture(n.width, n.height, n.cursor));

        }

        SetWeatherIcon();
    }

    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SavePalyerData();
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
        SetWeatherIcon();


        //状態付与
        if (IsPlayerConditionEqualTo(Condition.Hungry) &&
         IsPlayerConditionEqualTo(Condition.Thirsty))
        {
            AddPlayerCondition(Condition.ThirstyAndHungry);
        }
        else
        {
            EraseCondition(Condition.ThirstyAndHungry);
        }

        if (Thirst <= 30)
            AddPlayerCondition(Condition.Thirsty);
        else
            EraseCondition(Condition.Thirsty);

        if (Hunger <= 30)
            AddPlayerCondition(Condition.Hungry);
        else
            EraseCondition(Condition.Hungry);


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

    public void SwitchUIVisibility()
    {
        gameObject.transform.GetChild(0).GetChild(0).gameObject.SetActive(!gameObject.transform.GetChild(0).GetChild(0).gameObject.activeSelf);

    }
    public void SetUIVisibility(bool visible)
    {
        gameObject.transform.GetChild(0).GetChild(0).gameObject.SetActive(visible);
    }

    public void SetWeatherIcon()
    {
        weather_image.sprite = SunnyCloudyRainy[(int)weather];
    }

    IEnumerator MoveImage()
    {
        print($"リストのなかは{coroutines.Count}個");
        if(coroutines.Count > 0)
        {
            StopCoroutine(coroutines[coroutines.Count - 1]);
        }
        yield return null;

        print(Time.time);
        yield return new WaitForSeconds(1);
        coroutines.RemoveAt(0);
       
    }
    public void ItemViewVisualize(Items.Item_ID id, int num)
    {

        coroutines.Add(StartCoroutine(MoveImage()));



    }

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
       // UnityEngine.SceneManagement.SceneManager.LoadScene()
    }

    public void SavePalyerData()
    {
        SaveData saveData = new SaveData();
        saveData.MakeSaveData();
        Debug.Log($"プレイヤーデータが保存されました");
        DataManager.Instance.Save(saveData);
    }




    public void OnHover(int i)
    {
        SetMouseCursor(i);
    }
    public void OnUnhover()
    {
        SetMouseCursor(null);
    }




}

[System.Serializable]
public class TextureData
{
    public Texture2D cursor;
    public int width;
    public int height;
}