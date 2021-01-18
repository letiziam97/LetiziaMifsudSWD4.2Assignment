using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScoller : MonoBehaviour
{
    [SerializeField] float bkgdScrollSpeed = 1f;


    [SerializeField] AudioClip bkgroundClip;

    [SerializeField] [Range(0, 1)] float bkgroundClipVol = 0.75f;  //sound between 0 and 1 > Volume 


    //the material from the texture
    Material myMaterial;

    //movement offSetss
    Vector2 offSet;
    void Start()
    {
        //Playing the sound in the background
        AudioSource.PlayClipAtPoint(bkgroundClip, Camera.main.transform.position, bkgroundClipVol);

        //getting the material from the renderer component
        myMaterial = GetComponent<Renderer>().material;

        //move in the y-axis -same speed as racing car
        offSet = new Vector2(0f, bkgdScrollSpeed);
    }

    
    void Update()
    {
        //move the material by offset every frame
        myMaterial.mainTextureOffset += offSet * Time.deltaTime;
    }
}
