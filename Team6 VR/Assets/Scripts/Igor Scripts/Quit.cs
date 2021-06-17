//Author Igor Doslov
//created: 10/6/2021
//Last Modified: 17/6/2021

using UnityEngine;

// Quits the game when player shoots the quit menu button
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
