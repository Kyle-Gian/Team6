//Author Igor Doslov
//created: 10/6/2021
//Last Modified: 17/6/2021

using UnityEngine;

// Detects when the player is looking directly at the menu so that it can be selectable
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
        int layerMask = 1 << 8; // layer 8

        Vector3 rayOrigin = cam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));

        RaycastHit hit;

        if (Physics.Raycast(rayOrigin, cam.transform.forward, out hit, range, layerMask, QueryTriggerInteraction.Collide))
        {
            Instantiate(shotEffect, hit.point, Quaternion.identity);
            timer += Time.deltaTime; // must look at the menu for a certain time
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
