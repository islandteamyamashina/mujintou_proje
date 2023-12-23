using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSlot : MonoBehaviour
{
   //【自分がアイテムスロットの何番目なのか？の x, y (関数で書き換えます)】
    private int x, y;

//【自分のスロット内にあるアイテムを保管する変数】
    public GameObject item;

//【マネージャーを取得(これはstatic GameManager等でインスタンス化させてい置くとさらに◎)】
  //  private InventoryManager cpInventoryManager;

    void Start()
    {
       // 【自分が動的に生成されるので、スポーンした後にマネージャーを探す】
       // cpInventoryManager = GameObject.Find("StorageManage").GetComponent<InventoryManager>();
    }

//【マネージャー側で呼び出す関数。自身の配列番地をマネージャーから教えてもらう】
    public void SetSlotNum(int _x, int _y)
    {
        x = _x;
        y = _y;
    }

//【マネージャー側で呼び出す関数。引数でもらってきたアイテムを自分のスロットの場所に移動させる】
    public void SetItem(GameObject _Itemvalue)
    {
        _Itemvalue.transform.position = transform.position;
    }
}
