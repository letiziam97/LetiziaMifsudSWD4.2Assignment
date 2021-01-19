using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shredder : MonoBehaviour
{

    //obs + lasers will be destroyed once it touches the trigger.
    private void OnTriggerEnter2D(Collider2D otherobj)
    { 
        Destroy(otherobj.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print(collision.gameObject.name);
        Destroy(collision.gameObject);
    }

}

