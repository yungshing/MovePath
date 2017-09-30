using UnityEngine;
using UnityEditor;
namespace ZTools.ZPathPoints
{
    [CustomEditor(typeof(PathItemRoot))]
    public class PathItemRootEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            PathItemRoot t = target as PathItemRoot;
            if (t.gameObject .name != PathEditorTools.PointItemRootName)
            {
                t.gameObject.name = PathEditorTools.PointItemRootName;
            }
        }
    }
}