using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{

    [SerializeField] float delayInSec = 2f;

    IEnumerator WaL()
    {
        yield return new WaitForSeconds(delayInSec);
        //loads the scene with name GameOver
        SceneManager.LoadScene("GameOver");
    }
    public void LoadStartMenu()
    {
        //loads the first scene in the project that is StartMenu 
        SceneManager.LoadScene(0);
    }

    public void LoadGame()
    {
        //loads CarGame Scene
        SceneManager.LoadScene("CarGame");
    }

    public void LoadGameOver()
    {
        StartCoroutine(WaL());
    }

    public void LoadWinner()
    {
        //loads the scene with name GameOver
        SceneManager.LoadScene("Winner");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
