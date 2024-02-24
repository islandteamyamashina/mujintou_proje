using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ForEditor))]
public class TestEditor : Editor
{
    GUIContent boolLabel;
    SerializedProperty isA_Prop;

    GUIContent intLabel;
    SerializedProperty count_Prop;

    GUIContent stringLabel;
    SerializedProperty str_Prop;

    GUIContent listLabel;
    SerializedProperty values_Prop;

    private void OnEnable()
    {
        boolLabel = new GUIContent("Boolの値", "toolTip");
        isA_Prop = serializedObject.FindProperty("isA");

        intLabel = new GUIContent("intの値");
        count_Prop = serializedObject.FindProperty("count");

        stringLabel = new GUIContent("Stringの値");
        str_Prop = serializedObject.FindProperty("str");

        listLabel = new GUIContent("listの値");
        values_Prop = serializedObject.FindProperty("values");

        
    }

    public override void OnInspectorGUI()
    {
        //base.OnInspectorGUI();

        // 最新データを取得
        serializedObject.Update();

        EditorGUILayout.PropertyField(isA_Prop, boolLabel);

        if (isA_Prop.boolValue)
        {
            EditorGUILayout.PropertyField(count_Prop, intLabel);
            EditorGUILayout.PropertyField(str_Prop, stringLabel);
            EditorGUILayout.PropertyField(values_Prop, listLabel);

        }

        // 変更点を反映させる
        serializedObject.ApplyModifiedProperties();
    }
}
