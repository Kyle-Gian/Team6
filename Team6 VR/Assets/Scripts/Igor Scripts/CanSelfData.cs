using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanSelfData : MonoBehaviour
{
    public bool fallen = false;

    public AudioClip impact;
    AudioSource audioSource;
    Rigidbody rb;
    public float velocity = 0.5f;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if(rb.velocity.magnitude >= velocity)
        {
            audioSource.clip = impact;
            audioSource.Play();
        }

        if (other.gameObject.CompareTag("LoadableObject"))
        {
            audioSource.clip = impact;
            audioSource.Play();
        }
    }
}
