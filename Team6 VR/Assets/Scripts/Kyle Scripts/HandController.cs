
using System;
using UnityEngine;
using UnityEngine.InputSystem;
public class HandController : MonoBehaviour
{
    [SerializeField] private InputActionReference _controllerActionGrip;
    [SerializeField] private InputActionReference _controllerActionTrigger;
    private Animator _handAnimator;
    private void Awake()
    {
        _controllerActionGrip.action.performed += GripPress;
        _controllerActionTrigger.action.performed += GripTrigger;

        _handAnimator = GetComponent<Animator>();
    }

    private void GripTrigger(InputAction.CallbackContext obj)
    {
        _handAnimator.SetFloat("Trigger", obj.ReadValue<float>());
    }

    private void GripPress(InputAction.CallbackContext obj)
    {
        _handAnimator.SetFloat("Grip", obj.ReadValue<float>());
    }
}
