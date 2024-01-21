using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : SingletonMonoBehaviour<PlayerInfo>
{

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

  //  private Items.Item_ID[] Owing_Items;

    
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
        _player_Luck = 0;
        #region
        //�A�C�e���X���b�g�̏�����
        //if (Inventry.InstanceNullable)
        //{
        //    Owing_Items = new Items.Item_ID[Inventry.Instance.slot_manager.GetSlotNum()];
        //    for (int i = 0; i < Inventry.Instance.slot_manager.GetSlotNum(); i++) Owing_Items[i] = Items.Item_ID.EmptyObject;


        //    Owing_Items[0] = Items.Item_ID.Butterfly;
        //    Owing_Items[1] = Items.Item_ID.Plank;
        //    Inventry.Instance.OnItemChanged(0);
        //    Inventry.Instance.OnItemChanged(1);

        //}





        //Inventry.Instance.OnItemsChanged();
        #endregion
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
            _player_Health = value;
            _player_Health = Mathf.Clamp(_player_Health, 0, _Max_Player_Health);
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
        get { return _player_Luck; }
        set
        {
            _player_Luck = value;
             _player_Luck = Mathf.Clamp(_player_Luck,0,_Max_Player_Luck);
        }
    }

    public enum Condition
    {
        Good,Poisoned,Thirsty,Hungry,ThirstyAndHungry,CONDIITON_MAX
    }

    //�v���C���[�ɑ̒���t�����܂���
    public void AddPlayerCondition(Condition condition)
    {
        _player_condition |= (uint)1 << (int)condition;
    }

    //�v���C���[�̌��݂̑̒����ׂĂ����X�g�ŕԂ��܂�
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
    //�v���C���[���w�肵���̒��ł��邩�ǂ���
    public bool IsPlayerConditionEqualTo(Condition condition)
    {
        return (_player_condition & ((uint)1 << (int)condition)) != 0;
    }
    //���ׂĂ̑̒����Ȃ����܂�
    public void ResetCondition()
    {
        _player_condition = 0;
    }
    //�w�肵���̒����Ȃ����܂�
    public void EraseCondition(Condition condition)
    {
        _player_condition &= ~((uint)1 << (int)condition);
    }
    //�s�����ƂɎ��s���Ă��������B�̒��ɂ���Ċe�p�����[�^�[���ω����܂�
    public void DoAction()
    {
        for(int i = 0; i < (int)Condition.CONDIITON_MAX; i++)
        {
            if(IsPlayerConditionEqualTo((Condition)i))
            {
                switch (i)
                {
                    case (int)Condition.Good:
                        Luck += 5;
                        break;
                    case (int)Condition.Poisoned:
                        int decrease_health = Random.Range(3, 6);
                        Health -= decrease_health;
                        break;
                    case (int)Condition.Hungry:
                        int decrease_thirst = Random.Range(3, 6);
                        Thirst -= decrease_thirst;
                        break;
                    case (int)Condition.Thirsty:
                        int decrease_hunger = Random.Range(3, 6);
                        Thirst -= decrease_hunger;
                        break;
                    case (int)Condition.ThirstyAndHungry:
                        decrease_health = Random.Range(8, 11);
                        Health -= decrease_health;
                        Luck = 30;
                        break;
                }
            }
           
        }
    }
    #region
    ///// <summary>
    ///// �w�肵���A�C�e������g�p���܂�(��������炷)
    ///// </summary>
    ///// <param name="item_ID"></param>
    //public void UseItem(int index)
    //{

    //    if (Owing_Items[index] == Items.Item_ID.EmptyObject) return;
    //    Items used_item = Inventry.Instance.GetItemData(Owing_Items[index]);

    //    Health += used_item.Health_Change;
    //    Hunger += used_item.Hunger_Change;
    //    Thirst += used_item.Thirst_Chage;
    //    Luck += used_item.Luck_Change;

    //    Owing_Items[index] = Items.Item_ID.EmptyObject;

    //    Inventry.Instance.OnItemChanged(index);
    //}

    ///// <summary>
    ///// �w�肵���A�C�e���̐��𒼐ڎw�肵�܂�
    ///// </summary>
    ///// <param name="item_ID"></param>
    ///// <param name="num"></param>
    //public void SetItemNum(Items.Item_ID item_ID, int num)
    //{
    //   // Owing_Items[(int)item_ID] = num;
    //    if (Owing_Items[(int)item_ID] < 0)
    //    {
    //        Owing_Items[(int)item_ID] = 0;
    //    }

    //}

    //public Items.Item_ID GetItem(int index)
    //{
    //    return Owing_Items[index];
    //}
    #endregion
}
