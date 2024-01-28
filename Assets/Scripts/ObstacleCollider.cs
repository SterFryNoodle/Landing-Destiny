using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObstacleCollider : MonoBehaviour
{
    

    void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Friendly":
                //do not blow up
                break;

            case "Finish":
                //do not blow up
                break;

            case "Fuel":
                //do not blow up
                break;

            default :
                LoadLevel();
                break;
        }
    }

    void LoadLevel()
    {
        SceneManager.LoadScene(0); //used integer arguement instead of string to increment array value for multiple lvls.
    }
}
