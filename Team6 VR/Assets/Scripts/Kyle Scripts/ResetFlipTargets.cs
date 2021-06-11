//Author Kyle Gian
//created: 9/6/2021
//Last Modified: 9/6/2021

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ResetFlipTargets : MonoBehaviour
{
    List<GameObject> _targets = new List<GameObject>();
    List<Animator> _targetAnimator = new List<Animator>();

    public string _hingeTagName;


    // Start is called before the first frame update
    void Start()
    {
        if (_hingeTagName != null)
        {
            _targets = GameObject.FindGameObjectsWithTag(_hingeTagName).ToList();

            foreach (var item in _targets)
            {
                _targetAnimator.Add(item.GetComponent<Animator>());
            }

        }

    }

    public void ResetTargets()
    {
        for (int i = 0; i < _targets.Count; i++)
        {
            Animator animator = _targets[i].GetComponent<Animator>();
            animator.SetBool("reset", true);
            animator.SetBool("knockDown", false);
        }
    }
}
