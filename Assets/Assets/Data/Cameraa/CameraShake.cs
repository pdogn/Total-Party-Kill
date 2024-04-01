using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public Transform cameraTransform;
    public float shakeDuration = 0.1f;
    public float shakeIntensity = 0.5f;

    private Vector3 originalPos;
    private float shakeTimeRemaining = 0f;

    void Start()
    {
        if (cameraTransform == null)
        {
            cameraTransform = Camera.main.transform;
        }

        originalPos = cameraTransform.localPosition;
    }

    void Update()
    {
        if (shakeTimeRemaining > 0)
        {
            cameraTransform.localPosition = originalPos + Random.insideUnitSphere * shakeIntensity;

            shakeTimeRemaining -= Time.deltaTime * 1.0f;
        }
        else
        {
            shakeTimeRemaining = 0f;
            cameraTransform.localPosition = originalPos;
        }
    }

    public void ShakeCamera()
    {
        shakeTimeRemaining = shakeDuration;
    }
}
