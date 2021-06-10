using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class CanRotation : MonoBehaviour
{
    public List<Color> colors = new List<Color>();

    public GameObject floatingScore;

    public List<Transform> cans1 = new List<Transform>();
    public List<Transform> cans2 = new List<Transform>();
    public List<Transform> cans3 = new List<Transform>();
    public List<Transform> cans4 = new List<Transform>();
    public List<Transform> allCans = new List<Transform>();

    public bool allCansFallen = false;

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
                allCans.Add(canStack.GetChild(j));
            }

            //for (int j = 0; j < canStack.childCount; j++)
            //{
            //    if (i == 0)
            //    {
            //        cans1.Add(canStack.GetChild(j));

            //    }
            //    else if (i == 1)
            //    {
            //        cans2.Add(canStack.GetChild(j));

            //    }
            //    else if (i == 2)
            //    {
            //        cans3.Add(canStack.GetChild(j));

            //    }
            //    else if (i == 3)
            //    {
            //        cans4.Add(canStack.GetChild(j));

            //    }
            //}
        }
    }

    private void Update()
    {

        //foreach (var c in cans4)
        //{
        //    CanRotationCheck(c);
        //}
        //foreach (var c in cans3)
        //{
        //    CanRotationCheck(c);

        //}
        //foreach (var c in cans2)
        //{
        //    CanRotationCheck(c);
        //}
        //foreach (var c in cans1)
        //{
        //    CanRotationCheck(c);

        //}

        for (int i = 0; i < allCans.Count; i++)  
        {
            if (!CanRotationCheck(allCans[i]))
            {
                break;
            }
            if (i == allCans.Count)
            {
                allCansFallen = true;
            }

        }
        if (allCansFallen)
        {
            foreach (var c in allCans)
            {
                c.GetComponent<ResetCanPos>().ResetObjectPos();
            }
            allCansFallen = false;
        }

    }


    public bool CanRotationCheck(Transform can)
    {
        CanSelfData data = can.GetComponent<CanSelfData>();

        if (!data.fallen)
        {
            if (can.eulerAngles.x > angle1 && can.eulerAngles.x < angle2 || can.eulerAngles.z > angle1 && can.eulerAngles.z < angle2)
            {
                data.fallen = true;
                ShowScoreText(scoreValue, can);
                return true;
                //can.GetComponent<AudioSource>().clip = impact;
                //can.GetComponent<AudioSource>().Play();
            }
        }
        return false;
    }


    public void ShowScoreText(int score, Transform can)
    {
        //GameObject points = Instantiate(floatingScore, can.position, Quaternion.identity);
        //points.transform.GetChild(0).GetComponent<TextMeshPro>().text = score.ToString();
        //ss.score += score;

        TextMeshPro text = floatingScore.transform.GetChild(0).GetComponent<TextMeshPro>();

        int randomNumber = Random.Range(0, colors.Count);

        text.color = new Color(colors[randomNumber].r, colors[randomNumber].g, colors[randomNumber].b, 1);

        GameObject points = Instantiate(floatingScore, can.position, Quaternion.identity);
        points.transform.GetChild(0).GetComponent<TextMeshPro>().text = score.ToString();
        ss.score += score;
        Destroy(points, 2f);
    }
}
