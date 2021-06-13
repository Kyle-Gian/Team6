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
    private static bool _buttonPressed = false;
    public static bool ButtonPressed()
    {
        return _buttonPressed;
    }

    public void TriggerIn()
    {
        _buttonPressed = true;

    }
    public void TriggerOut()
    {
        _buttonPressed = false;

    }
}
