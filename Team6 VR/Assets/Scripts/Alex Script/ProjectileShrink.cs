using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        if (!_audio.isPlaying)
        {
            _audio.Play();
        }

        foreach (GameObject item in loadedItems)
        {
            //item.GetComponentInChildren<Collider>().enabled = false;
            item.GetComponent<Rigidbody>().isKinematic = true;


            //Shrink
            item.transform.localScale = Vector3.Lerp(item.transform.localScale, item.transform.localScale * 0.1f, shrinkSpeed * Time.deltaTime);

            //Move
            item.transform.position = Vector3.Lerp(item.transform.position, this.transform.position, movementSpeed * Time.deltaTime);
        }

    }

    void OnShoot()
    {

    }
}
