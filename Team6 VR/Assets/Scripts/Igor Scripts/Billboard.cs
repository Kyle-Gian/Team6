//Author Igor Doslov
//created: 10/6/2021
//Last Modified: 17/6/2021

using UnityEngine;

// For making the score text always face the player
public class Billboard : MonoBehaviour
{
    Transform cam;
    private void Start()
    {
        cam = Camera.main.transform;
    }
    // Update is called once per frame
    void LateUpdate()
    {
        transform.LookAt(transform.position + cam.forward); 
    }
}
