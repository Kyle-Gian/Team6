//Author Kyle Gian
//created: 29/5/2021
//Last Modified: 29/5/2021

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverBehaviour : MonoBehaviour
{
    private GameObject _lever;

    private HingeJoint _hinge;
    // Start is called before the first frame update
    void Start()
    {
        _lever = GameObject.FindGameObjectWithTag("Lever");
        _hinge = _lever.GetComponent<HingeJoint>();
    }

    public float LeverPosition()
    {
        Debug.Log(_hinge.axis.x);

        return _hinge.axis.x;
    }
}
