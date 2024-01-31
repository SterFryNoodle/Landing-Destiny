using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    Vector3 startingPos;
    [SerializeField] Vector3 movementVector;
    [SerializeField][Range(0,1)] float movementFactor; //the range class allows to turn a variable into a slider between
                                                       // a min and max range in the inspector.
    [SerializeField] float period = 2f;

    void Start()
    {
        startingPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float cycles = Time.time / period; 
        const float tau = Mathf.PI * 2; // equation to get 2pi.
        
        float rawSinWave = Mathf.Sin(cycles * tau);

        movementFactor = (rawSinWave + 1f) / 2f;
        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPos + offset;
    }
}
