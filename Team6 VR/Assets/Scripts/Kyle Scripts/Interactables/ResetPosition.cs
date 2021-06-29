//Author Kyle Gian
//created: 3/6/2021
//Last Modified: 3/6/2021

using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ResetPosition : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private Vector3 _startPos;
    [SerializeField] private float _waitTime = 5;
    private bool _inAction;
    ReloadWeapon _reloadWeapon;
    private Quaternion _startRotation;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _startPos = transform.position;
        _startRotation = Quaternion.identity;

        //Set up the unity events to change if object is in action
        _reloadWeapon = FindObjectOfType<ReloadWeapon>();
        _reloadWeapon.ObjectLoaded.AddListener(ObjectInAction);
        _reloadWeapon.ObjectShot.AddListener(ObjectNotInAction);
        
        GetComponent<XRGrabInteractable>().selectEntered.AddListener(ObjectInAction);
        GetComponent<XRGrabInteractable>().selectExited.AddListener(ObjectNotInAction);

    }



    // Update is called once per frame
    void Update()
    {
        //Check the distance from start position, will trigger respawn after set time
        if (Vector3.Distance(transform.position, _startPos) > .5f)
        {
            if (!_inAction)
            {
                StartCoroutine("RespawnTime");
            }
        }
    }

    public void ResetObjectPos()
    {
        if (!_inAction)
        {
            gameObject.SetActive(false);
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.rotation = _startRotation;
            _rigidbody.angularVelocity = Vector3.zero;
            transform.position = _startPos;
            gameObject.SetActive(true);
        }

    }

    IEnumerator RespawnTime()
    {
        yield return new WaitForSeconds(_waitTime);
        ResetObjectPos();
    }

    public void ObjectInAction()
    {
        _inAction = true;
    }
    public void ObjectNotInAction()
    {
        _inAction = false;
    }
    
    private void ObjectInAction(SelectEnterEventArgs arg0)
    {
        _inAction = true;
    }
    
    private void ObjectNotInAction(SelectExitEventArgs arg0)
    {
        _inAction = false;

    }

    
}
