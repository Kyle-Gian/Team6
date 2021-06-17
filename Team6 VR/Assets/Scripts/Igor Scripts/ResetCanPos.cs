//Author Igor Doslov
//created: 10/6/2021
//Last Modified: 17/6/2021

using System.Collections;
using UnityEngine;

// Get can's start position values so the can's position be reset
public class ResetCanPos : MonoBehaviour
{
    Rigidbody rb;
    Vector3 startPos;
    Quaternion startRotation;
    CanSelfData can;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPos = transform.position;
        startRotation = transform.rotation;
        can = GetComponent<CanSelfData>();
        
    }

    public void ResetObjectPos()
    {
        StartCoroutine(WaitToResetCans());
    }

    // Reset can transform values to start position after 3 seconds
    public IEnumerator WaitToResetCans()
    {
        yield return new WaitForSeconds(3f);
        rb.velocity = Vector3.zero;
        transform.rotation = startRotation;
        transform.position = startPos;
        rb.angularVelocity = Vector3.zero;
        can.fallen = false;
    }
}
