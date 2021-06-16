using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]
public class WaterMelonProjectile : MonoBehaviour
{

    public AudioClip impact;
    AudioSource audioSource;
    public GameObject particleEffect;
    public float velocity = 0.5f;
    Rigidbody rb;
    public UnityEvent ProjectileHit;


    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();

    }

    void OnCollisionEnter(Collision other)
    {
        if (rb.velocity.magnitude > velocity)
        {
            audioSource.clip = impact;
            audioSource.Play();
            Destroy(gameObject, 0.01f);
            Instantiate(particleEffect, transform.position, Quaternion.identity);
        }

    }
}
