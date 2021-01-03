using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScoller : MonoBehaviour
{
    [SerializeField] float bkgdScrollSpeed = 1f;

    //the material from the texture
    Material myMaterial;

    //movement offSetss
    Vector2 offSet;
    void Start()
    {
        //getting the material from the renderer component
        myMaterial = GetComponent<Renderer>().material;

        //move in the y-axis -same speed as racing car
        offSet = new Vector2(0f, bkgdScrollSpeed);
    }

    
    void Update()
    {
        //move the mateiral by offset every frame
        myMaterial.mainTextureOffset += offSet * Time.deltaTime;
    }
}
