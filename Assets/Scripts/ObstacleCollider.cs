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
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (isTransitioning)
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

    void NextLevelTransition()
    {
        isTransitioning = true;
        audioSource.Stop();
        levelComplete.Play();
        PlayShipLanding();
        GetComponent<PlayerMovement>().enabled = false;
        Invoke("LoadNextLevel", delayLevelLoad);
    }
    void StartCrashSequence()
    {
        isTransitioning = true;
        audioSource.Stop();
        shipCrash.Play();
        PlayCrashAudio();
        GetComponent<PlayerMovement>().enabled = false;
        Invoke("LoadLevel", delayTime);
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
