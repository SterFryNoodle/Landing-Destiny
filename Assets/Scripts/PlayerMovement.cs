using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody playerRb;
    [SerializeField] float upwardsThrust = 50f;
    
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        GetPlayerThrust();
        GetPlayerRotation();
    }

    void GetPlayerThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            playerRb.AddRelativeForce(Vector3.up * upwardsThrust * Time.deltaTime);
        }  
    }

    void GetPlayerRotation()
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
