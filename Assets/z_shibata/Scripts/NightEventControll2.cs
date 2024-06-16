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
        probability = 1;
        string result_text = string.Empty;
        foreach (var n in Gain_Items)
        {
            Debug.Log("foreach");
            // ���̃A�C�e�����擾�ł��邩
            bool bGet = Random.value <= probability;
            probability -= 0.15f;
            if (bGet)
            {
                //�����l���ł��邩
                int num = 1;
                if (PlayerInfo.Instance.Inventry.GetNullSlot())
                {
                    result_text += PlayerInfo.Instance.Inventry.GetItemName(n) + $"��{num}�l�����܂����B\n";
                    PlayerInfo.Instance.Inventry.GetItem(n, num);
                }
                else
                {
                    result_text += PlayerInfo.Instance.Inventry.GetItemName(n) + $"{num}�͎����؂�Ȃ�����!\n";
                }


            }
        }
        textComponent.AddTextData(result_text);
        Debug.Log(result_text);

    }

}

