using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GunResetPosition : MonoBehaviour
{
   private Rigidbody _rigidbody;
    private Vector3 _startPos;
    [SerializeField] private float _waitTime = 5;
    private bool _inAction;
    private Quaternion _startRotation;
    
    public GameObject _leftHand;
    public GameObject _rightHand;
    XRDirectInteractor _leftHandInteractor;
    XRDirectInteractor _rightHandInteractor;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _startPos = transform.position;
        _startRotation = Quaternion.identity;
        _leftHand = GameObject.FindWithTag("left");
        _rightHand = GameObject.FindWithTag("right");

        //If either the left or right hand are null throw an error for the user
        if (_leftHand != null)
        {
            //Get the left hand interactor and access the event
            _leftHandInteractor = _leftHand.GetComponent<XRDirectInteractor>();
            _leftHandInteractor.selectEntered.AddListener(ObjectInAction);
            _leftHandInteractor.selectExited.AddListener(ObjectNotInAction);


        }
        else
        {
            Debug.LogWarning("Left hand has not been attached, Check Tag on left hand controller");

        }
        if (_rightHand != null)
        {
            //Get the right hand interactor and access the event
            _rightHandInteractor = _rightHand.GetComponent<XRDirectInteractor>();
            _rightHandInteractor.selectEntered.AddListener(ObjectInAction);
            _rightHandInteractor.selectExited.AddListener(ObjectNotInAction);


        }
        else
        {
            Debug.LogWarning("Right hand has not been attached, Check Tag on Right hand controller");

        }

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(_inAction);
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

    public void ObjectInAction(SelectEnterEventArgs test)
    {
        _inAction = true;
    }
    public void ObjectNotInAction(SelectExitEventArgs test)
    {
        _inAction = false;
    }
}
