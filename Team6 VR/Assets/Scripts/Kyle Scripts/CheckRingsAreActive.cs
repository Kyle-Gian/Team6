using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CheckRingsAreActive : MonoBehaviour
{
    List<GameObject> _ringsList = new List<GameObject>();
    List<RingScore> _ringScore = new List<RingScore>();

    public bool _allRingsAreActive = false;

    // Start is called before the first frame update
    void Start()
    {
        _ringsList = GameObject.FindGameObjectsWithTag("Ring").ToList();

        for (int i = 0; i < _ringsList.Count; i++)
        {
            _ringScore.Add(_ringsList[i].GetComponentInChildren<RingScore>());
        }

    }

    public bool CheckAllRingsAreActive()
    {
        for (int i = 0; i < _ringScore.Count; i++)
        {
            if (!_ringScore[i]._RingActive)
            {
                return false;                
            }
                    
        }
        return true;
    }

}
