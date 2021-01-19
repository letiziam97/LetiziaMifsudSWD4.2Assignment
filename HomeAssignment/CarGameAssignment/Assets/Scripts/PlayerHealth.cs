using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    //updates the Text in UI
    Text PlayerHealthTxt;
    Player player;

    
    void Start()
    {
        PlayerHealthTxt = GetComponent<Text>();
        player = FindObjectOfType<Player>();
    }

    void Update()
    {
        //to display score in the canvas, from int to string.
        PlayerHealthTxt.text = player.GetHealth().ToString();    
    }

}
