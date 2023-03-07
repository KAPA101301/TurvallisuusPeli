using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public static float timePassed = 0;

    public TextMeshProUGUI timerText;

    [SerializeField]
    private TimeSO scoreTimeSO;

    private void Start()
    {
        //nollataan timer levelin alkuun
        timePassed = 0;
    }
    // Update is called once per frame
    void Update()
    {
        timePassed += Time.deltaTime;
        int seconds = Mathf.FloorToInt(timePassed % 60);
        int minutes = Mathf.FloorToInt(timePassed / 60);     //Seconds -> mills //minutes -> sec -> mills
        int milliseconds = Mathf.FloorToInt(timePassed * 1000 - seconds*1000 - minutes*60*1000);

        // Added milliseconds
        timerText.text = minutes.ToString("00") + ":" + seconds.ToString("00") + ":" + milliseconds.ToString("000");

        //Push values to ScriptalbeObject TimoSO
        scoreTimeSO.Minutes = minutes;
        scoreTimeSO.Seconds = seconds;
        scoreTimeSO.MilliSeconds = milliseconds;
        //Debug.Log(timePassed);

        if(timePassed > 10)
        {
            EventSystem.Instance.TriggerEvent("score-event", timePassed);
        }
    }
}
