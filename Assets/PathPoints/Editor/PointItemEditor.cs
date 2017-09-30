using UnityEngine;
using UnityEditor;
namespace ZTools.ZPathPoints
{
    [CustomEditor(typeof(PointItem))]
    public class PointItemEditor : Editor
    {
        public override void OnInspectorGUI()
        {
        }

        private void OnSceneGUI()
        {
            PointItem t = target as PointItem;
            Handles.Label(t.transform.position + PathEditorTools.PointLabelPos, t.transform.position.ToString(), PathEditorTools.GUIStyle);
            if (Handles.Button(t.transform.position, Quaternion.identity, 15, 15, CapFunction))
            {
                Debug.Log("asdf");
                Handles.BeginGUI();
                GUILayout.Button("test");
                Handles.EndGUI();
                if (Input.GetMouseButtonDown(1))
                {
                    Handles.BeginGUI();
                    GUILayout.Button("test");
                    Handles.EndGUI();
                }
            }
        }

        private void CapFunction(int controlID, Vector3 position, Quaternion rotation, float size, EventType eventType)
        {

        }
    }
}