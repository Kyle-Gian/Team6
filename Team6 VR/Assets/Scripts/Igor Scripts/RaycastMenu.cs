using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastMenu : MonoBehaviour
{

    Camera cam;
    public float range = 50f;
    public GameObject shotEffect;
    public float timer = 0f;
    public float timerLimit = 3f;
    public bool canHit = false;
    //public LayerMask layerMask;
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        ShootRay();
    }


    public void ShootRay()
    {
        int layerMask = 1 << 8;

        Vector3 rayOrigin = cam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));

        RaycastHit hit;

        if (Physics.Raycast(rayOrigin, cam.transform.forward, out hit, range, layerMask))
        {
            Instantiate(shotEffect, hit.point, Quaternion.identity);
            timer += Time.deltaTime;
            if (timer >= timerLimit)
                canHit = true;
        }
        else
        { 
            canHit = false;
            timer = 0f;
        }

    }

}
