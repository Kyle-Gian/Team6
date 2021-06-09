using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Projectile : MonoBehaviour
{
    public string nameOfFirstHitObject;

    public delegate void HitDelegate();
    public event HitDelegate hitEvent;

    void OnCollisionExit(Collision other) // Change back to exit
    {
        if(hitEvent != null)
        {
            hitEvent();
        }

        nameOfFirstHitObject = other.gameObject.name;
        //nameOfFirstHitObject = other.contacts[0].otherCollider.name;
        //Debug.Log(other.gameObject.name);
    }
}
