using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody playerRb;
    
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveZ = 1, moveX = 1;
        GetPlayerThrust(moveZ);
        GetPlayerRotation(moveX);
    }

    void GetPlayerThrust(float moveZ)
    {
        if (Input.GetKey(KeyCode.Space))
        {
            playerRb.AddRelativeForce(Vector3.up);
        }  
    }

    void GetPlayerRotation(float moveX)
    {
        if (Input.GetKey(KeyCode.A))
        {
            //make player rotate left
        }
        else if (Input.GetKey(KeyCode.D))
        {
            //make player rotate right
        }
    }
}
