using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class ProjectileShrink : MonoBehaviour
{

    public float shrinkSpeed;
    public float movementSpeed;

    [HideInInspector]
    public List<GameObject> loadedItems;

    [HideInInspector]
    public bool shrink;

    private AudioSource audio;

    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (shrink)
            OnLoad();
    }

    void OnLoad()
    {
        if(audio.clip == null)
        {
            Debug.Log("Missing Audio Clip!");
        }

        if (!audio.isPlaying)
        {
            audio.Play();
        }
        foreach (GameObject item in loadedItems)
        {
            item.GetComponent<Rigidbody>().isKinematic = true;

            //Shrink
            item.transform.localScale = Vector3.Lerp(item.transform.localScale, item.transform.localScale * 0.1f, shrinkSpeed * Time.deltaTime);

            //Move
            item.transform.position = Vector3.Lerp(item.transform.position, this.transform.position, movementSpeed * Time.deltaTime);
        }

    }
}
