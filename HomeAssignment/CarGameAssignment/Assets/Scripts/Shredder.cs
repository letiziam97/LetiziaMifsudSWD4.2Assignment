using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shredder : MonoBehaviour
{

    //laser will be destroyed once it touches the trigger.
    private void OnTriggerEnter2D(Collider2D otherobj)
    {
        Destroy(otherobj.gameObject);
    }


}

