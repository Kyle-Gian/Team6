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

    public List<GameObject> _loadedObjects;
    public int _gunCapacity = 2;

    private ProjectileShrink shrinkScript;

    private void OnEnable()
    {
        _loadedObjects = new List<GameObject>();
        ObjectLoaded = new UnityEvent();
        ObjectShot = new UnityEvent();
        
        _loadedObjects.Capacity = _gunCapacity;

        shrinkScript = GetComponentInChildren<ProjectileShrink>();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("LoadableObject") && _loadedObjects.Count < _gunCapacity)
        {
            XRGrabInteractable _grabInteractable = null;
            _grabInteractable = other?.GetComponent<XRGrabInteractable>();

            if (!_grabInteractable.isSelected)
            {
                //Alex's Addition
                shrinkScript.loadedItems.Add(other.gameObject);
                other.gameObject.GetComponent<Collider>().enabled = false;
                shrinkScript.shrink = true;
                Invoke("HideLoadedItem", 0.5f);
            }

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

        if (_loadedObjects.Contains(obj))
        {
            _loadedObjects.Remove(obj);
        }
    }
}
