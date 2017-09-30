using UnityEngine;
using UnityEditor;
using System.Collections;
namespace ZTools.ZPathPoints
{
    public class PathEditorTools
    {
        public static Vector3 PointLabelPos = new Vector3(0, 0.5f, 0);
        public static IconManager.Icon PointIcon = IconManager.Icon.DiamondGreen;
        public static string PointItemRootName = "PointsRoot";
        /// <summary>
        /// 
        /// </summary>
        /// <param name="p"></param>
        /// <param name="i">IconManager.Icon 枚举</param>
        public static void SetIcon<T>(T[] p,int i) where T : MonoBehaviour
        {
            foreach (var item in p)
            {
                IconManager.SetIcon(item.gameObject,(IconManager.Icon)i);
            }
        }
        private static GUIStyle guiStyle = null;
        public static GUIStyle GUIStyle
        {
            get
            {
                if (guiStyle == null)
                {
                    guiStyle = new GUIStyle();
                    guiStyle.normal.textColor = Color.red;
                    guiStyle.fontSize = 10;
                }
                return guiStyle;
            }
        }

        public static void DrawLines()
        {
            var p = GameObject.FindObjectsOfType<PathPoints>();
            foreach (var item in p)
            {
                var root = item.GetComponentInChildren<PathItemRoot>();

                for (int i = 0; i < item.Points.Count; i++)
                {
                    
                }
            }
        }
    }
}