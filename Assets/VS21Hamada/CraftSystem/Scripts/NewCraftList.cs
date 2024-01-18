using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewCraftList : MonoBehaviour
{
    public SO_Item[] Items;

    public int fID, sID, tID;

    public int CraftItem(NewItem fItem, NewItem sItem, NewItem tItem)
    {
        for (int i = 0; i < 61; i++)
        {
            if (Items[i].itemID == 1) continue;

            if (Items[i].isCraftingItem)
            {
                Debug.Log(i + "回目");
                if (fItem != null)
                    fID = fItem.ScriptalItem.itemID;
                if (sItem != null)
                    sID = sItem.ScriptalItem.itemID;
                if (tItem != null)
                    tID = tItem.ScriptalItem.itemID;

                //  設定されているIDが1つの場合
                if (fID != 0 && sID == 0 && tID == 0)
                {
                    Debug.LogWarning("設定されているIDが１つ");
                    if (fID == Items[i].firstID)
                    {
                        Debug.LogWarning("Items[" + i + "]とID一致");
                        if (fItem.CurrentStackCount >= Items[i].fItemCount)
                        {
                            Debug.LogWarning("個数足りています。");
                            fItem.CurrentStackCount -= Items[i].fItemCount;
                            return i;
                        }
                    }
                    else
                        continue;
                }
                //  設定されているIDが2つの場合
                else if (fID != 0 && sID != 0 && tID == 0)
                {
                    Debug.LogWarning("設定されているIDが２つ");
                    if (fID == Items[i].firstID && sID == Items[i].secondID)
                    {
                        Debug.LogWarning("Items[" + i + "]とID一致");
                        if (fItem.CurrentStackCount >= Items[i].fItemCount && sItem.CurrentStackCount >= Items[i].sItemCount)
                        {
                            Debug.LogWarning("個数足りています。");
                            fItem.CurrentStackCount -= Items[i].fItemCount;
                            sItem.CurrentStackCount -= Items[i].sItemCount;
                            return i;
                        }
                    }
                    else
                        continue;
                }
                //  設定されているIDが3つの場合
                else if (fID != 0 && sID != 0 && tID != 0)
                {
                    Debug.LogWarning("設定されているIDが３つ");
                    if (fID == Items[i].firstID && sID == Items[i].secondID && tID == Items[i].ThirdID)
                    {
                        Debug.LogWarning("Items[" + i + "]とID一致");
                        if (fItem.CurrentStackCount >= Items[i].fItemCount && sItem.CurrentStackCount >= Items[i].sItemCount && tItem.CurrentStackCount >= Items[i].tItemCount)
                        {
                            Debug.LogWarning("個数足りています。");
                            fItem.CurrentStackCount -= Items[i].fItemCount;
                            sItem.CurrentStackCount -= Items[i].sItemCount;
                            tItem.CurrentStackCount -= Items[i].tItemCount;
                            return i;
                        }
                    }
                    else
                        continue;
                }
            }
            else
            {
                Debug.LogWarning("クラフト可能ではないオブジェクトがリスト内にあります。(" + i + "番地)");
                return -1;
            }
        }
        Debug.LogWarning("リストのFor文が終了しました。エラー");
        return -1;
    }
}
