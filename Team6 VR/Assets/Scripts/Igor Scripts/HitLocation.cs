using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitLocation : MonoBehaviour
{
  // Print how many points are colliding this transform
    // And print the first point that is colliding.
    void OnCollisionEnter(Collision other)
    {
        //print("Points colliding: " + other.contacts.Length);
        print("First point that collided: " + other.contacts[0].point);
        float dis = Vector3.Distance(other.transform.position, other.contacts[0].point);
        Debug.Log(dis);
        if(dis > 1.2)
        {
            Debug.Log("Score: 1");
        }
        else if (dis > 0.75)
        {
            Debug.Log("Score: 2");

        }
        else if(dis > 0)
        {
            Debug.Log("Score: 3");

        }
    }
}
