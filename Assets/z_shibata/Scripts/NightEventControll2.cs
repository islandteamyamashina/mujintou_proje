using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NightEventControll2 : MonoBehaviour
{
    public TextControl textComponent;
    public float interval = 1f; 

    [SerializeField] Items.Item_ID[] Gain_Items;
    float probability = 1;
    int getNum;
    // Start is called before the first frame update
    void Start()
    {
        bool stilDest = false;
        getNum = 0;
        probability = 0.45f;
        string result_text = string.Empty;

        foreach (var n in Gain_Items)
        {
            Debug.Log("foreach");
            // このアイテムを取得できるか
            bool bGet = Random.value <= probability;
            if (bGet)
            {
                Debug.Log(probability);
                //いくつ獲得できるか
                int num = 1;
                if (PlayerInfo.Instance.Inventry.GetNullSlot())
                {
                    probability -= 0.09f;
                    getNum++;
                    result_text += PlayerInfo.Instance.Inventry.GetItemName(n) + $"を{num}個獲得しました。\n";
                    PlayerInfo.Instance.Inventry.GetItem(n, num);
                }
                else
                {
                    result_text += PlayerInfo.Instance.Inventry.GetItemName(n) + $"{num}個は持ち切れなかった!\n";
                }
            }
            
        }
        if (getNum == 0)
        {
            result_text += PlayerInfo.Instance.Inventry.GetItemName(Items.Item_ID.item_mat_shell) + $"を{1}個獲得しました。\n";
            PlayerInfo.Instance.Inventry.GetItem(Items.Item_ID.item_mat_shell, 1);
        }
        //たいまつしかもっていない時
        if(PlayerInfo.Instance.Inventry.GetItemAmount(Items.Item_ID.item_craft_torch) >= 1)
        {
            if (PlayerInfo.Instance.Inventry.GetItemAmount(Items.Item_ID.item_special_flash) < 1)
            {
                bool rnd = Random.value < 0.2f;
                if (rnd && PlayerInfo.Instance.MaxActionValue > 6)
                {
                    PlayerInfo.Instance.Inventry.UseItem(Items.Item_ID.item_craft_torch);
                    result_text +=  "\n" + "\n" + $"たいまつが燃え尽きてしまった！\n";
                    stilDest = true ;
                }
            }
        }
        //懐中電灯を持っている場合（優先的に懐中電灯を破壊）
        if (!stilDest)
        {
            if (PlayerInfo.Instance.Inventry.GetItemAmount(Items.Item_ID.item_special_flash) >= 1)
            {
                bool rnd = Random.value < 0.2f;
                if (rnd && PlayerInfo.Instance.MaxActionValue > 6)
                {
                    PlayerInfo.Instance.Inventry.UseItem(Items.Item_ID.item_special_flash);
                    result_text += "\n" + "\n" + $"懐中電灯の電池が切れてしまった！\n";
                }
            }
        }
        PlayerInfo.Instance.SavePalyerData();
        textComponent.AddTextData(result_text);
        Debug.Log(result_text);

    }

}

