//Author Kyle Gian
//created: 29/5/2021
//Last Modified: 29/5/2021

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootFromGun : MonoBehaviour
{
    private ReloadWeapon _ReloadWeapon;
    [SerializeField] private float _shootingSpeed = 200;
    private bool _weaponShot = false;
    public Transform _barrel;
    // Start is called before the first frame update
    void Start()
    {
        _ReloadWeapon = GetComponent<ReloadWeapon>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_ReloadWeapon._loadedObjects.Count != 0)
        {
            foreach (var obj in _ReloadWeapon._loadedObjects)
            {
                //If the button has been pressed then shoot the bullet at the barrel position with the set speed
                if (GunButtonPress.ButtonPressed() && !_weaponShot)
                {
                    _weaponShot = true;
                    obj.transform.position = _barrel.position;
                    obj.SetActive(true);
                    obj.GetComponent<Rigidbody>().AddForce((_barrel.position.x * _shootingSpeed) * 10, _barrel.position.y * _shootingSpeed, (_barrel.position.z * _shootingSpeed) * 10);
                    _ReloadWeapon.RemoveObjectFromLoadedList(obj);
                    StartCoroutine("CanShoot");
                }

            }

        }
    }

    IEnumerator CanShoot()
    {
        yield return new WaitForSeconds(0.2f);
        _weaponShot = false;
    }
}
