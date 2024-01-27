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
            playerRb.freezeRotation = true; //freezing rotation to manually rotate.
            transform.Rotate(rotationThrust * Time.deltaTime * Vector3.forward);
            playerRb.freezeRotation = false; //unfreeze so unity physics takes over.
        }
        else if (Input.GetKey(KeyCode.D))
        {
            playerRb.freezeRotation = true;
            transform.Rotate(rotationThrust * Time.deltaTime * Vector3.back);
            playerRb.freezeRotation = false;
        }
    }
}
