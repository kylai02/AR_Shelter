using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemLengthAdjuster : MonoBehaviour
{
    public GameObject targetObject; // The target character object
    public float defaultLength = 13f; // The default length of the particle system

    private ParticleSystem particleSystem;
    private ParticleSystem.ShapeModule shapeModule;
    private float initialDistance;
    private float currentDistance;

    void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
        shapeModule = particleSystem.shape;
        shapeModule.length = defaultLength; // Set the initial length
        initialDistance = Vector3.Distance(transform.position, targetObject.transform.position);
    }

    void Update()
    {
        if (targetObject != null)
        {
            // Calculate the current distance between the particle system and the target object
            currentDistance = Vector3.Distance(transform.position, targetObject.transform.position);

            // Adjust the length of the particle system's shape module based on the distance change
            float distanceDelta = currentDistance - initialDistance;
            shapeModule.length = Mathf.Max(0, defaultLength + distanceDelta); // Ensure the length never goes below 0
        }
    }
}