using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData 
{
    public void MakeSaveData()
    {
        PlayerInfo info = null;
        if (PlayerInfo.InstanceNullable)
        {
            info = PlayerInfo.Instance;
            player_health = info.Health;
            player_hunger = info.Hunger;
            player_thirst = info.Thirst;
            player_luck = info.Luck;
            player_condition = info.GetConditionRawData();
        }
        else
        {
            Debug.Log("PlayerInfoが存在しないためセーブデータを作成できません");
        }
    }
    public int player_health;
    public int player_hunger;
    public int player_thirst;
    public int player_luck;
    public uint player_condition;
}
