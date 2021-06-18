using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShelfHit : MonoBehaviour
{
    public UnityEvent _shelfHasBeenHit;
    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("LoadableObject"))
        {
            _shelfHasBeenHit.Invoke();
        }
    }
}
