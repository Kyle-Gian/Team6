//Author Igor Doslov
//created: 17/6/2021
//Last Modified: 17/6/2021

using UnityEngine;
using UnityEngine.Events;

// Generic collision script to invoke an event on collision
public class GenericCollision : MonoBehaviour
{
    public UnityEvent onCollisionEvent;

    private void OnCollisionEnter(Collision collision)
    {
        onCollisionEvent.Invoke();
    }

}
