using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotManager : MonoBehaviour
{
    
    [SerializeField] private int iSideSlideValue;

    //【スポーンさせるItemSlot.csのプレハブ、約70種類あるアイテム達(今は1つだけ。配列にして種類を増やしてね)】
    public GameObject prefab_Slot, prefab_Item;

//【難関！２次元配列！ここでは6x4の大きさにしてるよ】
    public InventorySlot[,] cpSlots = new InventorySlot[6, 4];

    void Start()
    {
        for (int k = 0; k < 6; k++)
        {
            for (int i = 0; i < 4; i++)
            {
　　//　【二重forで2次元配列の中に順番でItemSlot.csをスポーンさせて(この時同時に位置もずらしてるよ)、格納】
                cpSlots[k, i] = Instantiate(prefab_Slot, gameObject.transform.position + (Vector3.right * i * iSideSlideValue) + (Vector3.down * k * iSideSlideValue), gameObject.transform.rotation).GetComponent<InventorySlot>();
                cpSlots[k, i].transform.localScale = Vector3.one * 0.8f;

　　　//【ItemSlot.csで作っておいた関数を呼び出して、それぞれに番号をつけていく】
                cpSlots[k, i].GetComponent<InventorySlot>().SetSlotNum(i, k);
            }
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
　　//【キーボード押したときに関数を呼び出す】
            GetItem();
        }
    }

    public void GetItem()
    {
　//【アイテムをスポーンさせる(varは型名で、この関数内のみ使えるローカル変数。(どんな型でも大体入れることができる))】
        var _Item = Instantiate(prefab_Item);
        for (int k = 0; k < 6; k++)
        {
            for (int i = 0; i < 4; i++)
            {
　　　//【二重forの中でItemSlot.csの中のGameobject変数「Item」にアクセスして、中身を確認する】
　　　//【何も入っていなければそこにスポーンさせたアイテムをセットする】
                if (cpSlots[k, i].item == null)
                {
                    cpSlots[k, i].item = _Item;
                    _Item.transform.position = cpSlots[k, i].transform.position;
                    return;
                }
            }
        }
    }
    public void ShowItem(int x, int y)
    {
        Debug.Log("SlotNum" + x + ":" + y + "=" + cpSlots[x, y].item.GetComponent<Item>().name);
    }
}
