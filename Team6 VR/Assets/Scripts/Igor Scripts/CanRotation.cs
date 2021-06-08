using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanRotation : MonoBehaviour
{
    [SerializeField]
    float eulerAngleX;
    [SerializeField]
    float eulerAngleY;
    [SerializeField]
    float eulerAngleZ;


    void Update()
    {

        eulerAngleX = transform.localEulerAngles.x;
        eulerAngleY = transform.localEulerAngles.y;
        eulerAngleZ = transform.localEulerAngles.z;

        if (eulerAngleX > 45f && eulerAngleX < 315f || eulerAngleZ > 45f && eulerAngleZ < 315f)
        {
            Debug.Log("fall");
        }
    }

    //private void OnCollisionEnter(Collision other)
    //{
    //    if (other.gameObject.CompareTag("Ball"))
    //    {
    //        if(eulerAngleX > 45f || eulerAngleX < 315f)
    //        {

    //        }
    //    }
    //}
}
