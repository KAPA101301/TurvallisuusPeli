using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
public class TimeSO : ScriptableObject
{
    [SerializeField]
    private float Min;
    [SerializeField]
    private float Sec;
    [SerializeField]
    private float Mills;

    public float Minutes
    {
        get { return Min; }
        set { Min = value; }
    }
    public float Seconds
    {
        get { return Sec; }
        set { Sec = value; }
    }
    public float MilliSeconds
    {
        get { return Mills; }
        set { Mills = value; }
    }

}
