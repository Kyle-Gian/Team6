using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RingScore : MonoBehaviour
{
    ScoreScreen ss;
    public GameObject floatingScore;
    public int scoreValue;

    private void Start()
    {
        ss = FindObjectOfType<ScoreScreen>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            GameObject points = Instantiate(floatingScore, transform.position, Quaternion.identity);
            points.transform.GetChild(0).GetComponent<TextMeshPro>().text = scoreValue.ToString();
            ss.score += scoreValue;
        }
    }
}
