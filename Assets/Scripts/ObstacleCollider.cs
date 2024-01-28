using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObstacleCollider : MonoBehaviour
{
    [SerializeField] float delayTime = 2f;

    void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Friendly":
                //do not blow up
                break;

            case "Finish":
                NextLevelTransition();
                break;
                         
            default :
                StartCrashSequence();
                break;
        }
    }

    void NextLevelTransition()
    {
        GetComponent<PlayerMovement>().enabled = false;
        Invoke("LoadNextLevel", delayTime);
    }
    void StartCrashSequence()
    {
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
}
