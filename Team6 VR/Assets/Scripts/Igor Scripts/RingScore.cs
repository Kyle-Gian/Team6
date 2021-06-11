using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RingScore : MonoBehaviour
{
    ScoreScreen ss;
    public GameObject floatingScore;
    public int scoreValue;
    public bool _RingActive = false;

    RingsActivated _ringsChallenge;
    CheckRingsAreActive _ringCheck;

    private void Start()
    {
        ss = FindObjectOfType<ScoreScreen>();
        _ringsChallenge = FindObjectOfType<RingsActivated>();
        _ringCheck = FindObjectOfType<CheckRingsAreActive>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            GameObject points = Instantiate(floatingScore, transform.position, Quaternion.identity);
            points.transform.GetChild(0).GetComponent<TextMeshPro>().text = scoreValue.ToString();
            ss.score += scoreValue;

            if (!_RingActive)
            {
                if (_ringCheck.CheckAllRingsAreActive())
                {
                    AllRingsActive();
                }
            }
        }
    }

    public void AllRingsActive()
    {
        if (!_ringsChallenge._challengeComplete)
        {
            _ringsChallenge.ChallengeComplete();
        }
    }
}
