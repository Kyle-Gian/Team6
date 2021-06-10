using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CanRotation : MonoBehaviour
{
    public GameObject floatingScore;

    public List<Transform> cans1 = new List<Transform>();
    public List<Transform> cans2 = new List<Transform>();
    public List<Transform> cans3 = new List<Transform>();
    public List<Transform> cans4 = new List<Transform>();
    public float angle1 = 45f;
    public float angle2 = 315f;

    //public AudioClip impact;
    //AudioSource audioSource;

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

        foreach (var c in cans4)
        {
            CanRotationCheck(c);
        }
        foreach (var c in cans3)
        {
            CanRotationCheck(c);

        }
        foreach (var c in cans2)
        {
            CanRotationCheck(c);
        }
        foreach (var c in cans1)
        {
            CanRotationCheck(c);
        }
    }


    public void CanRotationCheck(Transform can)
    {
        CanSelfData data = can.GetComponent<CanSelfData>();
        
        if (!data.fallen)
        {
            if (can.eulerAngles.x > angle1 && can.eulerAngles.x < angle2 || can.eulerAngles.z > angle1 && can.eulerAngles.z < angle2)
            {
                data.fallen = true;
                ShowScoreText(scoreValue, can);
                //can.GetComponent<AudioSource>().clip = impact;
                //can.GetComponent<AudioSource>().Play();
            }
        }
    }


    public void ShowScoreText(int score, Transform can)
    {
        GameObject points = Instantiate(floatingScore, can.position, Quaternion.identity);
        points.transform.GetChild(0).GetComponent<TextMeshPro>().text = score.ToString();
        ss.score += score;
    }
}
