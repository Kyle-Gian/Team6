//Author Kyle Gian
//created: 7/6/2021
//Last Modified: 7/6/2021
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class SmallTargetKnockedDown : MonoBehaviour
{
    public bool _targetKnocked = false;
    public UnityEvent AreAllTargetsKnocked;
    Animator _animator;
    
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponentInParent<Animator>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("LoadableObject"))
        {
            if (!_targetKnocked)
            {
                _targetKnocked = true;
                _animator.SetBool("reset", false);
                _animator.SetBool("knockDown", true);
                AreAllTargetsKnocked.Invoke();
            }
        }
    }
}
