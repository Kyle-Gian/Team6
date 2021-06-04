using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ResetPosition : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private Vector3 _startPos;
    public static bool _resetPos = false;
    [SerializeField] private float _waitTime = 10;

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
        if (transform.position != _startPos && !_resetPos)
        {
            //if (_rigidbody.velocity.magnitude < 0.5f)
            //{
            //    if (_resetPos)
            //    {
            //        ResetObjectPos();
            //        _resetPos = false;
            //    }
            //}
            _resetPos = true;
            StartCoroutine("RespawnTime");
        }
    }

    public void ResetObjectPos()
    {
        gameObject.SetActive(false);
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.rotation = _startRotation;
        transform.position = _startPos;
        gameObject.SetActive(true);
    }

    IEnumerator RespawnTime()
    {
        yield return new WaitForSeconds(_waitTime);
        ResetObjectPos();
        _resetPos = false;
    }
}
