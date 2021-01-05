using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.XR.WSA.Input;

public class Player : MonoBehaviour
{
    //creating variable without intialisation
    float MinX, MaxX, MinY, MaxY;

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

    //Generated the method for the ViewPortToWordPoint() - setting up the boundaries according to the camera
    private void SetUpMoveBoundaries()
    {
        //gameCamera is a variable (it is an object) - getting camera from Unity
        Camera boundCam = Camera.main;

        //setting up variable according to the camera therefore 
        //xMin = 0, xMax = 1
        MinX = boundCam.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + pad;
        MaxX = boundCam.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - pad;

        //yMin = 0, yMax = 0
        MinY = boundCam.ViewportToWorldPoint(new Vector3(0, -4 , 0)).y + pad;
        MaxY = boundCam.ViewportToWorldPoint(new Vector3(0, -4, 0)).y - pad;

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
