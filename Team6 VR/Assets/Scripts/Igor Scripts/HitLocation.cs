using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitLocation : MonoBehaviour
{
    public float Outer = 0f;
    public float Middle = 0f;
    public float Centre = 0f;

    void OnCollisionEnter(Collision other)
    {
        //print("Points colliding: " + other.contacts.Length);
        print("First point that collided: " + other.contacts[0].point);
        float dis = Vector3.Distance(other.contacts[0].point, transform.position);
        Debug.Log(dis);
        if(dis > Outer)
        {
            Debug.Log("hit outer");
        }
        else if (dis > Middle)
        {
            Debug.Log("hit middle");

        }
        else if(dis > Centre)
        {
            Debug.Log("bullseye");

        }
    }
}
