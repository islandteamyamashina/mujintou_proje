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
    // Start is called before the first frame update
    void Start()
    {

        probability = 0.45f;
        string result_text = string.Empty;
        result_text += PlayerInfo.Instance.Inventry.GetItemName(Items.Item_ID.item_mat_shell) + $"を{1}個獲得しました。\n";
        PlayerInfo.Instance.Inventry.GetItem(Items.Item_ID.item_mat_shell, 1);
        foreach (var n in Gain_Items)
        {
            Debug.Log("foreach");
            // このアイテムを取得できるか
            bool bGet = Random.value <= probability;
            probability -= 0.05f;
            if (bGet)
            {
                Debug.Log(probability);
                //いくつ獲得できるか
                int num = 1;
                if (PlayerInfo.Instance.Inventry.GetNullSlot())
                {
                    result_text += PlayerInfo.Instance.Inventry.GetItemName(n) + $"を{num}個獲得しました。\n";
                    PlayerInfo.Instance.Inventry.GetItem(n, num);
                }
                else
                {
                    result_text += PlayerInfo.Instance.Inventry.GetItemName(n) + $"{num}個は持ち切れなかった!\n";
                }


            }
        }
        textComponent.AddTextData(result_text);
        Debug.Log(result_text);

    }

}

