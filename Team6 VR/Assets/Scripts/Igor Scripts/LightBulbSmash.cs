using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBulbSmash : MonoBehaviour
{
    public GameObject brokenBulb;


    public void SwapLightBulb()
    {
        Destroy(gameObject);
        Instantiate(brokenBulb, transform.position, Quaternion.identity);
    }
}
