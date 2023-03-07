using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoTextHandler : MonoBehaviour
{
    public List<GameObject> infoTexts;
    private bool isActive = false;

    private void Awake()
    {
        infoTexts.AddRange(GameObject.FindGameObjectsWithTag("InfoText"));
        for(int i = 0; i < infoTexts.Count; i++)
        {
            infoTexts[i].SetActive(false);
        }
    }

    public void infoText()
    {
        isActive = !isActive;
        for (int i = 0; i < infoTexts.Count; i++)
        {
            infoTexts[i].SetActive(isActive);
        }
    }
}
