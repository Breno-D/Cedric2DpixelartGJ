using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    
    public void Play()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");      
    }

    public void Exit()
    {
        Application.Quit();
    }
}
