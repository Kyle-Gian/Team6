//Author Kyle Gian
//created: 29/5/2021
//Last Modified: 29/5/2021

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadWeapon : MonoBehaviour
{
    public List<GameObject> _loadedObjects = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("LoadableObject"))
        {
            _loadedObjects.Add(other.gameObject);
            other.gameObject.SetActive(false);
        }
    }

    public void RemoveObjectFromLoadedList(GameObject obj)
    {
        _loadedObjects.Remove(obj);
    }
}
