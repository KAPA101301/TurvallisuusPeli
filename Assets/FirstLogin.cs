using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstLogin : MonoBehaviour
{
    public GameObject InfoMenu;
    public GameObject MainMenu;

    [SerializeField]
    private TimeSO STSO;

    private void Start()
    {
        //Jos pelaajalla ei ole nimeä mene inforuutuun
        if(STSO.PlayerName == null)
        {
            InfoMenu.SetActive(true);
            MainMenu.SetActive(false);
        }
        //Jos pelaajalla on nimi niin Mene suoraan mainmenuun
        else
        {
            InfoMenu.SetActive(false);
            MainMenu.SetActive(true);
        }
    }


}
