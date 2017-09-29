using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(TestA))]
public class TestAEditor : Editor
{
    public override void OnInspectorGUI()
    {
        TestA t = target as TestA;
        var so = new SerializedObject(target);
        so.Update();
        t.T_int = EditorGUILayout.IntField("整形", t.T_int);
        var ctai = so.FindProperty("TA_int");
        EditorGUILayout.PropertyField(ctai, new GUIContent("整形数组([])"), true);
        t.T_long = EditorGUILayout.LongField("长整形", t.T_long);
        t.T_float = EditorGUILayout.FloatField("浮点形", t.T_float);
        t.T_String = EditorGUILayout.TextField("字符串", t.T_String);
        t.T_Transform = (Transform)EditorGUILayout.ObjectField("组件", t.T_Transform, typeof(Transform), true) as Transform;
        t.T_Vector3 = EditorGUILayout.Vector3Field("向量", t.T_Vector3);
        var ctav = so.FindProperty("TL_Vector3");
        EditorGUILayout.PropertyField(ctav, new GUIContent("向量数组(List)"), true);
        t.T_Enum = (TestA.ETest)EditorGUILayout.EnumPopup("单项选择枚举", t.T_Enum);
        var mClass = so.FindProperty("T_class");
        EditorGUILayout.PropertyField(mClass,new GUIContent("序列化类"),true);
        so.ApplyModifiedProperties();
    }
}