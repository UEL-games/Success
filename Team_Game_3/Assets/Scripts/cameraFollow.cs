using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    //Public variable to store a reference to the player game object
    public GameObject player;   
    //Private variable to store the offset distance between the player and camera
    public Vector3 offset;
    private float minOffset = 1.28f;
    private float maxOffset = 16.28f;
    public Transform target;




    // Use this for initialization
    void Start()
    {
        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        offset = transform.position - player.transform.position;

    }

    private void Update()
    {
            MouseWheelScroll();
    }

    // LateUpdate is called after Update each frame
    void LateUpdate()
    {
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        transform.position = player.transform.position + offset;

    
    }

    void MouseWheelScroll()
    {
        if ((Input.GetAxis ("Mouse ScrollWheel") > 0) && offset.y > minOffset)
        {
                offset += new Vector3(0, -1, 1); 
        }

        if ((Input.GetAxis("Mouse ScrollWheel") < 0) && offset.y < maxOffset)
        {
                offset += new Vector3(0, 1, -1);
        }

    }
}
