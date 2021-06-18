//Author Alex Smits
//created: 12/6/2021
//Last Modified: 17/6/2021

using System;
using UnityEngine;
using UnityEngine.Events;

// Invokes a unity event when the button is pressed to enable functions to be called upon button press
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
