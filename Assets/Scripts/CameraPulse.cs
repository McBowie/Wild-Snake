using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPulse : MonoBehaviour
{
    [SerializeField] float maxRotation;
    [SerializeField] float rotationSpeed;
    [SerializeField] float pulseSpeed;
    [SerializeField] float maxPulse;


    // Transform of the camera to shake. Grabs the gameObject's transform
    // if null.
    [SerializeField] Transform camTransform;

    // How long the object should shake for.
    public float shakeDuration = 0f;

    // Amplitude of the shake. A larger value shakes the camera harder.
    public float shakeAmount = 0.7f;
    [SerializeField] float decreaseFactor = 1.0f;




    void Update()
    {



        if (shakeDuration > 0)
        {
            camTransform.localPosition = Random.insideUnitSphere * shakeAmount + new Vector3(0f, 0f, -40 + maxPulse * Mathf.Sin(Time.time * pulseSpeed));

            shakeDuration -= Time.deltaTime * decreaseFactor;
        }
        else
        {
            shakeDuration = 0f;
            transform.rotation = Quaternion.Euler(0f, maxRotation * Mathf.Sin(Time.time * rotationSpeed), Mathf.Cos(Time.time * rotationSpeed));
            transform.position = new Vector3(0f, 0f, -40 + maxPulse * Mathf.Sin(Time.time * pulseSpeed));
        }
    }
}

