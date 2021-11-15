using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    private Transform playerTransform;
    private Vector3 tempPos; // temp position of the camera

    [SerializeField]
    private float minX, maxX;

    
    void Start()
    {
        playerTransform = GameObject.FindWithTag("Player").transform;  // get the transform component of the player
    }

    // gets called after Update() Calculations are done (in Player.cs script)
    void LateUpdate()  
    {

        if (!playerTransform) // if it's null
        {
            return;
        }

        tempPos = transform.position; // the first position of the camera
        tempPos.x = playerTransform.position.x; // position of the player

        if (tempPos.x <= minX)
            tempPos.x = minX;

        if (tempPos.x >= maxX)
            tempPos.x = maxX;

        transform.position = tempPos;

    }
}
