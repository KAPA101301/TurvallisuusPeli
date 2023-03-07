using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
public class TimeSO : ScriptableObject
{
    [SerializeField]
    private float m_Time;

    public float Time
    {
        get { return m_Time; }
        set { m_Time = value; }
    }

}
