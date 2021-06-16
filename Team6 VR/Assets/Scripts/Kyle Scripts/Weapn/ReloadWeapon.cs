//Author Kyle Gian
//created: 29/5/2021
//Last Modified: 7/6/2021

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

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
            //_loadedObjects.Add(other.gameObject);
            //ObjectLoaded.Invoke();
            //_loadedObjects.Add(other.gameObject);
            //other.gameObject.SetActive(false);
            //ObjectLoaded.Invoke();

            //Alex's Addition
            shrinkScript.loadedItems.Add(other.gameObject);
            other.gameObject.GetComponent<Collider>().enabled = false;
            shrinkScript.shrink = true;
            Invoke("HideLoadedItem", 0.5f);
        }
    }

    //Also Alex's Stuff
    void HideLoadedItem()
    {
        shrinkScript.shrink = false;

        _loadedObjects.Add(shrinkScript.loadedItems[0]);
        ObjectLoaded.Invoke();

        shrinkScript.loadedItems[0].gameObject.SetActive(false);
        shrinkScript.loadedItems.RemoveAt(0);


    }

    public void RemoveObjectFromLoadedList(GameObject obj)
    {
        ObjectShot.Invoke();

        _loadedObjects.Remove(obj);
    }
}
