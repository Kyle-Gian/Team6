//Author Kyle Gian
//created: 29/5/2021
//Last Modified: 7/6/2021

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ReloadWeapon : MonoBehaviour
{
    public UnityEvent ObjectLoaded;
    public List<GameObject> _loadedObjects = new List<GameObject>();
    public int _gunCapacity = 2;

    private void Start()
    {
        _loadedObjects.Capacity = _gunCapacity;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("LoadableObject"))
        {
            ObjectLoaded.Invoke();
            _loadedObjects.Add(other.gameObject);
            other.gameObject.SetActive(false);
        }
    }

    public void RemoveObjectFromLoadedList(GameObject obj)
    {
        _loadedObjects.Remove(obj);
    }
}
