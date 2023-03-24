using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Oscillator : MonoBehaviour
{
    Vector2 startPosition;
    [SerializeField]Vector2 movementVector;
    float movementFactor;
    [SerializeField] float period = 2f;

    private void Start()
    {
        startPosition = transform.position;
    }
    private void Update()
    {
        if(period <= Mathf.Epsilon)
        {
            return;
        }
        float cycles = Time.time / period;
        const float tau = Mathf.PI * 2;
        float sin = Mathf.Sin(cycles * tau);

        movementFactor = (sin + 1f) / 2;

        Vector2 offset = movementVector * movementFactor;
        transform.position = startPosition + offset;
    }
}
