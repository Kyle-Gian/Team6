//Author Kyle Gian
//created: 2/6/2021
//Last Modified: 2/6/2021

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class RespawnInteractables : MonoBehaviour
{
    public UnityEvent ButtonPress;

    private GameObject _button;
    private ConfigurableJoint _joint;
    
    private List<GameObject> _interactables = new List<GameObject>();
    private List<GameObject> _cans = new List<GameObject>();
    private GameObject _weapon;

    private Vector3 _startPositon; 
    // Start is called before the first frame update
    void Start()
    {
        ButtonPress = new UnityEvent();
        _interactables = GameObject.FindGameObjectsWithTag("LoadableObject").ToList();
        _interactables = GameObject.FindGameObjectsWithTag("Can").ToList();
        _weapon = GameObject.FindGameObjectWithTag("Gun");
        _button = GameObject.FindGameObjectWithTag("Gun Button");
        _joint = _button.GetComponent<ConfigurableJoint>();
        _startPositon = _button.transform.position;

    }

    private void Update()
    {
        if(Vector3.Distance(_joint.targetPosition, _startPositon) > 0.1f)
        {
            if (ButtonPress != null)
               ButtonPress.Invoke();
        }
    }


    //Alex's inclusion
    public void ResetProjectiles()
    {
        _weapon.GetComponent<ResetPosition>().ResetObjectPos();

        for (int i = 0; i < _interactables.Count; i++)
        {
            _interactables[i].GetComponent<ResetPosition>().ResetObjectPos();
        }
    }

    public void ResetCans()
    {
        for (int i = 0; i < _cans.Count; i++)
        {
            _cans[i].GetComponent<ResetPosition>().ResetObjectPos();
        }
    }
}
