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
    public bool hitSomething = false;


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
        //audioSource.Play();
        //Instantiate(particleEffect, transform.position, Quaternion.identity);
        //if (sfg._weaponShot)
        //transform.SetParent(other.transform, true);
        //Destroy(gameObject);
        //  Debug.Log("dart hit can");
        // }
        if (!other.gameObject.CompareTag("Gun"))
        {
            hitSomething = true;
            Stick();
            if (other.gameObject.CompareTag("Can"))
            {
                transform.SetParent(other.transform);
                Debug.Log(other.gameObject.name);

            }
            //if (rb != null)
            //    rb.isKinematic = true;
            //Debug.Log(other.gameObject.name);
        }

    }

    private void Stick()
    {
        rb.constraints = RigidbodyConstraints.FreezeAll;
    }
}
