using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[System.Serializable]
public class SlotsInfo
{
    public int slot_horizontal_num = 0;
    public int slot_vertical_num = 0;
    public int margin_horizontal = 20;
    public int margin_vertical = 20;
    public Slot slot_prefab = null;
    public GameObject slot_parent = null;
}

public class SlotManager : MonoBehaviour
{
    [SerializeField]
    SlotsInfo data;
   




    private Vector2Int slot_rect = new Vector2Int(0, 0);
    private Slot[] _Slots = null;
    private (Items.Item_ID id, int amount)[] item_list = null;

    

    private void Awake()
    {
        SlotReconstruct();
        
    }

    private void Start()
    {
        SetItemToSlot(Items.Item_ID.Fish, 1, 0);
    }


    private void SlotReconstruct()
    {
        #region ÉGÉâÅ[èàóù
        if (!data.slot_prefab)
        {
            Debug.LogError("SlotPrefab is not set");
            return;
        }
        #endregion 

        var rectTransform = data.slot_prefab.gameObject.GetComponent<RectTransform>();
        slot_rect = new Vector2Int((int)rectTransform.rect.width,(int)rectTransform.rect.height);
    
        if (_Slots != null && _Slots.Length != 0  )
        {
            for(int i = 0;i < _Slots.Length; i++)
            {
                Destroy(_Slots[i]);
                _Slots[i] = null;
            }
        }

        _Slots = new Slot[data.slot_horizontal_num * data.slot_vertical_num];
        item_list = new (Items.Item_ID id, int amount)[data.slot_horizontal_num * data.slot_vertical_num];
        for (int i = 0; i < item_list.Length; i++) item_list[i] = (Items.Item_ID.EmptyObject, 0);

        for (int i = 0; i < _Slots.Length; i++)
        {

            _Slots[i] = Instantiate(data.slot_prefab.gameObject).GetComponent<Slot>();
            _Slots[i].transform.SetParent(
                data.slot_parent ? data.slot_parent.transform : gameObject.transform);
            _Slots[i].Slot_index = i;
            _Slots[i].Affiliation = this;
            _Slots[i].SetIcon(null);

            int h_index = i % data.slot_horizontal_num;
            int v_index = i / data.slot_horizontal_num;
            // print(new Vector2(h_index, v_index));
            //0 , 1 , 2 , 3
            //4 , 5 , 6 , 7
            //8 , 9 , 10 , 11
            //12 , 13 , 14 , 15

            //Å´Å´Å´Å´Å´Å´Å´Å´
            float temp_x = h_index - ((data.slot_horizontal_num - 1) / 2.0f);
            float temp_y = (data.slot_horizontal_num - 1 - v_index) - ((data.slot_vertical_num  - 1)/ 2.0f);
            Vector2Int local_index = new Vector2Int(
                  temp_x >= 0 ? Mathf.CeilToInt(temp_x) : Mathf.FloorToInt(temp_x),
                  temp_y >= 0 ? Mathf.CeilToInt(temp_y) : Mathf.FloorToInt(temp_y)
                );
            
            //(-2,2),(-1,2) , (1,2) , (2,2)
            //(-2,1),(-1,1) , (1,1) , (2,1)
            //(-2,-1),(-1,-1) , (1,-1) , (2,-1)
            //(-2,-2),(-1,-2) , (1,-2) , (2,-2)

            //define horizontal position
            int local_x = 0;
            if (data.slot_horizontal_num  % 2 == 0)
            {
                //â°ÇÃêîÇ™ãÙêîÇÃéû
                if (local_index.x > 0)
                    local_x = (int)(((2 * local_index.x - 1) / 2.0f) * (data.margin_horizontal + slot_rect.x));
                if (local_index.x < 0)
                    local_x = (int)(((2 * local_index.x + 1) / 2.0f) * (data.margin_horizontal + slot_rect.x));
            }
            else
            {
                //â°ÇÃêîÇ™äÔêîÇÃéû
                local_x = local_index.x * (data.margin_horizontal + slot_rect.x);

            }

            //define vertical position
            int local_y = 0;
            if (data.slot_vertical_num % 2 == 0)
            {
                //ècÇÃêîÇ™ãÙêîÇÃéû
                if (local_index.y > 0)
                    local_y = (int)(((2 * local_index.y - 1) / 2.0f) * (data.margin_vertical + slot_rect.y));
                if (local_index.y < 0)
                    local_y = (int)(((2 * local_index.y + 1) / 2.0f) * (data.margin_vertical + slot_rect.y));
            }
            else
            {
                //ècÇÃêîÇ™äÔêîÇÃéû
                local_y = local_index.y * (data.margin_vertical + slot_rect.y);

            }


            _Slots[i].gameObject.transform.localPosition = new Vector3(local_x, local_y, 0);


        }

    }

    public void SetItemToSlot(Items.Item_ID item_ID, int num, int slot_index)
    {
        item_list[slot_index] = (item_ID, num);
        var n = Resources.Load($"{item_ID}") as Items;
        if (n == null)
        {
            Debug.LogError($"Couldn't find Item Data : {item_ID} in Resources");
            return;
        }
        _Slots[slot_index].SetIcon(n.icon);
    }

    public void ClearSlot(int slot_index)
    {
        item_list[slot_index] = (Items.Item_ID.EmptyObject, 0);
    }

    static private GameObject[] SearchActiveSlotsInScene()
    {
        return GameObject.FindGameObjectsWithTag(Slot.slot_tag_name);
    }

    /// <summary>
    /// Return null if when no active slot or active slot is too far
    /// </summary>
    /// <param name="pos"></param>
    /// <returns></returns>
    static protected Slot GetNearestSlot(Vector3 pos)
    {
        float nearest_dis = float.MaxValue;
        GameObject nearest_slot = null;
        foreach(var n in SearchActiveSlotsInScene())
        {
            float distant = (n.transform.position - pos).magnitude;
            if(distant < nearest_dis)
            {
                nearest_dis = distant;
                nearest_slot = n;
            }
        }

        if(nearest_dis <= 150)
        {
            return nearest_slot.GetComponent<Slot>();
        }
        else
        {
            return null;
        }
        
    }

    /// <summary>
    /// Return move success or not
    /// </summary>
    /// <param name="src"></param>
    /// <param name="dis"></param>
    /// <returns></returns>
    static public bool MoveItem(Slot src ,Slot dis)
    {
        if(src == null|| dis == null)
        {
            return false;
        }

        if(dis.Affiliation.item_list[dis.Slot_index].id != Items.Item_ID.EmptyObject)
        {
            var temp_src = src.Affiliation.item_list[src.Slot_index];
            var temp_dis = dis.Affiliation.item_list[dis.Slot_index];

            dis.Affiliation.SetItemToSlot(temp_src.id, temp_src.amount, dis.Slot_index);
            src.Affiliation.SetItemToSlot(temp_dis.id, temp_dis.amount, src.Slot_index);

            return true;

        }
        else
        {
            var temp_src = src.Affiliation.item_list[src.Slot_index];
            dis.Affiliation.SetItemToSlot(temp_src.id, temp_src.amount, dis.Slot_index);
            src.Affiliation.ClearSlot(src.Slot_index);

            return true;
        }



        
    }
}
