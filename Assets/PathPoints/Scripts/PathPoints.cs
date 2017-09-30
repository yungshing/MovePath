using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace ZTools.ZPathPoints
{
    [ExecuteInEditMode]
    public class PathPoints : MonoBehaviour
    {
        /// <summary>
        /// 路径点
        /// </summary>
        public List<Vector3> Points = new List<Vector3>();

        public int Index = 0;

        private void Start()
        {
            var v = GameObject.FindObjectsOfType<PathPoints>();
            Index = v.Length - 1;
        }
    }
}