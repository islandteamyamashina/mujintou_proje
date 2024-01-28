using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManagerVer : MonoBehaviour
{
    //  テキスト表示用
    public Text txName, txInfo;

    //  引数のアイテムの情報を表示する
    public void SetText(NewItem ItemValue)
    {
        txName.text = ItemValue.ScriptalItem.itemName;
        txInfo.text = ItemValue.ScriptalItem.itemInfo;
    }
}
