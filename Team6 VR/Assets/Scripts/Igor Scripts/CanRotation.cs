using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class CanRotation : MonoBehaviour
{
    public List<Color> colors = new List<Color>();

    public GameObject floatingScore;

    public List<Transform> allCans = new List<Transform>();

    public bool allCansFallen = false;

    public float angle1 = 45f;
    public float angle2 = 315f;

    public CanFallenAmount numOfCansFallen;

    public Vector3 eulerAngles;

    ScoreScreen ss;

    public int scoreValue;



    private void Start()
    {
        numOfCansFallen.numberOfCansFallenOver = 0;

        ss = FindObjectOfType<ScoreScreen>();
        eulerAngles = transform.localEulerAngles;

        for (int i = 0; i < transform.childCount; i++)
        {
            Transform canStack = transform.GetChild(i);

            for (int j = 0; j < canStack.childCount; j++)
            {
                allCans.Add(canStack.GetChild(j));
            }
        }
    }

    private void Update()
    {

        foreach (var c in allCans)
        {
            CanCheck(c);
            if (numOfCansFallen.numberOfCansFallenOver == 36)
            {
                numOfCansFallen.numberOfCansFallenOver = 0;
                foreach (var can in allCans)
                {
                    can.GetComponent<ResetCanPos>().ResetObjectPos();
                    can.GetComponentInChildren<Renderer>().material.color = Color.green;

                }
            }
        }
    }


    public void CanCheck(Transform can)
    {
        CanSelfData canData = can.GetComponent<CanSelfData>();

        if (!canData.fallen)
        {

            if (CheckCanPosAndAngle(can, canData))
            {
                canData.fallen = true;
                numOfCansFallen.numberOfCansFallenOver += 1;
                ShowScoreText(scoreValue, can);
                can.GetComponentInChildren<Renderer>().material.color = Color.red;
            }
            //if (can.eulerAngles.x > angle1 && can.eulerAngles.x < angle2 || can.eulerAngles.z > angle1 && can.eulerAngles.z < angle2)
            //{
            //    canData.fallen = true;
            //    numOfCansFallen.numberOfCansFallenOver += 1;
            //    ShowScoreText(scoreValue, can);
            //    can.GetComponentInChildren<Renderer>().material.color = Color.red;

            //}
        }
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


    public bool CheckCanPosAndAngle(Transform can, CanSelfData canData)
    {
        if (can.eulerAngles.x > angle1 && can.eulerAngles.x < angle2 || can.eulerAngles.z > angle1 && can.eulerAngles.z < angle2) // Check angle
            return true;

        if (Vector3.Distance(can.position, canData.startPos) > 0.1f) //Check position
            return true;


        return false;
    }

}
