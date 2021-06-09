using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HandTracking : MonoBehaviour
{
    public GameObject followObject;
    public float followSpeed;
    public float rotationSpeed;
    public float animationSpeed;

    private Transform followTarget;
    private Rigidbody body;

    private Animator animator;
    private float gripTarget;
    private float gripCurrent;

    public Vector3 positionOffset;
    public Vector3 rotationOffset;

    private bool gripping;
    [SerializeField] private InputActionReference triggerReference;


    void Start()
    {
        triggerReference.action.started += TriggerPressed;
        triggerReference.action.canceled += TriggerReleased;

        followTarget = followObject.transform;
        body = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

        body.position = followTarget.position;
        body.rotation = followTarget.rotation;
        body.maxAngularVelocity = 20;
    }

    internal void SetGrip(float v)
    {
        gripTarget = v;
    }

    void Update()
    {
        PhysicsMove();
        AnimateHand();
    }

    void PhysicsMove()
    {
        //Position
        var positionWithOffset = followTarget.position + positionOffset;
        var distance = Vector3.Distance(positionWithOffset, transform.position);
        body.velocity = (positionWithOffset - transform.position).normalized * (followSpeed * distance);

        //Rotation
        var roationWithOffset = followTarget.rotation * Quaternion.Euler(rotationOffset);
        var q = roationWithOffset * Quaternion.Inverse(body.rotation);
        q.ToAngleAxis(out float angle, out Vector3 axis);
        body.angularVelocity = axis * (angle * Mathf.Deg2Rad * rotationSpeed);
    }

    void AnimateHand()
    {
        if (gripCurrent != gripTarget)
        {
            gripCurrent = Mathf.MoveTowards(gripCurrent, gripTarget, Time.deltaTime * animationSpeed);
            animator.SetFloat("Grip", gripCurrent);
        }        
    }


    public void TriggerPressed(InputAction.CallbackContext context)
    {
        gripTarget = 1;
        gripping = true;
    }    
    
    public void TriggerReleased(InputAction.CallbackContext context)
    {
        gripTarget = 0;
        gripping = false;
    }

    public void StartHoverEvent()
    {
        if (!gripping)
        {
            gripTarget = -1;
        }
    }    
    
    public void EndHoverEvent()
    {
        if (!gripping)
        {
            gripTarget = 0;
        }

    }

    public void Release()
    {
        Physics.IgnoreLayerCollision(6, 7, true);
        Invoke("RestoreCollision", 1);
    }

    void RestoreCollision()
    {
        Physics.IgnoreLayerCollision(6, 7, false);
    }
}
