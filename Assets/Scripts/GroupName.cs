using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GroupName : MonoBehaviour
{

    public TextMeshProUGUI GroupText;

    [SerializeField]
    private TimeSO STSO;
    // Start is called before the first frame update
    void Start()
    {
        //Keskeneräinen -> placeholder
        GroupText.text = "Group A";
    }
    
}
