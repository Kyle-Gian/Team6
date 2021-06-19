//Author Igor Doslov
//created: 10/6/2021
//Last Modified: 17/6/2021

using UnityEngine;
using UnityEngine.Events;

// Generic protectile
public class Projectile : MonoBehaviour
{

    public AudioClip impact;
    AudioSource audioSource;
    public GameObject particleEffect;
    public float velocity = 0.5f;
    Rigidbody rb;
    public UnityEvent ProjectileHit;
    public bool soundHasPlayed = false;



    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();

    }

    void OnCollisionEnter(Collision other)
    {
        if (!soundHasPlayed) // Prevents sound playing more than once
        {
            if (audioSource != null)
            {
                audioSource.PlayOneShot(impact);
                soundHasPlayed = true;
            }

        }

        if (rb != null)
            if (rb.velocity.magnitude > velocity /*&& !audioSource.isPlaying*/)
            {
                //audioSource.PlayOneShot(impact);
                Instantiate(particleEffect, transform.position, Quaternion.identity);
            }

    }

    private void OnCollisionExit(Collision other)
    {
        soundHasPlayed = false;
    }
}
