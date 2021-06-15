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
    
    public GameObject _leftHand;
    public GameObject _rightHand;
    XRDirectInteractor _leftHandInteractor;
    XRDirectInteractor _rightHandInteractor;

    private ProjectileShrink shrinkScript;

    private void OnEnable()
    {
        _leftHand = GameObject.FindGameObjectWithTag("left");
        _rightHand = GameObject.FindGameObjectWithTag("right");

        //If either the left or right hand are null throw an error for the user
        if (_leftHand != null)
        {
            //Get the left hand interactor and access the event
            _leftHandInteractor = _leftHand.GetComponent<XRDirectInteractor>();
        }
        else
        {
            Debug.LogError("Left hand has not been attached, Check Tag on left hand controller");

        }
        if (_rightHand != null)
        {
            //Get the right hand interactor and access the event
            _rightHandInteractor = _rightHand.GetComponent<XRDirectInteractor>();
        }
        else
        {
            Debug.LogError("Right hand has not been attached, Check Tag on Right hand controller");

        }

        ObjectLoaded = new UnityEvent();
        ObjectShot = new UnityEvent();
        
        _loadedObjects.Capacity = _gunCapacity;

        shrinkScript = GetComponentInChildren<ProjectileShrink>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("LoadableObject") && _loadedObjects.Count < _gunCapacity)
        {
            //Checks if obj is attached to hand, if so removes from hand before adding to list 
            if (other.transform == _leftHandInteractor.attachTransform)
            {
                _leftHandInteractor.attachTransform.DetachChildren();
            }

            if (other.transform == _rightHandInteractor.attachTransform)
            {
                _rightHandInteractor.attachTransform.DetachChildren();
            }
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
