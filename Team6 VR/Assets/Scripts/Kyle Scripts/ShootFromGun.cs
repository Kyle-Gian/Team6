//Author Kyle Gian
//created: 29/5/2021
//Last Modified: 29/5/2021

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootFromGun : MonoBehaviour
{
    private ReloadWeapon _ReloadWeapon;
    [SerializeField] private float _shootingSpeed = 100;

    private Transform _barrel;
    // Start is called before the first frame update
    void Start()
    {
        _ReloadWeapon = GetComponent<ReloadWeapon>();
        _barrel = GameObject.FindWithTag("Barrel").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (_ReloadWeapon._loadedObjects.Count != 0)
        {
            foreach (var obj in _ReloadWeapon._loadedObjects)
            {
                //If the button has been pressed then shoot the bullet at the barrel position with the set speed
                if (GunButtonPress.ButtonPressed())
                {
                    obj.transform.position = _barrel.position;
                    obj.SetActive(true);
                    obj.GetComponent<Rigidbody>().AddForce(0, _shootingSpeed, _shootingSpeed);
                    _ReloadWeapon.RemoveObjectFromLoadedList(obj);
                }

            }
        }
    }
}
