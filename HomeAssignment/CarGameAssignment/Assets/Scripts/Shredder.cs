using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shredder : MonoBehaviour
{
    //laser will be destroyed once it touches the trigger.
    private void OnTriggerEnter2D(Collider2D otherobj)
    {
        DamageDealer damageDeal = otherobj.gameObject.GetComponent<DamageDealer>();

        Destroy(otherobj.gameObject);
    }


}



//reduces health whenever an obstacle collides with a gameObj
//and reduces its healh accordingly

private void OnTriggerEnter2D(Collider2D otherObj)
{
    //accesses the damage dealer calss from other objects.
    DamageDealer damageDeal = otherObj.gameObject.GetComponent<DamageDealer>();

    //if there is no damageDeal in otherObj, end the method
    if (!damageDeal) // damangeDeal == null
    {
        return; //it will end the method
    }

    ProHit(damageDeal);

}

private void ProHit(DamageDealer damageDeal)
{
    health -= damageDeal.GetDamage();

    if (health <= 0)
    {
        //Playing the sound as soon as the player dies
        AudioSource.PlayClipAtPoint(playerHealthRed, Camera.main.transform.position, playerHealthRedVol);

        Destroy(gameObject);
    }

}
