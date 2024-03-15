using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class CraftSlots : SlotManager
{
    [SerializeField]
    Slot craft_output_slot;

    bool output_slot_has_item = false;

    protected override void Start()
    {
        SetItemToSlot(Items.Item_ID.Plank, 1, 3);
    }


    protected override void Update()
    {
        base.Update();
        output_slot_has_item = craft_output_slot.Affiliation
            .GetSlotItem(craft_output_slot.Slot_index).Value.id == Items.Item_ID.EmptyObject;
        for(int i = 0; i < 3; i++)
        {
            _Slots[i].can_place_item = output_slot_has_item;
        }
    }

    public void DoCraft()
    {
        
    }

}


#if UNITY_EDITOR
[CustomEditor(typeof(CraftSlots))]
class CraftSlotsInspector : Editor
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
            EditorGUILayout.PropertyField(property_slot_editable, new GUIContent("データを編集"));
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

        EditorGUILayout.PropertyField(serializedObject.FindProperty("data"), new GUIContent("スロット群のデータ"));

        EditorGUI.EndDisabledGroup();

        EditorGUILayout.PropertyField(serializedObject.FindProperty("Slots_Main"), new GUIContent("表示の切り替え元"));

        EditorGUILayout.PropertyField(serializedObject.FindProperty("craft_output_slot"), new GUIContent("output slot"));

        serializedObject.ApplyModifiedProperties();

    }
}



#endif