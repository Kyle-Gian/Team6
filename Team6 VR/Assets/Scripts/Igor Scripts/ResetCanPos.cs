using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
