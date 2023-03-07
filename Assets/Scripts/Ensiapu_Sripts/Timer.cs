using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public static float timePassed = 0;

    public TextMeshProUGUI timerText;

    // Update is called once per frame
    void Update()
    {
        timePassed += Time.deltaTime;
        int seconds = Mathf.FloorToInt(timePassed % 60);
        int minutes = Mathf.FloorToInt(timePassed / 60);

        timerText.text = minutes.ToString("00") + ":" + seconds.ToString("00");

        if(timePassed > 10)
        {
            EventSystem.Instance.TriggerEvent("score-event", timePassed * 100);
        }
    }
}
