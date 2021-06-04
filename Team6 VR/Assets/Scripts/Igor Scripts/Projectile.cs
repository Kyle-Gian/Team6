using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public string nameOfFirstHitObject;

    void OnCollisionExit(Collision other)
    {
        nameOfFirstHitObject = other.gameObject.name;
    }
}
