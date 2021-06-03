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
    public void ResetAllPositions()
    {
        for (int i = 0; i < _interactables.Count; i++)
        {
            _interactables[i].GetComponent<ResetPosition>().ResetObjectPos();
        }
    }
}
