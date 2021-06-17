using UnityEngine;
using UnityEngine.Events;

public class GenericCollision : MonoBehaviour
{
    public UnityEvent onCollisionEvent;

    private void OnCollisionEnter(Collision collision)
    {
        onCollisionEvent.Invoke();
    }

    private void OnCollisionExit(Collision collision)
    {
        onCollisionEvent.Invoke();
    }
}
