using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemFaceTarget : MonoBehaviour
{
    public Transform target; // Assign the target character in the Inspector

    private ParticleSystem particleSystem;

    void Start()
    {
        // Get the Particle System component from this GameObject
        particleSystem = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        // Make sure we have a valid particle system and target
        if (particleSystem != null && target != null)
        {
            // Calculate the direction vector from the particle system to the target
            Vector3 directionToTarget = target.position - transform.position;

            // Calculate the rotation that looks at the target
            Quaternion lookRotation = Quaternion.LookRotation(directionToTarget);

            // Subtract 90 degrees from the y-axis
            lookRotation *= Quaternion.Euler(0, -90, 0);

            // Apply the rotation to the particle system
            transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * 10);
        }
    }
}