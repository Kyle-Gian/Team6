using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]
public class DartProjectile : MonoBehaviour
{

    public AudioClip impact;
    AudioSource audioSource;
    public GameObject particleEffect;
    public float velocity = 0.5f;
    Rigidbody rb;
    public UnityEvent ProjectileHit;
    ShootFromGun sfg;


    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
        sfg = FindObjectOfType<ShootFromGun>();

    }

    void OnCollisionEnter(Collision other)
    {
        if (rb.velocity.magnitude > velocity && sfg._weaponShot)
        {
            //audioSource.clip = impact;
            //audioSource.Play();
            //Instantiate(particleEffect, transform.position, Quaternion.identity);
            if(sfg._weaponShot)
            rb.isKinematic = true;
        }

    }
}
