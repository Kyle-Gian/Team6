//Author Igor Doslov
//created: 10/6/2021
//Last Modified: 17/6/2021

using UnityEngine;

// Makes menu disappear when projectile hits "no" menu button
public class NotQuit : MonoBehaviour
{
    public GameObject yes;
    public GameObject no;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("LoadableObject"))
        {
            yes.SetActive(false);
            no.SetActive(false);
        }
    }
}
