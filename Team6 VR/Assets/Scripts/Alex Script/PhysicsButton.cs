using System;
using System.Collections;
using System.Collections.Generic;
//using System.Windows.Markup;
using UnityEngine;
using UnityEngine.Events;

public class PhysicsButton : MonoBehaviour
{
    public float _threshhold = 0.1f;
    public float _deadZone = 0.025f;

    private bool _isPressed;
    private Vector3 _startPos;
    private ConfigurableJoint _joint;

    public UnityEvent _onPressed;

    void Start()
    {
        _startPos = transform.localPosition;
        _joint = GetComponent<ConfigurableJoint>();
    }


    void Update()
    {
        if (!_isPressed && GetValue() + _threshhold >= 1)
        {
            Pressed();
        }

        if (_isPressed && GetValue() - _threshhold <= 0)
        {
            Released();
        }
    }

    private float GetValue()
    {
        var value = Vector3.Distance(_startPos, transform.localPosition) / _joint.linearLimit.limit;

        if (Math.Abs(value) < _deadZone)
        {
            value = 0f;
        }

        return Mathf.Clamp(value, -1, 1);
    }

    void Pressed()
    {
        _isPressed = true;
        _onPressed.Invoke();
    }

    void Released()
    {
        _isPressed = false;
    }
}
