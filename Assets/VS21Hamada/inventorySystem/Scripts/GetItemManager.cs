using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetItemManager : MonoBehaviour
{
    [SerializeField] GameObject[] goAllItemPrefabs;
    [SerializeField] InventoryManagerVer cpInventoryManager;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (!cpInventoryManager.GetIsItemFull())
                GetNewItem(Random.Range(4, 68));
        }
    }
    public void GetNewItem(int _ItemID)
    {
        var item = Instantiate(goAllItemPrefabs[_ItemID]);
        cpInventoryManager.SetNewGetItem(item);
    }
}
