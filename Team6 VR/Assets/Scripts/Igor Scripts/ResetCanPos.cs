using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetCanPos : MonoBehaviour
{
    Rigidbody rb;
    Vector3 startPos;
    Quaternion startRotation;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPos = transform.position;
        startRotation = transform.rotation;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetObjectPos()
    {
        rb.velocity = Vector3.zero;
        transform.rotation = startRotation;
        transform.position = startPos;
        rb.angularVelocity = Vector3.zero;
    }
}
