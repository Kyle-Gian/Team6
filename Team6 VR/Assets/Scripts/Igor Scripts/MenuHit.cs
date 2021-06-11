using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuHit : MonoBehaviour
{
    public GameObject yes;
    public GameObject no;
    public RaycastMenu cam;

    private void Start()
    {
        cam = FindObjectOfType<RaycastMenu>(); 
    }

    private void OnCollisionEnter(Collision other)
    {
        if (cam.canHit)
        {
            if (other.gameObject.CompareTag("LoadableObject"))
            {
                yes.SetActive(true);
                no.SetActive(true);
            }
        }
    }
}
