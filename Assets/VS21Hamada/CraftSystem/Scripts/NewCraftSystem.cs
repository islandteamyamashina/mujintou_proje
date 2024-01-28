using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewCraftSystem : MonoBehaviour
{
    public NewCraftList cpList;
    public GameObject[] prefabCraftItem;

    public InventorySlotVer cpFirstItemSlot, cpSecondItemSlot, cpThirdItemSlot, cpCraftItemSpawnPos;

    public void CraftStart()
    {
        var _ItemNum = cpList.CraftItem(cpFirstItemSlot.GetItem(), cpSecondItemSlot.GetItem(), cpThirdItemSlot.GetItem());
        if (_ItemNum != -1)
        {
            Instantiate(prefabCraftItem[_ItemNum], cpCraftItemSpawnPos.transform.position, cpCraftItemSpawnPos.transform.rotation);
        }
        else
            Debug.LogWarning("�N���t�g�V�X�e������󂯎�����l��-1�ł��B");
    }

}
