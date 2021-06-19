//Author Kyle Gian
//created: 3/6/2021
//Last Modified: 3/6/2021

using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

//Class used by objects that are thrown or shot at the targets
public class Interactable : MonoBehaviour
{
    [HideInInspector] public Vector3 _startPosition;
    [HideInInspector] public bool _thrown;

    ReloadWeapon reloadWeapon;
    public GameObject _leftHand;
    public GameObject _rightHand;
    XRDirectInteractor _leftHandInteractor;
    XRDirectInteractor _rightHandInteractor;
    

    private void Start()
    {
        _startPosition = transform.position;
        reloadWeapon = FindObjectOfType<ReloadWeapon>();
        reloadWeapon.ObjectLoaded.AddListener(delegate { ObjectShot(false); });
        _leftHand = GameObject.FindWithTag("left");
        _rightHand = GameObject.FindWithTag("right");
        
        //If either the left or right hand are null throw an error for the user
        if (_leftHand != null)
        {
            //Get the left hand interactor and access the event
            _leftHandInteractor = _leftHand.GetComponent<XRDirectInteractor>();
            _leftHandInteractor.selectEntered.AddListener(ObjectThrown);

        }
        else
        {
            Debug.LogWarning("Left hand has not been attached, Check Tag on left hand controller");

        }
        if (_rightHand != null)
        {
            //Get the right hand interactor and access the event
            _rightHandInteractor = _rightHand.GetComponent<XRDirectInteractor>();
            _leftHandInteractor.selectEntered.AddListener(ObjectThrown);

        }
        else
        {
            Debug.LogWarning("Right hand has not been attached, Check Tag on Right hand controller");

        }
        
        
    }

    private void ObjectThrown(SelectEnterEventArgs arg0)
    {
        _thrown = true;
    }

    //Added to grab interactable on the gameobject, if object picked up set thrown to true.
    //When loaded in gun, set false. Used for challenges
    public void ObjectShot(bool thrown)
    {
        _thrown = thrown;
    }
}
