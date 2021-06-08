//Author Kyle Gian
//created: 3/6/2021
//Last Modified: 3/6/2021

using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ResetPosition : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private Vector3 _startPos;
    [SerializeField] private float _waitTime = 5;
    private bool _inAction;

    private Quaternion _startRotation;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _startPos = transform.position;
        _startRotation = Quaternion.identity;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, _startPos) > 1)
        {
            if (!_inAction)
            {
                StartCoroutine("RespawnTime");
            }

        }
    }

    public void ResetObjectPos()
    {
        gameObject.SetActive(false);
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.rotation = _startRotation;
        //transform.rotation = _startRotation;
        _rigidbody.angularVelocity = Vector3.zero;
        transform.position = _startPos;
        gameObject.SetActive(true);
    }

    IEnumerator RespawnTime()
    {
        yield return new WaitForSeconds(_waitTime);
        ResetObjectPos();
    }

    public void ObjectInAction(bool inAction)
    {
        _inAction = inAction;
    }
    
    
}
