using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootRocket : MonoBehaviour
{
    public GameObject rocket;
    public Camera fpsCam;
    //public int rocketAmmo = 4;    // Start is called before the first frame update
    void Start()
    {
        fpsCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        ShootCheck();
    }

    void ShootCheck()
    {
        //if (PauseMenu.gameIsPaused == true)
        //    return;

        if (Input.GetButtonDown("Fire2"))
        {
            //rocketAmmo--;
            //if (rocketAmmo > 0)
            //{
                Vector3 rayOrigin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));

                RaycastHit hit;


                if (Physics.Raycast(rayOrigin, fpsCam.transform.forward, out hit))
                {
                    GameObject rkt = Instantiate(rocket, gameObject.transform.position, gameObject.transform.rotation);

                   // rkt.GetComponent<Rocket>().SetTarget(hit.point);
                }
            //}
        }
    }
}
