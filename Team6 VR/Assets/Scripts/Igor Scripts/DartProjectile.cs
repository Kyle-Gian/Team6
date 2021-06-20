//Author Igor Doslov
//created: 16/6/2021
//Last Modified: 17/6/2021

using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class DartProjectile : XRGrabInteractable
{

    public AudioClip impact;
    AudioSource audioSource;
    public GameObject particleEffect;
    public float velocity = 0.5f;
    Rigidbody rb;
    public UnityEvent ProjectileHit;
    public bool hitSomething = false;
    public bool soundHasPlayed = false;
    public bool hasBeenThrown = false;

    ShootFromGun sfg;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
        //transform.rotation = Quaternion.LookRotation(rb.velocity);

        sfg = FindObjectOfType<ShootFromGun>();
    }

    private void FixedUpdate()
    {

        if (!hitSomething || isSelected)
        { 
            //rb.constraints = RigidbodyConstraints.None;
            //transform.rotation = Quaternion.LookRotation(rb.velocity); // Makes the dart rotate according to its velocity

        }

        if (sfg._weaponShot)
        {
            rb.constraints = RigidbodyConstraints.None;
            transform.rotation = Quaternion.LookRotation(rb.velocity); // Makes the dart rotate according to its velocity
        }

    }

    void OnCollisionEnter(Collision other)
    {
        if (sfg._weaponShot || hasBeenThrown)
        {
            if (!soundHasPlayed) // Prevents sound playing more than once when dart is stuck to object
            {
                audioSource.PlayOneShot(impact);
                soundHasPlayed = true;

            }

            if (CheckCollisionTag(other.transform.tag))
            {
                hitSomething = true;
                Stick(other);
                // If a can or popUpTarget then parent so the dart moves with the object
                if (other.gameObject.CompareTag("Can") || other.gameObject.CompareTag("PopUpTarget"))
                {
                    transform.SetParent(other.transform);

                }

            }
            hasBeenThrown = false;
        }

    }

    // Freezes x, y, z position and rotation values
    private void Stick(Collision other)
    {
        rb.constraints = RigidbodyConstraints.FreezeAll;
    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        base.OnSelectExited(args);
        hasBeenThrown = true;
    }

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);
        transform.SetParent(null,true);
      
    }

    private bool CheckCollisionTag(string tag)
    {
        if (tag == "Wall" || tag == "Main target" || tag == "PopUpCollider" || tag == "Can Collider")
        {
            return true;
        }

        return false;
    }

}
