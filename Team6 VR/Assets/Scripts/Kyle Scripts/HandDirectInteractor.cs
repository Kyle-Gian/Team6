using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HandDirectInteractor : XRDirectInteractor
{
    public List<HitLocation> _hitLocations;
    void Awake()
    {
        _hitLocations = new List<HitLocation>();
        _hitLocations = GameObject.FindObjectsOfType<HitLocation>().ToList();

        foreach (var hitLocation in _hitLocations)
        {
            this.selectEntered.AddListener(hitLocation.HitLocation_hitEvent);

        }
        
    }
    
}
