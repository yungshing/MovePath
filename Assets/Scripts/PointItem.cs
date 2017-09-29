using UnityEngine;
using System.Collections;

public class PointItem : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
#if !UNITY_EDITOR
        GameObject.Destroy(this);
#endif
    }
}
