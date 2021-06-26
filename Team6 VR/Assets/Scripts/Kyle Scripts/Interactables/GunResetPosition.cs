using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GunResetPosition : MonoBehaviour
{
   private Rigidbody _rigidbody;
    private Vector3 _startPos;
    [SerializeField] private float _waitTime = 2;
    private bool _inHand;
    private Quaternion _startRotation;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _startPos = transform.position;
        _startRotation = Quaternion.identity;

    }

    // Update is called once per frame
    void Update()
    {
        //Check the distance from start position, will trigger respawn after set time
        if (Vector3.Distance(transform.position, _startPos) > 0.6f)
        {
            if (!_inHand)
            {
                StartCoroutine("RespawnTime");
            }
        }
    }

    public void ResetObjectPos()
    {
        if (!_inHand)
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

    public void InHand(bool isInhand)
    {
        _inHand = isInhand;
    }

}
