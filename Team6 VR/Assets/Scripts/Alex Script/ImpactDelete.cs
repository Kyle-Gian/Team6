//Author Alex Smits
//created: 10/6/2021
//Last Modified: 17/6/2021

using UnityEngine;

//Destroys gameobject after specified time
public class ImpactDelete : MonoBehaviour
{

    public float timer = 1;
    void Start()
    {
        Destroy(gameObject, timer);
    }
}
