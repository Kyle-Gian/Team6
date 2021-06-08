using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<Player>().onEnemyHit += ChangeColor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ChangeColor(Color color)
    {
        //transform.GetComponent<Renderer>().material.color = color;
        Debug.Log("Change colour");
    }
}
