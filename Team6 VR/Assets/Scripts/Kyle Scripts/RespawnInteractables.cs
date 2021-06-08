//Author Kyle Gian
//created: 2/6/2021
//Last Modified: 2/6/2021

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RespawnInteractables : MonoBehaviour
{
    [SerializeField] private Transform _button;
    private Vector3 _startPosition;
    
    private List<GameObject> _interactables = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        _startPosition = _button.position;
        _interactables = GameObject.FindGameObjectsWithTag("LoadableObject").ToList();
    }

    private void Update()
    {
        if (Vector3.Distance(_button.position, _startPosition) > 0.01f)
        {
            for (int i = 0; i < _interactables.Count; i++)
            {
                _interactables[i].GetComponent<ResetPosition>().ResetObjectPos();
            }
        }    
    }
    
}
