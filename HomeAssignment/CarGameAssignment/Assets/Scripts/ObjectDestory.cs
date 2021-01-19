using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestory : MonoBehaviour
{
    [SerializeField] int pts = 5;
    [SerializeField] AudioClip obsAvoided;
    [SerializeField] [Range(0, 1)] float obsAvoidedVol = 0.5f;

    private void OnTriggerEnter2D(Collider2D otherobj)
    {

        AudioSource.PlayClipAtPoint(obsAvoided, Camera.main.transform.position, obsAvoidedVol);

        //adding to score ie pts 
        FindObjectOfType<GameSession>().AddToScore(pts);

    }


}
