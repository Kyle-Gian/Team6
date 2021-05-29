//Author Kyle Gian
//created: 28/5/2021
//Last Modified: 28/5/2021

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class TestActionController : MonoBehaviour
{
    private ActionBasedController _controller;
    // Start is called before the first frame update
    void Start()
    {
        bool isPressed = _controller.selectAction.action.ReadValue<bool>();
        _controller.selectAction.action.performed += Action_performed;
    }

    private void Action_performed(InputAction.CallbackContext obj)
    {
        Debug.Log("Select Button is Pressed");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
