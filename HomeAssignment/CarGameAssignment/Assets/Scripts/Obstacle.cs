using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] float health = 500f;
    
    [SerializeField] float shotCnt;

    [SerializeField] float minTimeBetShots = 0.2f;

    [SerializeField] float maxTimeBetShots = 3f;

    [SerializeField] GameObject obsLaserPre; // set a diff prefab to one of each obs

    [SerializeField] float ObsLaserSpeed = 3f; //speed for laster of obstacle

    //Obstacles have no health and therefore when it hits the car, obstacle should be destroyed.
    //Has a DamageDealer components
    private void OnTriggerEnter2D(Collider2D otherObj)
    {
        //accesses the damage dealer calss from other objects.
        DamageDealer damageDeal = otherObj.gameObject.GetComponent<DamageDealer>();


        ProHit(damageDeal);

    }

    private void ProHit(DamageDealer damageDeal)
    {
        health -= damageDeal.GetDamage();
        
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }


    void Start()
    {
        //generate a random number
        shotCnt = Random.Range(minTimeBetShots, maxTimeBetShots);   
    }

    private void Update()
    {
        
        CntDownAndShoot();
    }

    private void CntDownAndShoot()
    {
        //every frame reduce the amount of time for shot
        shotCnt -= Time.deltaTime;

        if (shotCnt <= 0f)
        {
            ObsFire();
            //reset shotCnt

            shotCnt = Random.Range(minTimeBetShots, maxTimeBetShots);
        }
    }

    private void ObsFire()
    {
        //spawn an obs laser at obs pos
        GameObject obsLaser = Instantiate(obsLaserPre, transform.position, Quaternion.identity) as GameObject;

        //shoot laser downwards
        obsLaser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -ObsLaserSpeed);
    }


}

