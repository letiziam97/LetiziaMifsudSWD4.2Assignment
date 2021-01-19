using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreGame : MonoBehaviour
{
    //used to update the text in the UI
    Text textscore;

    GameSession sessionGame;

    void Start()
    {
        textscore = GetComponent<Text>();
        sessionGame = FindObjectOfType<GameSession>();
    }

    void Update()
    {
        //changing from int to string 
        textscore.text = sessionGame.GetScore().ToString();
    }
}
