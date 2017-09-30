using UnityEngine;
using System.Collections;
namespace ZTools.ZPathPoints
{
#if UNITY_EDITOR
    [ExecuteInEditMode]
    public class PointItem : MonoBehaviour
    {
        private void OnDestroy()
        {
            //DestroyImmediate(this.gameObject);
        }
    }
#endif
}