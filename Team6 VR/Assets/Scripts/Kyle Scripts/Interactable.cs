//Author Kyle Gian
//created: 3/6/2021
//Last Modified: 3/6/2021

using System;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [HideInInspector] public Vector3 _startPosition;
    public ParticleSystem _collisionParticle;
    public ParticleSystem _trailParticle;
    [HideInInspector] public bool _thrown;

    private void Start()
    {
        _startPosition = transform.position;
    }

    //Added to grab interactable on the gameobject, if object picked up set thrown to true.
    //When loaded in gun, set false. Used for challenges
    public void ObjectThrown(bool thrown)
    {
        _thrown = thrown;
    }
}
