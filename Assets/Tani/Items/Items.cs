using UnityEngine;


[CreateAssetMenu(fileName = "New Item", menuName = "ScriptableObject/Create Item")]
public class Items : ScriptableObject
{
    //�A�C�eID
    public Item_ID item_ID = Item_ID.Item_Max;
    //�A�C�e���̃A�C�R��
    public Sprite icon = null;
    //�g�p�ł��邩
    public bool canUse = false;
    //�g�p�������̌���
    public int Health_Change = 0;
    public int Hunger_Change = 0;
    public int Thirst_Chage = 0;
    public int Luck_Change = 0;
    //������
    public string Discription = null;
    
    public enum Item_ID
    {
        Butterfly,
        Fish,
        Leaf,
        Plank,
        Item_Max
    }

    
}
