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

    string _hingeTagName;


    // Start is called before the first frame update
    void Start()
    {
        _hingeTagName = "PopUpTarget";

        if (_hingeTagName != null)
        {
            _targets = GameObject.FindGameObjectsWithTag(_hingeTagName).ToList();

            foreach (var item in _targets)
            {
                _targetAnimator.Add(item.GetComponentInParent<Animator>());
                item.GetComponentInParent<SmallTargetKnockedDown>().AreAllTargetsKnocked.AddListener(CheckTargetsNeedToBeReset);
            }            
        }
    }

    public void ResetTargets()
    {
        for (int i = 0; i < _targets.Count; i++)
        {
            Animator animator = _targetAnimator[i];
            animator.SetBool("reset", true);
            animator.SetBool("knockDown", false);
        }
    }

    public void CheckTargetsNeedToBeReset()
    {
        for (int i = 0; i < _targets.Count; i++)
        {
            if (!_targets[i].GetComponentInParent<SmallTargetKnockedDown>()._targetKnocked)
            {
                break;
            }

            if (i == _targets.Count)
            {
                ResetTargets();
            }
        }          
    }
}
