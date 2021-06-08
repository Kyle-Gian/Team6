//Author Kyle Gian
//created: 6/6/2021
//Last Modified: 6/6/2021

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleRotatePastPoint : MonoBehaviour
{
    private bool _hasBeenKnocked = false;

    [SerializeField]private float _rotationPoint;

    public Vector3 _bottleRotate;

    void Start()
    {
        _bottleRotate = transform.rotation.eulerAngles;
    }

    public bool HasRotated()
    {
        _bottleRotate = transform.rotation.eulerAngles;
        
        if (_bottleRotate.x > _rotationPoint || _bottleRotate.y > _rotationPoint || _bottleRotate.z > _rotationPoint)
        {
            _hasBeenKnocked = true;
        }
        return _hasBeenKnocked;
    }

    public void ResetBottle()
    {
        _hasBeenKnocked = false;
    }
}
