using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    //This runs before start
   void Awake()
   {
        SetupSingleton();
   }

    private void SetupSingleton()
    {
        //get type of Music Player (ie object attached to the script
        if (FindObjectsOfType(GetType()).Length > 1 )
        {
            //if there is more than one music player, destroy the last one
            Destroy(gameObject);
        }
        else
        {
            //dont destory the object ie Music when changing scenes 
            DontDestroyOnLoad(gameObject);
        }
    }

}
