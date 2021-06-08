//Author Kyle Gian
//created: 2/6/2021
//Last Modified: 2/6/2021

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedGunPosition : MonoBehaviour
{
    private Vector3 _defaultPos;
    // Start is called before the first frame update
    void Start()
    {
        _defaultPos = transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = _defaultPos;
    }
}
