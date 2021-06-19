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
    SmallTargetsKnocked _smallTargetsChallenge;

    string _hingeTagName;

    // Start is called before the first frame update
    void Start()
    {
        _hingeTagName = "PopUpTarget";
        _smallTargetsChallenge = FindObjectOfType<SmallTargetsKnocked>();

        if (_hingeTagName != null)
        {
            _targets = GameObject.FindGameObjectsWithTag(_hingeTagName).ToList();

            foreach (var item in _targets)
            {
                //item.GetComponentInChildren<SmallTargetKnockedDown>().AreAllTargetsKnocked.AddListener(CheckTargetsNeedToBeReset);
            }            
        }
    }

    public void ResetTargets()
    {
        for (int i = 0; i < _targets.Count; i++)
        {
            _targets[i].GetComponentInChildren<SmallTargetKnockedDown>()._targetKnocked = false;
            Animator animator = _targets[i].GetComponentInParent<Animator>();
            animator.SetBool("reset", true);
            animator.SetBool("knockDown", false);
        }
    }

    public void CheckTargetsNeedToBeReset()
    {
        for (int i = 0; i != _targets.Count; i++)
        {
            if (i == _targets.Count - 1)
            {
                ResetTargets();
                _smallTargetsChallenge.ChallengeComplete();
            }
            
            if (!_targets[i].GetComponentInChildren<SmallTargetKnockedDown>()._targetKnocked)
            {
                break;
            }


        }          
    }
}
