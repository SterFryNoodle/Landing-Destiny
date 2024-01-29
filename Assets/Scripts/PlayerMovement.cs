using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{    
    [SerializeField] float upwardsThrust = 50f;
    [SerializeField] float rotationThrust = 1.0f;
    [SerializeField] AudioClip rocketEngine;
    [SerializeField] ParticleSystem mainBooster;
    [SerializeField] ParticleSystem rightBooster;
    [SerializeField] ParticleSystem leftBooster;
    
    AudioSource audioSource;
    Rigidbody playerRb;


    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
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
            PlayAudio();
            PlayParticleFX();
        }
        else
        {
            audioSource.Stop();
            mainBooster.Stop();
        }
    }

    void GetPlayerRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            playerRb.freezeRotation = true; //freezing rotation to manually rotate.
            transform.Rotate(rotationThrust * Time.deltaTime * Vector3.forward);
            playerRb.freezeRotation = false; //unfreeze so unity physics takes over.
            PlayLeftBooster();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            playerRb.freezeRotation = true;
            transform.Rotate(rotationThrust * Time.deltaTime * Vector3.back);
            playerRb.freezeRotation = false;
            PlayRightBooster();
        }
        else
        {
            leftBooster.Stop(); 
            rightBooster.Stop();
        }
    }

    void PlayAudio()
    {
        if(!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(rocketEngine);
        }
    }

    void PlayParticleFX()
    {
        if(!mainBooster.isPlaying)
        {
            mainBooster.Play();
        }
    }

    void PlayLeftBooster()
    {
        if (!leftBooster.isPlaying)
        {
            leftBooster.Play();
        }
    }

    void PlayRightBooster()
    {
        if (!rightBooster.isPlaying)
        {
            rightBooster.Play();
        }
    }
}
