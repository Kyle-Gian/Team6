//Author Igor Doslov
//created: 16/6/2021
//Last Modified: 17/6/2021

using UnityEngine;
using UnityEngine.Events;

public class DartProjectile : MonoBehaviour
{

    public AudioClip impact;
    AudioSource audioSource;
    public GameObject particleEffect;
    public float velocity = 0.5f;
    Rigidbody rb;
    public UnityEvent ProjectileHit;
    public bool hitSomething = false;
    public bool soundHasPlayed = false;


    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
        transform.rotation = Quaternion.LookRotation(rb.velocity);

    }

    private void FixedUpdate()
    {
        if (!hitSomething)
            transform.rotation = Quaternion.LookRotation(rb.velocity); // Makes the dart rotate according to its velocity
    }

    void OnCollisionEnter(Collision other)
    {

        if (!soundHasPlayed) // Prevents sound playing more than once when dart is stuck to object
        {
            audioSource.PlayOneShot(impact);
            soundHasPlayed = true;

        }

        if (!other.gameObject.CompareTag("Gun"))
        {
            hitSomething = true;
            Stick(other);
            // If a can or popUpTarget then parent so the dart moves with the object
            if (other.gameObject.CompareTag("Can") || other.gameObject.CompareTag("PopUpTarget"))
            {
                transform.SetParent(other.transform);

            }

        }

    }
    
    // Freezes x, y, z position and rotation values
    private void Stick(Collision other)
    {
        rb.constraints = RigidbodyConstraints.FreezeAll;
    }
}
