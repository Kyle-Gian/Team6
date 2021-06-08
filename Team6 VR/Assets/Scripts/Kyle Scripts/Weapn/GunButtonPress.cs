//Author Kyle Gian
//created: 2/6/2021
//Last Modified: 2/6/2021

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR;
public class GunButtonPress : MonoBehaviour
{
    private Vector3 _buttonStartPos;
    private static bool _buttonPressed = false;
    private bool m_B;
    public static bool ButtonPressed()
    {
        return _buttonPressed;
    }

    public void TriggerIn(bool triggerPressed)
    {
        _buttonPressed = triggerPressed;

    }
}
