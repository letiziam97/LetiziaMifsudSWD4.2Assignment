﻿using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.XR.WSA.Input;

public class Player : MonoBehaviour
{
    [SerializeField] float health = 50f;

    [SerializeField] AudioClip playerHealthRed;

    [SerializeField] [Range(0, 1)] float playerHealthRedVol = 0.75f;  //sound between 0 and 1 > Volume 

    [SerializeField] public static int pts = 0;

    [SerializeField] AudioClip obstacleAvoided;

    [SerializeField] [Range(0, 1)] float obstacleAvoidedVol = 0.50f;




    //creating variable without intialisation
    float MinX, MaxX;

    //This is a variable that can be edited from Unity
    [SerializeField] float movingSpeed = 1f;
    [SerializeField] float pad = 1f;

    void Start()
    {
        //Calling ViewPortToWordPoint() 
        SetUpMoveBoundaries();

    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }


    //reduces health whenever the player collides with a gameObj
    //and reduces its healh accordingly

    private void OnTriggerEnter2D(Collider2D otherObj)
    {
        //accesses the damage dealer calss from other objects.
        DamageDealer damageDeal = otherObj.gameObject.GetComponent<DamageDealer>();
        ProHit(damageDeal);

    }

    private void ProHit(DamageDealer damageDeal)
    {
        health -= damageDeal.GetDamage();
        damageDeal.Hit();

        //Playing the sound as soon as the player dies
        AudioSource.PlayClipAtPoint(playerHealthRed, Camera.main.transform.position, playerHealthRedVol);
       
        if (health <= 0)
        {
            Destroy(gameObject);
        }

    }

    private void OnTriggerEnter2D(Collider target)
    {
        if (target.gameObject.tag.Equals("laser") == false)
        {
            //audio of player gaining points 
            AudioSource.PlayClipAtPoint(obstacleAvoided, Camera.main.transform.position, obstacleAvoidedVol);
            Player.pts += 5;
        }

    }


    //Generated the method for the ViewPortToWordPoint() - setting up the boundaries according to the camera
    private void SetUpMoveBoundaries()
    {
        //gameCamera is a variable (it is an object) - getting camera from Unity
        Camera boundCam = Camera.main;

        //setting up variable according to the camera therefore 
        //xMin = 0, xMax = 1
        MinX = boundCam.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + pad;
        MaxX = boundCam.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - pad;

    }

    //Moves the PlayerCar Around
    private void Move()
    {
        //movementX = movement in x axis ie left and right
        var movementX = Input.GetAxis("Horizontal") * Time.deltaTime * movingSpeed;

        //current position of PlayerCar, + difference in X by keyboard input
        //Clamping the position - Clamps the min float and the max float values.
        var newPosX = Mathf.Clamp(transform.position.x + movementX, MinX, MaxX);


        //movementY = so that the car does not move in the y axis ie up and down 
        float movementY = -4;


        //Update the position of the player
        this.transform.position = new Vector2(newPosX, movementY);

    }
}
