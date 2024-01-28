using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
                //blow up
                break;
        }
    }
}
