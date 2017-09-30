using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
namespace ZTools.ZPathPoints
{
    [CustomEditor(typeof(PathPoints))]
    public class PathPointsEditor : Editor
    {
        List<PointItem> Gos = new List<PointItem>();
        GameObject PointsRoot = null;
        public override void OnInspectorGUI()
        {
            PathPoints t = target as PathPoints;
            var so = new SerializedObject(target);
            so.Update();
            var cl = so.FindProperty("Points");
            EditorGUILayout.PropertyField(cl, new GUIContent("路径点:"), true);
            so.ApplyModifiedProperties();
            CreatePointsRoot(t);
            SetGameObjectsOnInspectorGUI(t);
        }
        private void OnSceneGUI()
        {
            PathPoints t = target as PathPoints;
            SetGameObjectsOnSceneGUI(t);
            if (t.Points.Count == 1)
            {
                Handles.Label(t.Points[0] + Vector3.up * 2, "点");
            }
            else if (t.Points.Count > 1)
            {
                for (int i = 0; i < t.Points.Count; i++)
                {
                    Handles.Label(t.Points[i] + Vector3.up * 0.3f, "节点" + i.ToString() + ":" + t.Points[i].ToString());
                }
                //Handles.DrawLines(t.Points.ToArray());
            }
            Vector3[] v3 = new Vector3[] { Vector3.one,Vector3.up};
            Handles.DrawLines(v3);
        }


        void CreatePointsRoot(PathPoints p)
        {
            var v = p.GetComponentInChildren<PathItemRoot>();
            if (v == null)
            {
                PointsRoot = new GameObject("PathPoints");
                PointsRoot.transform.SetParent(p.transform);
                PointsRoot.transform.position = Vector3.zero;
                PointsRoot.transform.localScale = Vector3.one;
                PointsRoot.transform.rotation = Quaternion.identity;
                v = PointsRoot.AddComponent<PathItemRoot>();
            }
            PointsRoot = v.gameObject;
        }
        void SetGameObjectsOnSceneGUI(PathPoints p)
        {
            Gos = new List<PointItem>(p.transform.GetComponentsInChildren<PointItem>());
            if (Gos.Count != p.Points.Count)
            {
                p.Points.Clear();
                for (int i = 0; i < Gos.Count; i++)
                {
                    p.Points.Add(Gos[i].transform.position);
                }
            }
            else
            {
                for (int i = 0; i < Gos.Count; i++)
                {
                    p.Points[i] = Gos[i].transform.position;
                }
            }
        }

        void SetGameObjectsOnInspectorGUI(PathPoints p)
        {
            Gos = new List<PointItem>(p.transform.GetComponentsInChildren<PointItem>());
            var v = Gos.Count - p.Points.Count;
            if (v > 0)
            {
                for (int i = 0; i < v; i++)
                {
                    DestroyImmediate(Gos[i].gameObject);
                }
            }
            else if (v < 0)
            {
                for (int i = 0; i < -v; i++)
                {
                    var g = new GameObject("节点:" + i.ToString());
                    g.transform.SetParent(PointsRoot.transform);
                    g.transform.position = Vector3.zero;
                    g.transform.localScale = Vector3.one;
                    g.transform.rotation = Quaternion.identity;
                    g.transform.position = p.Points[i];
                    var m = g.AddComponent<PointItem>();
                    Gos.Add(m);
                }
                PathEditorTools.SetIcon(Gos.ToArray(),p.Index);
            }
            Gos = new List<PointItem>(p.transform.GetComponentsInChildren<PointItem>());
            for (int i = 0; i < p.Points.Count; i++)
            {
                Gos[i].transform.position = p.Points[i];
                Gos[i].transform.name = "节点:" + i.ToString();
            }
        }
    }
}