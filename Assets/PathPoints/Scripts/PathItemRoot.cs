using UnityEngine;
using System.Collections;
namespace ZTools.ZPathPoints
{
    [ExecuteInEditMode]
    public class PathItemRoot : MonoBehaviour
    {
#if UNITY_EDITOR
        private void Awake()
        {
            if (this.transform .parent .GetComponentsInChildren<PathItemRoot>().Length >=2)
            {
                DestroyImmediate(this);
            }
        }
#endif
    }
}