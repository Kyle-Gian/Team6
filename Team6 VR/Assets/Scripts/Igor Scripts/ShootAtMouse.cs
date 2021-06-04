using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class ShootAtMouse : MonoBehaviour
{
    // Assign a Rigidbody component in the inspector to instantiate

    public Rigidbody projectile;
    public Transform gunEnd;


    private void Awake()
    {
        GetComponent<PlayerInput>().onActionTriggered += HandleAction;
    }

    private void HandleAction(InputAction.CallbackContext context)
    {
        // Ctrl was pressed, launch a projectile
        if (context.action.name == "Shoot")
        {
            Instantiate(projectile, gunEnd.position, gunEnd.rotation);
        }
        // Instantiate the projectile at the position and rotation of this transform
        // Rigidbody clone;
        

            // Give the cloned object an initial velocity along the current
            // object's Z axis
           // clone.velocity = transform.TransformDirection(Vector3.forward * 10);
        
    }
}
