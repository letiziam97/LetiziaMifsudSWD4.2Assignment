using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestory : MonoBehaviour
{
    [SerializeField] int pts = 5;
    [SerializeField] AudioClip obsAvoided;
    [SerializeField] [Range(0, 1)] float obsAvoidedVol = 0.5f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //audio when obs touch other shredder
        AudioSource.PlayClipAtPoint(obsAvoided, Camera.main.transform.position, obsAvoidedVol);

        //adding 5 pts to pts ie score 
        FindObjectOfType<GameSession>().AddToScore(pts);

    }

}
