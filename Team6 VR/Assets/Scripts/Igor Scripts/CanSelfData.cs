using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanSelfData : MonoBehaviour
{
    public bool fallen = false;
    //public CanFallenAmount numCansFallen;

    public AudioClip impact;
    AudioSource audioSource;
    Rigidbody rb;
    public float velocity = 1f;
    public Vector3 startPos;
    

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
        startPos = transform.position;
    }

    private void OnCollisionEnter(Collision other)
    {
        if(rb.velocity.magnitude >= velocity)
        {
            audioSource.clip = impact;
            audioSource.Play();
        }

        if (other.gameObject.CompareTag("LoadableObject") && other.rigidbody.velocity.magnitude > velocity)
        {
            audioSource.clip = impact;
            audioSource.Play();
        }
    }
}
