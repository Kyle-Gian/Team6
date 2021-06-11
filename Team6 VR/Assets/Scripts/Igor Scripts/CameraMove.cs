using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class CameraMove : MonoBehaviour
{
    protected Vector3 moveVec = Vector3.zero; // movement speed of player
    public float moveSpeed = 10;
    protected Rigidbody rigidbody;			// reference to the rigidbody

    // Start is called before the first frame update
    void Start()
    {
		rigidbody = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        rigidbody.velocity = moveVec * moveSpeed;

        // 2
        if (moveVec != Vector3.zero)
        {
            transform.LookAt(this.transform.position + moveVec.normalized);
        }
    }

    public void OnMove(InputValue input)
    {
        Vector2 inputVec = input.Get<Vector2>();

        moveVec = new Vector3(inputVec.x, 0, inputVec.y);
    }
}
