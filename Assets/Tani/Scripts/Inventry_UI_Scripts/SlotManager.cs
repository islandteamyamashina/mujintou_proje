using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
#if UNITY_EDITOR
using UnityEditor;
#endif

[System.Serializable]
public class SlotsInfo
{
    public int slot_horizontal_num = 0;
    public int slot_vertical_num = 0;
    public int margin_horizontal = 20;
    public int margin_vertical = 20;
    public Slot slot_prefab = null;
    public GameObject slot_parent = null;
    public List<int> index_igonored;
    public List<Slot> extra_slots;
}

public class SlotManager : MonoBehaviour
{
    [SerializeField]
    SlotsInfo data;
    [SerializeField]
    GameObject Slots_Main;




    private Vector2Int slot_rect = new Vector2Int(0, 0);
    private Slot[] _Slots = null;
    private (Items.Item_ID id, int amount)[] item_list = null;
    private float active_range = 0;

    

    private void Awake()
    {
        SlotReconstruct();
        active_range = data.slot_prefab.GetComponent<RectTransform>().rect.width * 2;
        
    }

    private void Start()
    {
        SetItemToSlot(Items.Item_ID.Fish, 1, 0);
    }


    public void SlotReconstruct()
    {
        #region �G���[����
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
            for(int i = 0;i < _Slots.Length - data.extra_slots.Count; i++)
            {
                if (_Slots[i])
                {
                    DestroyImmediate(_Slots[i].gameObject);
                }
                _Slots[i] = null;
            }
        }

        if (data.slot_parent)
        {
           while(data.slot_parent.transform.childCount != 0)
           {
                DestroyImmediate(data.slot_parent.transform.GetChild(0).gameObject);
           }
        }
        else
        {
            while (gameObject.transform.childCount != 0)
            {
                DestroyImmediate(gameObject.transform.GetChild(0).gameObject);
            }
        }



        _Slots = new Slot[data.slot_horizontal_num * data.slot_vertical_num + data.extra_slots.Count];
        item_list = new (Items.Item_ID id, int amount)[data.slot_horizontal_num * data.slot_vertical_num + data.extra_slots.Count];
        for (int i = 0; i < item_list.Length; i++) item_list[i] = (Items.Item_ID.EmptyObject, 0);

        for (int i = 0; i < _Slots.Length - data.extra_slots.Count; i++)
        {
            if (!data.index_igonored.Contains(i))
            {
                _Slots[i] = Instantiate(data.slot_prefab.gameObject).GetComponent<Slot>();
                _Slots[i].transform.SetParent(
                    data.slot_parent ? data.slot_parent.transform : gameObject.transform);
                _Slots[i].Slot_index = i;
                _Slots[i].Affiliation = this;
                _Slots[i].SetIcon(null);
            }
            

            int h_index = i % data.slot_horizontal_num;
            int v_index = i / data.slot_horizontal_num;

            //0 , 1 , 2 , 3
            //4 , 5 , 6 , 7
            //8 , 9 , 10 , 11
            //12 , 13 , 14 , 15

            //����������������
            float temp_x = h_index - ((data.slot_horizontal_num - 1) / 2.0f);
            float temp_y = (data.slot_vertical_num - 1 - v_index) - ((data.slot_vertical_num  - 1)/ 2.0f);
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
                //���̐��������̎�
                if (local_index.x > 0)
                    local_x = (int)(((2 * local_index.x - 1) / 2.0f) * (data.margin_horizontal + slot_rect.x));
                if (local_index.x < 0)
                    local_x = (int)(((2 * local_index.x + 1) / 2.0f) * (data.margin_horizontal + slot_rect.x));
            }
            else
            {
                //���̐�����̎�
                local_x = local_index.x * (data.margin_horizontal + slot_rect.x);

            }

