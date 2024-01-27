using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody playerRb;
    [SerializeField] float upwardsThrust = 50f;
    [SerializeField] float rotationThrust = 1.0f;
    
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
            playerRb.AddRelativeForce(Time.deltaTime * upwardsThrust * Vector3.up);
        }  
    }

    void GetPlayerRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(rotationThrust * Time.deltaTime * Vector3.forward);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(rotationThrust * Time.deltaTime * Vector3.back);
        }
    }
}
