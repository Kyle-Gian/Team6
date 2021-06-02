//Author Kyle Gian
//created: 2/6/2021
//Last Modified: 2/6/2021

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetHit : MonoBehaviour
{
    public bool _hasBeenHit = false;
    private Collider _targetCollider;
    private Material _objCurrentMaterial;
    private Color32 _objCurrentColor;
    [SerializeField] private Color32 _highLightColor;
    
    // Start is called before the first frame update
    void Start()
    {
        _objCurrentMaterial = GetComponent<MeshRenderer>().material;
        _objCurrentColor = _objCurrentMaterial.color;
        _highLightColor = new Color32();
        _targetCollider = GetComponent<Collider>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("LoadableObject"))
        {
            Debug.Log("Hit Target!!");
            _hasBeenHit = true;
            HighLightObjectOnHit();
        }
    }

    private void HighLightObjectOnHit()
    {
        _objCurrentMaterial.color = _highLightColor;
        
    }
    
}
