using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRespawnArea : MonoBehaviour
{
    private GunResetPosition _gunReset;

    private void Start()
    {
        _gunReset = FindObjectOfType<GunResetPosition>();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Gun"))
        {
            
        }
    }
}
