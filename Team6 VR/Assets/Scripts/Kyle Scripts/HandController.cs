
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
        _controllerActionGrip.action.canceled += GripCancelled;


        _controllerActionTrigger.action.performed += GripTrigger;
        _controllerActionGrip.action.canceled += TriggerCancelled;


        _handAnimator = GetComponent<Animator>();
    }

    private void TriggerCancelled(InputAction.CallbackContext obj)
    {
        _handAnimator.SetFloat("Trigger",0);
    }

    private void GripCancelled(InputAction.CallbackContext obj)
    {
        _handAnimator.SetFloat("Grip", 0);

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
