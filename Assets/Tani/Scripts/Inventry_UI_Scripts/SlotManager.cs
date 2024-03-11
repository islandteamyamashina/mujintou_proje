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
    public Vector2Int slot_rect = new Vector2Int(0, 0);
    public Slot slot_prefab = null;
    public GameObject slot_parent = null;
}

public class SlotManager : MonoBehaviour
{
    [SerializeField]
    SlotsInfo data;
    
    
    


    private Slot[] _Slots = null;

    

    private void Awake()
    {
        SlotReconstruct();
    }

    private void Start()
    {
        
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

    
        if (_Slots != null && _Slots.Length != 0  )
        {
            for(int i = 0;i < _Slots.Length; i++)
            {
                Destroy(_Slots[i]);
                _Slots[i] = null;
            }
        }

        _Slots = new Slot[data.slot_horizontal_num * data.slot_vertical_num];
        for (int i = 0; i < _Slots.Length; i++)
        {

            _Slots[i] = Instantiate(data.slot_prefab.gameObject).GetComponent<Slot>();
            _Slots[i].transform.SetParent(
                data.slot_parent ? data.slot_parent.transform : gameObject.transform);

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
            print(local_index);
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
                    local_x = (int)(((2 * local_index.x - 1) / 2.0f) * (data.margin_horizontal + data.slot_rect.x));
                if (local_index.x < 0)
                    local_x = (int)(((2 * local_index.x + 1) / 2.0f) * (data.margin_horizontal + data.slot_rect.x));
            }
            else
            {
                //â°ÇÃêîÇ™äÔêîÇÃéû
                local_x = local_index.x * (data.margin_horizontal + data.slot_rect.x);

            }

            //define vertical position
            int local_y = 0;
            if (data.slot_vertical_num % 2 == 0)
            {
                //ècÇÃêîÇ™ãÙêîÇÃéû
                if (local_index.y > 0)
                    local_y = (int)(((2 * local_index.y - 1) / 2.0f) * (data.margin_vertical + data.slot_rect.y));
                if (local_index.y < 0)
                    local_y = (int)(((2 * local_index.y + 1) / 2.0f) * (data.margin_vertical + data.slot_rect.y));
            }
            else
            {
                //ècÇÃêîÇ™äÔêîÇÃéû
                local_y = local_index.y * (data.margin_vertical + data.slot_rect.y);

            }


            _Slots[i].gameObject.transform.localPosition = new Vector3(local_x, local_y, 0);


        }

    }
}
