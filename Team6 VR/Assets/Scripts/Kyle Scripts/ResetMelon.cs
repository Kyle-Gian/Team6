using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetMelon : MonoBehaviour
{
    public GameObject _waterMelon;
    [SerializeField] private GameObject _watremelonPrefab;
    
    private Vector3 _startPos;
    [SerializeField] private float _waitTime = 2;
    private bool _inAction;
    ReloadWeapon _reloadWeapon;
    private Quaternion _startRotation;
    // Start is called before the first frame update
    void Start()
    {
        if (_waterMelon != null)
        {
            _startPos = _waterMelon.transform.position;
            _reloadWeapon = FindObjectOfType<ReloadWeapon>();
            _reloadWeapon.ObjectLoaded.AddListener(ObjectInAction);
            _reloadWeapon.ObjectShot.AddListener(ObjectNotInAction);
        }
        else
        {
            Debug.Log("WaterMelon Null");
        }


    }

    // Update is called once per frame
    void Update()
    {
        //Check the distance from start position, will trigger respawn after set time
        if (Vector3.Distance(transform.position, _startPos) > 0.5f)
        {
            if (!_inAction)
            {
                if (_waterMelon != null)
                {
                    Destroy(_waterMelon);
                    Instantiate(_watremelonPrefab, _startPos,Quaternion.identity);
                    _waterMelon = _watremelonPrefab;
                }

                if (_waterMelon == null)
                {
                    _waterMelon = _watremelonPrefab;
                }
            }
        }
    }
    
    public void ObjectInAction()
    {
        _inAction = true;
    }
    public void ObjectNotInAction()
    {
        _inAction = false;
    }
}
