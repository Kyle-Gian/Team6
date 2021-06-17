using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

public class DartProjectile : MonoBehaviour
{

    public AudioClip impact;
    AudioSource audioSource;
    public GameObject particleEffect;
    public float velocity = 0.5f;
    Rigidbody rb;
    public UnityEvent ProjectileHit;
    ShootFromGun sfg;
    public bool hitSomething = false;
    public bool soundHasPlayed = false;


    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
        sfg = FindObjectOfType<ShootFromGun>();
        transform.rotation = Quaternion.LookRotation(rb.velocity);

    }

    private void Update()
    {
        if (!hitSomething)
            transform.rotation = Quaternion.LookRotation(rb.velocity);
    }

    void OnCollisionEnter(Collision other)
    {
        // if (!other.gameObject.CompareTag("Gun")) // Or could be "Barrel"
        //rb.isKinematic = true;
        //if (rb.velocity.magnitude > velocity /*&& sfg._weaponShot*/)
        //{
        //audioSource.clip = impact;
        if (!soundHasPlayed)
        {
            audioSource.PlayOneShot(impact);
            soundHasPlayed = true;

        }
        //Instantiate(particleEffect, transform.position, Quaternion.identity);
        //if (sfg._weaponShot)
        //transform.SetParent(other.transform, true);
        //Destroy(gameObject);
        // }
        if (!other.gameObject.CompareTag("Gun"))
        {
            hitSomething = true;
            Stick(other);
            if (other.gameObject.CompareTag("Can") || other.gameObject.CompareTag("PopUpTarget"))
            {
                transform.SetParent(other.transform);
                // Debug.Log(transform.rotation);

            }
            //if (rb != null)
            //    rb.isKinematic = true;
            //Debug.Log(other.gameObject.name);
        }

    }

    private void Stick(Collision other)
    {
        rb.constraints = RigidbodyConstraints.FreezeAll;
    }
}
