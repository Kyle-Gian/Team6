using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanRotation : MonoBehaviour
{
    [SerializeField]
    float eulerAngleX;
    [SerializeField]
    float eulerAngleY;
    [SerializeField]
    float eulerAngleZ;

    public List<Transform> cans1 = new List<Transform>();
    public List<Transform> cans2 = new List<Transform>();
    public List<Transform> cans3 = new List<Transform>();
    public List<Transform> cans4 = new List<Transform>();

    public Vector3 eulerAngles;

    ScoreScreen ss;

    public int scoreValue;

    private void Start()
    {
        ss = FindObjectOfType<ScoreScreen>();
        eulerAngles = transform.localEulerAngles;

        for (int i = 0; i < transform.childCount; i++)
        {
            Transform canStack = transform.GetChild(i);

            for (int j = 0; j < canStack.childCount; j++)
            {
                if (i == 0)
                {
                    cans1.Add(canStack.GetChild(j));

                }
                else if (i == 1)
                {
                    cans2.Add(canStack.GetChild(j));

                }
                else if (i == 2)
                {
                    cans3.Add(canStack.GetChild(j));

                }
                else if (i == 3)
                {
                    cans4.Add(canStack.GetChild(j));

                }
            }
        }

    }

    private void Update()
    {
        foreach (var c in cans1)
        {
            CanRotationCheck(c);
        }


    }

    //private void OnCollisionEnter(Collision other)
    //{
    //    if (other.gameObject.CompareTag("Ball"))
    //    {
    //        if (eulerAngles.x > 45f && eulerAngles.x < 315f || eulerAngles.z > 45f && eulerAngles.z < 315f)
    //        {
    //            ss.score += scoreValue;
    //        }
    //    }
    //}

    public void CanRotationCheck(Transform can)
    {
        if (can.eulerAngles.x > 45f && can.eulerAngles.x < 315f || can.eulerAngles.z > 45f && can.eulerAngles.z < 315f)
        {
            
            ss.score += scoreValue;
            can.GetComponent<CanSelfData>().fallen = true;
        }
    }
}
