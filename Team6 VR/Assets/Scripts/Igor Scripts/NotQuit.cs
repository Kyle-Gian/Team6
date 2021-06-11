using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
