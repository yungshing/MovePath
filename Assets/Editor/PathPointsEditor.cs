using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
[CustomEditor(typeof(PathPoints))]
public class PathPointsEditor : Editor
{
    static List<GameObject> Gos = new List<GameObject>();
    static GameObject PointsParent = null;
    public override void OnInspectorGUI()
    {
        PathPoints t = target as PathPoints;
        var so = new SerializedObject(target);
        so.Update();
        var cl = so.FindProperty("Points");
        EditorGUILayout.PropertyField(cl,new GUIContent("路径点:"),true);
        so.ApplyModifiedProperties();
        CreatePointsParent(t);
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
            Handles.DrawLines(t.Points.ToArray());
        }
    }

    void CreatePointsParent(PathPoints p)
    {
        if (p.PointsParent == null)
        {
            p.PointsParent = new GameObject("PathPoints");
            p.PointsParent.transform.SetParent(p.transform);
            p.PointsParent.transform.position = Vector3.zero;
            p.PointsParent.transform.localScale = Vector3.one;
            p.PointsParent.transform.rotation = Quaternion.identity;
        }
        PointsParent = p.PointsParent;
    }
    void SetGameObjectsOnSceneGUI(PathPoints p)
    {
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
        if (Gos.Count != p.Points.Count)
        {
            foreach (var item in Gos)
            {
                GameObject.Destroy(item);
            }
            Gos.Clear();
            for (int i  = 0; i  < p.Points .Count; i ++)
            {
                var g = new GameObject("节点:"+i.ToString());
                g.transform.SetParent(PointsParent.transform);
                g.transform.position = Vector3.zero;
                g.transform.localScale = Vector3.one;
                g.transform.rotation = Quaternion.identity;
                g.transform.position = p.Points[i];
                IconManager.SetIcon(g, IconManager.Icon.CircleGreen);
                Gos.Add(g);
            }
        }
        else
        {
            for (int i = 0; i < p.Points.Count; i++)
            {
                Gos[i].transform.position = p.Points[i];
            }
        }
    }
}