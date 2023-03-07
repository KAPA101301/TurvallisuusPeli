using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private void Awake()
    {
        EventSystem.Instance.RegisterToEvent("score-event", onFinished);
    }

    public void onFinished(object score)
    {
        // Score
        Debug.Log("Score Test success");

        // Set score to list in here (registers when called with triggerEvent)
    }
}
