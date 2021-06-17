//Author Kyle Gian
//created: 29/5/2021
//Last Modified: 29/5/2021

using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;

public class ShootFromGun : MonoBehaviour
{
    private ReloadWeapon _ReloadWeapon;
    [SerializeField] private float _shootingSpeed = 200;
    public bool _weaponShot = false;
    public Transform _barrel;

    [HideInInspector] public UnityEvent ObjectShotFromGun;

    // Start is called before the first frame update
    void Start()
    {
        _ReloadWeapon = GetComponent<ReloadWeapon>();
        ObjectShotFromGun = new UnityEvent();
        ObjectShotFromGun.AddListener(Test);
    }

    // Update is called once per frame
    void Update()
    {
        if (_ReloadWeapon._loadedObjects.Count != 0)
        {
            foreach (var obj in _ReloadWeapon._loadedObjects.ToList())
            {
                //If the button has been pressed then shoot the bullet at the barrel position with the set speed
                if (GunButtonPress.ButtonPressed() && !_weaponShot)
                {
                    Rigidbody objRB = obj.GetComponentInChildren<Rigidbody>();
                    _weaponShot = true;
                    obj.transform.position = _barrel.position;
                    obj.SetActive(true);
                    
                    obj.GetComponent<Collider>().enabled = true;
                    objRB.isKinematic = false;
                    obj.transform.localScale = new Vector3(1, 1, 1);
                    
                    ObjectShotFromGun.Invoke();

                    objRB.velocity = _barrel.TransformDirection(new Vector3(0, 0, _shootingSpeed * 100 * Time.fixedDeltaTime));
                    _ReloadWeapon.RemoveObjectFromLoadedList(obj);
                    StartCoroutine("CanShoot");

                }

            }

        }
    }

    IEnumerator CanShoot()
    {
        yield return new WaitForSeconds(0.3f);
        _weaponShot = false;
    }

    void Test()
    {
        Debug.LogWarning("Event Invoked");
    }
}
