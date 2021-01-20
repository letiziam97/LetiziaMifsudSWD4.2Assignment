using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] int obsDamage = 0;

    //returns the amount of damage
    public int GetDamage()
    {
        return obsDamage;
    }

    //destroys the gameObject
    public void Hit()
    {
        Destroy(gameObject);
    }


}
