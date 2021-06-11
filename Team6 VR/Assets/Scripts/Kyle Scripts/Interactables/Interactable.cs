//Author Kyle Gian
//created: 3/6/2021
//Last Modified: 3/6/2021

using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Interactable : MonoBehaviour
{
    [HideInInspector] public Vector3 _startPosition;
    public ParticleSystem _collisionParticle;
    public ParticleSystem _trailParticle;
    [HideInInspector] public bool _thrown;

    ReloadWeapon reloadWeapon;
    GameObject _leftHand;
    GameObject _rightHand;
    XRDirectInteractor _leftHandInteractor;
    XRDirectInteractor _rightHandInteractor;

    private void Start()
    {
        _startPosition = transform.position;
        reloadWeapon = FindObjectOfType<ReloadWeapon>();
        reloadWeapon.ObjectLoaded.AddListener(delegate { ObjectThrown(false); });


        _leftHand = GameObject.FindGameObjectWithTag("left");
        _rightHand = GameObject.FindGameObjectWithTag("right");

        //If either the left or right hand are null throw an error for the user
        if (_leftHand != null)
        {
            //Get the left hand interactor and access the event
            _leftHandInteractor = _leftHand.GetComponent<XRDirectInteractor>();
            _leftHandInteractor.selectEntered.RemoveListener(ObjectHasHitTargetOnThrow);

        }
        else
        {
            Debug.LogError("Left hand has not been attached, Check Tag on left hand controller");

        }
        if (_rightHand != null)
        {
            //Get the right hand interactor and access the event
            _rightHandInteractor = _rightHand.GetComponent<XRDirectInteractor>();
            _rightHandInteractor.selectEntered.RemoveListener(ObjectHasHitTargetOnThrow);

        }
        else
        {
            Debug.LogError("Right hand has not been attached, Check Tag on Right hand controller");

        }


    }

    public void ObjectHasHitTargetOnThrow(SelectEnterEventArgs test)
    {
    }

    //Added to grab interactable on the gameobject, if object picked up set thrown to true.
    //When loaded in gun, set false. Used for challenges
    public void ObjectThrown(bool thrown)
    {
        _thrown = thrown;
    }
}
