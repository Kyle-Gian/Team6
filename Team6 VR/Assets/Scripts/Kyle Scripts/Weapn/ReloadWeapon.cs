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
    [HideInInspector]public UnityEvent ObjectShot;

    public List<GameObject> _loadedObjects = new List<GameObject>();
    public int _gunCapacity = 2;

    private ProjectileShrink shrinkScript;

    private void OnEnable()
    {

            ObjectLoaded = new UnityEvent();
            
            ObjectShot = new UnityEvent();
        
        _loadedObjects.Capacity = _gunCapacity;

        shrinkScript = GetComponentInChildren<ProjectileShrink>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("LoadableObject") && _loadedObjects.Count < _gunCapacity)
        {
            //Alex's Addition
            //shrinkScript.loadedItems.Add(other.transform.parent.gameObject);
            //shrinkScript.shrink = true;
            _loadedObjects.Add(other.gameObject);
            //Invoke("HideLoadedItem", 0.5f);

            //ObjectLoaded.Invoke();
            //_loadedObjects.Add(other.gameObject);
            other.gameObject.SetActive(false);
            ObjectLoaded.Invoke();

        }
    }

    //Also Alex's Stuff
    void HideLoadedItem()
    {
        shrinkScript.loadedItems[0].gameObject.SetActive(false);
        shrinkScript.loadedItems.RemoveAt(0);
        shrinkScript.shrink = false;

    }

    public void RemoveObjectFromLoadedList(GameObject obj)
    {
        ObjectShot.Invoke();

        _loadedObjects.Remove(obj);
    }
}
