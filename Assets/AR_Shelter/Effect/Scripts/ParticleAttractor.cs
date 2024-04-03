using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleAttractor : MonoBehaviour
{
    public ParticleSystem particleSystem;
    public Transform target;
    public float attractionForce = 10f;

    private ParticleSystem.Particle[] particles;
    private int particleCount;

    void LateUpdate()
    {
        InitializeIfNeeded();

        // Get particles
        particleCount = particleSystem.GetParticles(particles);

        // Adjust each particle's velocity
        float step = attractionForce * Time.deltaTime;
        for (int i = 0; i < particleCount; i++)
        {
            Vector3 directionToTarget = (target.position - particles[i].position).normalized;
            Vector3 newVelocity = Vector3.Lerp(particles[i].velocity, directionToTarget * attractionForce, step);
            particles[i].velocity = newVelocity;
        }

        // Apply the particle changes
        particleSystem.SetParticles(particles, particleCount);
    }

    void InitializeIfNeeded()
    {
        if (particles == null || particles.Length < particleSystem.main.maxParticles)
        {
            particles = new ParticleSystem.Particle[particleSystem.main.maxParticles];
        }
    }
}