using UnityEngine;


[CreateAssetMenu(fileName = "New Item", menuName = "ScriptableObject/Create Item")]
public class Items : ScriptableObject
{
    //アイテID
    public Item_ID item_ID = Item_ID.Item_Max;
    //アイテムのアイコン
    public Sprite icon = null;
    //使用できるか
    public bool canUse = false;
    //使用した時の効果
    public int Health_Change = 0;
    public int Hunger_Change = 0;
    public int Thirst_Chage = 0;
    public int Luck_Change = 0;
    //説明文
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
