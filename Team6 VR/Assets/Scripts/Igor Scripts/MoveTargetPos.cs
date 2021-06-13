using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTargetPos : MonoBehaviour
{
    Vector3 startPos;
    public Transform endPos;
    public float moveSpeed = 0.4f;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float step = moveSpeed * Time.deltaTime;
        if (transform.position != endPos.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, endPos.position, step);
        }
        else
        {
            endPos.position = startPos;
            startPos = transform.position;
        }

    }
}
