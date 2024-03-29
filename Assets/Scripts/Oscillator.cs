using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    Vector3 startingPos;
    [SerializeField] Vector3 movementVector;
    [SerializeField] float movementFactor; //the range class allows to turn a variable into a slider between
                                                       // a min and max range in the inspector.
    [SerializeField] float period = 2f;

    void Start()
    {
        startingPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (period > Mathf.Epsilon) //protects against NaN error; Use Mathf.Epsilon to compare to a "float" number for more accuracy.
        {
            float cycles = Time.time / period; // continually grows over time.
            const float tau = Mathf.PI * 2; // equation to get 2pi.
        
            float rawSinWave = Mathf.Sin(cycles * tau); // going from -1 to 1

            movementFactor = (rawSinWave + 1f) / 2f; // adjusts values of sin wave to 0 to 1 for object movement.
            Vector3 offset = movementVector * movementFactor;
            transform.position = startingPos + offset;
        }
        
    }
}
