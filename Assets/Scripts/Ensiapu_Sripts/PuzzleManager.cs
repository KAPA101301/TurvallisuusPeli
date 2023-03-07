using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public static Dictionary<int, int> puzzlePairs;
    public GameObject winScreen;

    private void Awake()
    {
        EventSystem.Instance.RegisterToEvent("gameWon", onWin);
    }

    public void onWin(object data)
    {
        // Something
        Debug.Log("Finished with time: " + data + " seconds");
        winScreen.SetActive(true);
    }
}
