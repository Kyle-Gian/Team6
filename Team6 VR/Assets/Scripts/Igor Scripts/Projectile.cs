using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public string nameOfFirstHitObject;

    void OnCollisionExit(Collision other)
    {
        nameOfFirstHitObject = other.gameObject.name;
        //nameOfFirstHitObject = other.contacts[0].otherCollider.name;
        Debug.Log(other.gameObject.name);
    }
}
