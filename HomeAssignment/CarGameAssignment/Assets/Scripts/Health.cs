using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    //updates the Text in UI
    Text TextPlayerHealth;
    Player pl;


    void Start()
    {
        TextPlayerHealth = GetComponent<Text>();
        pl = FindObjectOfType<Player>();
    }

    void Update()
    {
        //to display score in the canvas, from int to string.
        TextPlayerHealth.text = pl.GetHealth().ToString();
    }

}
