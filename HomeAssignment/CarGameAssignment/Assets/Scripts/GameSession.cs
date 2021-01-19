using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    int plscore = 0;


    void Awake()
    {
        SetUpSingleton();
    }

    private void SetUpSingleton()
    {
        int noOfGameSess = FindObjectsOfType<GameSession>().Length;
        //making sure that only 1 GameSession is running 
        if(noOfGameSess > 1 )
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }


    //to get score
    public int GetScore()
    {
        return plscore;
    }

    //add scorevalue from outside the script to score 
    public void AddToScore(int scoreVal)
    {
        plscore += scoreVal;
        print(plscore);
    }

    //Reset Game
    public void ResetGame()
    {
        Destroy(gameObject);
    }


}
