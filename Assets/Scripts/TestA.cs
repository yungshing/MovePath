using UnityEngine;
using System.Collections.Generic;
using System;
public class TestA : MonoBehaviour
{
    public int T_int = 1;
    public int[] TA_int = new int[] { 1, 2 };
    public long T_long = 2;
    public float T_float = 3;
    public string T_String = "5";
    public Transform T_Transform;
    public Vector3 T_Vector3 = new Vector3(1, 1, 1);
    public List<Vector3> TL_Vector3 = new List<Vector3>();
    public ETest T_Enum = ETest.T1;
    [SerializeField]
    public MClass T_class;

    public enum ETest
    {
        Null = 0,
        T1,
        T2,
        T3
    }
}
[Serializable]
public class MClass
{
    public int T_int = 1;
    public string T_String = "12";
    public Transform T_Transform;
}