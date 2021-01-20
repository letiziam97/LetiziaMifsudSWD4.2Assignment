using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{

    [SerializeField] float delayInSec = 2f;  
    [SerializeField] float delayInSecond = 0.5f;

    IEnumerator WaL()
    {
        yield return new WaitForSeconds(delayInSec);
        //loads the scene with name GameOver
        SceneManager.LoadScene("GameOver");
    }

    IEnumerator WaLWin()
    {
        yield return new WaitForSeconds(delayInSecond);
        //loads the scene with name Winner
        SceneManager.LoadScene("WinnerGame");
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

        //reset the GameSession from the beginning
        FindObjectOfType<GameSession>().ResetGame();
    }

    public void LoadGameOver()
    {
        StartCoroutine(WaL());
    }

    public void LoadWinner()
    {
        //loads the co routine
        StartCoroutine(WaLWin());
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
