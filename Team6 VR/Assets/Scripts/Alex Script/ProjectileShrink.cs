//Author Alex Smits
//created: 12/6/2021
//Last Modified: 17/6/2021

using System.Collections.Generic;
using UnityEngine;

// To shrink the projectile when it is loaded into the gun
[RequireComponent(typeof(AudioSource))]
public class ProjectileShrink : MonoBehaviour
{

    public float shrinkSpeed;
    public float movementSpeed;

    public List<GameObject> loadedItems;

    public List<GameObject> shotItems;

    [HideInInspector]
    public bool shrink;

    [HideInInspector]
    public AudioSource _audio;

    void Start()
    {
        _audio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (shrink)
            OnLoad();
    }

    void OnLoad()
    {

        if(_audio.clip == null)
        {
            Debug.Log("Missing Audio Clip!");
        }



        foreach (GameObject item in loadedItems)
        {
            item.GetComponent<Rigidbody>().isKinematic = true;

            if (!_audio.isPlaying)
            {
                _audio.Play();
            }

            //Shrink
            item.transform.localScale = Vector3.Lerp(item.transform.localScale, item.transform.localScale * 0.1f, shrinkSpeed * Time.deltaTime);

            //Move
            item.transform.position = Vector3.Lerp(item.transform.position, this.transform.position, movementSpeed * Time.deltaTime);
        }

    }

}
