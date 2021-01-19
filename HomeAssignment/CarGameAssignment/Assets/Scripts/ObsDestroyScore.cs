using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obs : MonoBehaviour
{
    [SerializeField] int scoreVal = 5;
    [SerializeField] AudioClip obsAvoided;
    [SerializeField] [Range(0, 1)] float obsAvoidedVol = 0.5f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        AudioSource.PlayClipAtPoint(obsAvoided, Camera.main.transform.position, obsAvoidedVol);

        //adding to score ie pts 
        FindObjectOfType<GameSession>().AddToScore(scoreVal);
    }

}
