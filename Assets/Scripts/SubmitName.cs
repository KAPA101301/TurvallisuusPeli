using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.UIElements.UxmlAttributeDescription;

public class SubmitName : MonoBehaviour
{
    public TextMeshProUGUI NameInput;
    public GameObject GroupInput;

    [SerializeField]
    private TimeSO STSO;
    public void Confirm()
    {
        STSO.PlayerName = NameInput.text;
    }
  
}
