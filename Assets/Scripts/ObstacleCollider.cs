using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObstacleCollider : MonoBehaviour
{
    [SerializeField] float delayTime = 2f;
    [SerializeField] float delayLevelLoad = 6f;

    [SerializeField] AudioClip shipExplosion;
    [SerializeField] AudioClip shipLanding;
    [SerializeField] ParticleSystem levelComplete;
    [SerializeField] ParticleSystem shipCrash;    

    AudioSource audioSource;

    bool isTransitioning;
    bool isCollisionDisabled;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        DebugKeys();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (isTransitioning || isCollisionDisabled)
        { 
            return;        // prevents from reaching switch statement if isTransitioning is true.
        }
        
        switch (collision.gameObject.tag)
        {
            case "Friendly":
                //do not blow up
                break;

            case "Finish":   
                NextLevelTransition();
                break;

            default:
                StartCrashSequence();
                break;
        }
    }

    void DebugKeys()
    { 
        if (Input.GetKey(KeyCode.L))
        {
            LoadNextLevel();
        }
        else if (Input.GetKey(KeyCode.C))
        {
            isCollisionDisabled = !isCollisionDisabled; //Everytime C is pressed, variable is set to opposite value of what it is.
        }
    }
    void NextLevelTransition()
    {
        isTransitioning = true;
        audioSource.Stop();
        levelComplete.Play();
        PlayShipLanding();
        GetComponent<PlayerMovement>().enabled = false;
        Invoke("LoadNextLevel", delayLevelLoad); //invokes delay between levels
    }
    void StartCrashSequence()
    {
        isTransitioning = true;
        audioSource.Stop();
        shipCrash.Play();
        PlayCrashAudio();
        GetComponent<PlayerMovement>().enabled = false;
        Invoke("LoadLevel", delayTime); // invokes delay after crash
    }
    void LoadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        
        SceneManager.LoadScene(currentSceneIndex);
    }

    void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }

    void PlayCrashAudio()
    {
        if(!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(shipExplosion);
        }
    }

    void PlayShipLanding()
    {
        if(!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(shipLanding);
        }
    }
}
