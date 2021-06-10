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
    [HideInInspector]public UnityEvent ObjectLoaded;
    [HideInInspector] public UnityEvent ObjectShot;

    public List<GameObject> _loadedObjects = new List<GameObject>();
    public int _gunCapacity = 2;

    private void OnEnable()
    {
        if (ObjectLoaded == null)
        {
            ObjectLoaded = new UnityEvent();
        }
        if (ObjectShot == null)
        {
            ObjectShot = new UnityEvent();
        }
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
        ObjectShot.Invoke();

        _loadedObjects.Remove(obj);
    }
}
