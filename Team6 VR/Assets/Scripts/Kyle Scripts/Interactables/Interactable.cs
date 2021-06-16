//Author Kyle Gian
//created: 3/6/2021
//Last Modified: 3/6/2021

using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

//Class used by objects that are thrown or shot at the targets
public class Interactable : MonoBehaviour
{
    [HideInInspector] public Vector3 _startPosition;
    [HideInInspector] public bool _thrown;

    ReloadWeapon reloadWeapon;


    private void Start()
    {
        _startPosition = transform.position;
        reloadWeapon = FindObjectOfType<ReloadWeapon>();
        reloadWeapon.ObjectLoaded.AddListener(delegate { ObjectThrown(false); });
        
    }
    
    //Added to grab interactable on the gameobject, if object picked up set thrown to true.
    //When loaded in gun, set false. Used for challenges
    public void ObjectThrown(bool thrown)
    {
        _thrown = thrown;
    }
}
