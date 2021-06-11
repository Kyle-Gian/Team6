//Author Kyle Gian
//created: 2/6/2021
//Last Modified: 2/6/2021

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTargetPosition : MonoBehaviour
{
    private Vector3 _startPosition;
    [SerializeField] private Vector3 _endPosition;
    [SerializeField] private float _moveSpeed = 0.2f;
    
    // Start is called before the first frame update
    void Start()
    {
        _startPosition = transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        if (transform.position != _endPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position,_endPosition, 0 + _moveSpeed * Time.deltaTime);
        }
        else
        {
            _endPosition = _startPosition;
            _startPosition = transform.position;
        }


    }
}
