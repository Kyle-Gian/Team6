//Author Kyle Gian
//created: 2/6/2021
//Last Modified: 2/6/2021

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
public class GunButtonPress : MonoBehaviour
{
    private GameObject _button;
    private Vector3 _buttonStartPos;
    private static bool _buttonPressed = false;
    private bool m_B;

    public GunButtonPress()
    {
        m_B = _button != null;
    }

    void Start()
    {
        _button = GameObject.FindWithTag("Gun Button");
        if (m_B)
        {
            _buttonStartPos = _button.transform.position;

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (m_B)
        {
            if (_button.transform.position.y < _buttonStartPos.y - 0.5f)
            {
                _buttonPressed = true;
            }
            else
            {
                _buttonPressed = false;
            }
        }
 
    }
    public static bool ButtonPressed()
    {
        return _buttonPressed;
    }

    public void TriggerIn(bool triggerPressed)
    {
        _buttonPressed = triggerPressed;

    }
}
