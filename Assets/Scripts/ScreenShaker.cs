using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShaker : MonoBehaviour
{
    [SerializeField] float shakeMagnitude = 0.7f;

    private float shakeDuration = 0f;
    private float dampingSpeed = 1f;

    Vector3 initialPosition;

    void OnEnable()
    {
        initialPosition = transform.localPosition;
    }

    void Update()
    {
        if (shakeDuration > 0)
        {
            transform.localPosition = initialPosition + Random.insideUnitSphere * shakeMagnitude;

            shakeDuration -= Time.deltaTime * dampingSpeed;
        }
        else
        {
            shakeDuration = 0f;
            transform.localPosition = initialPosition;
        }
    }

    public void TriggerShake(float newShakeDuration)
    {
        shakeDuration = newShakeDuration;
    }
}

// FindObjectOfType<ScreenShaker>().TriggerShake(0.5f);