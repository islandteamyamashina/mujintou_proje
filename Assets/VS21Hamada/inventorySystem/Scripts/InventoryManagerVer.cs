using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManagerVer : MonoBehaviour
{
    //  �e�L�X�g�\���p
    public Text txName, txInfo;

    //  �����̃A�C�e���̏���\������
    public void SetText(NewItem ItemValue)
    {
        txName.text = ItemValue.ScriptalItem.itemName;
        txInfo.text = ItemValue.ScriptalItem.itemInfo;
    }
}
