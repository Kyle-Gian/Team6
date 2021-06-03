//Author Kyle Gian
//created: 2/6/2021
//Last Modified: 2/6/2021

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RespawnInteractables : MonoBehaviour
{
    private List<GameObject> _interactables = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        _interactables = GameObject.FindGameObjectsWithTag("Loadableobject").ToList();
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var item in _interactables)
        {

        }
    }

    private bool HasItemBeenRemoved(GameObject interactable)
    {
        
        return false;
    }
}
