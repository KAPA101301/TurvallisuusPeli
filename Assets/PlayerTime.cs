using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerTime : MonoBehaviour
{

    public TextMeshProUGUI timerText;

    [SerializeField]
    private TimeSO STSO;
    // Start is called before the first frame update
    void Start()
    {
        timerText.text = STSO.Minutes.ToString("00") + ":" + STSO.Seconds.ToString("00") + ":" + STSO.MilliSeconds.ToString("000");
    }
    
}
