using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    public void LoadStartMenu()
    {
        //loads the first scene in the project that is StartMenu 
        SceneManager.LoadScene("StartMenu");
    }

    public void LoadGame()
    {
        //loads CarGame Scene
        SceneManager.LoadScene("CarGame");
    }

    public void LoadGameOver()
    {
        //loads the scene with name GameOver
        SceneManager.LoadScene("GameOver");
    }    

    public void QuitGame()
    {
        Application.Quit();
    }
}
