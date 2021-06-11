using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("LoadableObject"))
        {
            Application.Quit();
            Debug.Log("Quit");
        }
    }
}
