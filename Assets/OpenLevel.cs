using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenLevel : MonoBehaviour
{
    public string SceneName;
    
    public void LoadScene()
    {
        SceneManager.LoadScene(SceneName);
    }
}
