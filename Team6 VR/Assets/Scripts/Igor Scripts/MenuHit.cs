//Author Igor Doslov
//created: 10/6/2021
//Last Modified: 17/6/2021

using UnityEngine;

// Makes "yes" and "no" menu buttons appear when "quit" button is hit
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
