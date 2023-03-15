using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerName : MonoBehaviour
{

    public TextMeshProUGUI PlayerText;

    [SerializeField]
    private TimeSO STSO;
    // Start is called before the first frame update
    void Start()
    {
        PlayerText.text = STSO.PlayerName;
    }
    
}