            //define vertical position
            int local_y = 0;
            if (data.slot_vertical_num % 2 == 0)
            {
                //�c�̐��������̎�
                if (local_index.y > 0)
                    local_y = (int)(((2 * local_index.y - 1) / 2.0f) * (data.margin_vertical + slot_rect.y));
                if (local_index.y < 0)
                    local_y = (int)(((2 * local_index.y + 1) / 2.0f) * (data.margin_vertical + slot_rect.y));
            }
            else
            {
                //�c�̐�����̎�
                local_y = local_index.y * (data.margin_vertical + slot_rect.y);

            }

            if (!data.index_igonored.Contains(i))
            {
                _Slots[i].gameObject.transform.localPosition = new Vector3(local_x, local_y, 0);
            }
            
        }
        if(data.extra_slots.Count != 0)
        {
            for(int i = data.slot_horizontal_num * data.slot_vertical_num; i < _Slots.Length;i++)
            {
                _Slots[i] = data.extra_slots[i - data.slot_horizontal_num * data.slot_vertical_num];
                _Slots[i].Slot_index = i;
                _Slots[i].Affiliation = this;
                _Slots[i].SetIcon(null);
            }
        }

    }

    /// <summary>
    /// Return false if slot_index is included in index_ignored 
    /// </summary>
    public bool SetItemToSlot(Items.Item_ID item_ID, int num, int slot_index)
    {
        if (!_Slots[slot_index]) return false;
        item_list[slot_index] = (item_ID, num);
        var n = Resources.Load($"{item_ID}") as Items;
        if (n == null)
        {
            Debug.LogError($"Couldn't find Item Data : {item_ID} in Resources");
            return false;
        }
        _Slots[slot_index].SetIcon(n.icon);
        return true;
    }

    public void ClearSlot(int slot_index)
    {
        if (!_Slots[slot_index]) return;
        item_list[slot_index] = (Items.Item_ID.EmptyObject, 0);
        _Slots[slot_index].SetIcon(null);
    }

    /// <summary>
    /// Return null if slot_index is included in index_ignored 
    /// </summary>
    public (Items.Item_ID id, int amount)? GetSlotItem(int index)
    {
        if (!_Slots[index]) return null;
        return item_list[index];
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
     public Slot GetNearestSlot(Vector3 pos)
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

        if(nearest_dis <= active_range)
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

    public void SetVisible(bool visible)
    {
        if (Slots_Main)
        {
            Slots_Main.SetActive(visible);
        }
        else
        {
            gameObject.SetActive(visible);
        }
    }
    public void SwitchVisible()
    {
        if (Slots_Main)
        {
            Slots_Main.SetActive(!Slots_Main.activeSelf);
        }
        else
        {
            gameObject.SetActive(!gameObject.activeSelf);
        }
    }


#if UNITY_EDITOR
    [SerializeField]
    bool slot_data_editable = false;


#endif
}

#if UNITY_EDITOR
[CustomEditor(typeof(SlotManager))]
class SlotManagerInspector : Editor
{
    SerializedProperty property_slot_editable;

    private void OnEnable()
    {
        var manager = target as SlotManager;
        property_slot_editable = serializedObject.FindProperty("slot_data_editable");

    }

    public override void OnInspectorGUI()
    {
        //  base.OnInspectorGUI();
        serializedObject.Update();
        
        var manager = target as SlotManager;
        using (var check = new EditorGUI.ChangeCheckScope())
        {
            EditorGUILayout.PropertyField(property_slot_editable, new GUIContent("�f�[�^��ҏW"));
            if (check.changed)
            {
                serializedObject.ApplyModifiedProperties();
                if (!property_slot_editable.boolValue)
                {
                    manager.SlotReconstruct();
                }
                serializedObject.Update();

            }

        }

        

        EditorGUI.BeginDisabledGroup(!property_slot_editable.boolValue);

        EditorGUILayout.PropertyField(serializedObject.FindProperty("data"), new GUIContent("�X���b�g�Q�̃f�[�^"));

        EditorGUI.EndDisabledGroup();

        EditorGUILayout.PropertyField(serializedObject.FindProperty("Slots_Main"), new GUIContent("�\���̐؂�ւ���"));

        serializedObject.ApplyModifiedProperties();

    }
}


#endif
