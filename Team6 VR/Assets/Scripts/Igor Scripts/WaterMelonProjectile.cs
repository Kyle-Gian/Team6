//Author Igor Doslov
//created: 16/6/2021
//Last Modified: 17/6/2021

using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class WaterMelonProjectile : MonoBehaviour
{


    public GameObject particleEffect;
    public GameObject brokenMelon;
    public float velocity = 0.5f;
    Rigidbody rb;
    public UnityEvent ProjectileHit;
    public float spinMin = 0f;
    public float spinMax = 500f;
    public bool firstHit = false;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        //transform.rotation = Quaternion.LookRotation(rb.velocity);
    }

    private void FixedUpdate()
    {
        //rb.AddTorque(transform.right * Random.Range(spinMin, spinMax), ForceMode.Impulse);
    }

    void OnCollisionEnter(Collision other)
    {
        if (gameObject != null)
        {
            if (CheckCollisionTag(other.transform.tag))
            {
                rb.AddExplosionForce(10f, transform.position, 10f);
                Instantiate(particleEffect, transform.position, Quaternion.identity);
                Instantiate(brokenMelon, transform.position, transform.rotation);
                //Destroy(gameObject, 0.1f);
                gameObject.GetComponent<MeshRenderer>().enabled = false;
                gameObject.GetComponent<MeshCollider>().enabled = false;

                StartCoroutine(RespawnTime());
            }
            firstHit = true;
        }

    }
    private bool CheckCollisionTag(string tag)
    {
        if (tag == "Wall" || tag == "Main target" || tag == "PopUpCollider" || tag == "Can Collider")
        {
            return true;
        }

        return false;
    }
    IEnumerator RespawnTime()
    {
        yield return new WaitForSeconds(1.0f);
        gameObject.GetComponent<MeshRenderer>().enabled = true;
        gameObject.GetComponent<MeshCollider>().enabled = true;

    }
}
