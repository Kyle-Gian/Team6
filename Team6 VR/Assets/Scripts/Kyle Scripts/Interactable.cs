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

    private void Start()
    {
        _startPosition = transform.position;
    }
}
