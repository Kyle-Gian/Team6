//Author Igor Doslov
//created: 10/6/2021
//Last Modified: 17/6/2021

using UnityEngine;

// Each can has this script so that it holds position info about itself that can be checked by CanRotation script
public class CanSelfData : MonoBehaviour
{
    public bool fallen = false;

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
