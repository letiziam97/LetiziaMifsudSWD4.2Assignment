using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleS : MonoBehaviour
{
    [SerializeField] float health;

    [SerializeField] GameObject deathVFX; //Death Visual Effects

    [SerializeField] float explosionDur = 1f; // how long it will take for the exlopsion to be in the scene


    //Obstacles have no health and therefore when it hits the car, obstacle should be destroyed.
    //Has a DamageDealer components
    private void OnTriggerEnter2D(Collider2D otherObj)
    {


        //accesses the damage dealer calss from other objects.
        DamageDealer damageDeal = otherObj.gameObject.GetComponent<DamageDealer>();

        //instantiate explosion effects
        GameObject explosion = Instantiate(deathVFX, transform.position, Quaternion.identity);

        //remove the exlopsion from the hierarchy after 1 sec
        Destroy(explosion, explosionDur);

        Die();
    }


    private void ProHit(DamageDealer damageDeal)
    {
        health -= damageDeal.GetDamage();

        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        //destory gameObject
        Destroy(gameObject);

    }

}
