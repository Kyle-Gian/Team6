//Author Kyle Gian
//created: 3/6/2021
//Last Modified: 3/6/2021

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Interactable")]
public class Interactable : ScriptableObject
{
    public GameObject _item;
    public Vector3 _startPosition;
    public bool _itemActive;
    public ParticleSystem _collisionParticle;
    public ParticleSystem _trailParticle;
}
