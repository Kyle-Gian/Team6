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

    //[HideInInspector]
    //public bool expand;

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

        //if (expand)
        //    OnShoot();
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

    //void OnShoot()
    //{
    //    foreach (GameObject item in shotItems)
    //    {
    //        //item.GetComponentInChildren<Collider>().enabled = false;
    //        item.GetComponent<Rigidbody>().isKinematic = false;

    //        //Shrink
    //        item.transform.localScale = Vector3.Lerp(item.transform.localScale, new Vector3(1, 1, 1), shrinkSpeed * Time.deltaTime);
    //    }

    //    Invoke("RemoveShotItem", 5);

    //}

    //void RemoveShotItem()
    //{
    //    shotItems.RemoveAt(0);
    //}
}
