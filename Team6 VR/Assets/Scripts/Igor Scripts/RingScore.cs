using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RingScore : MonoBehaviour
{
    public List<Color> colors = new List<Color>();

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
        if (other.CompareTag("LoadableObject"))
        {
            //GameObject points = Instantiate(floatingScore, transform.position, Quaternion.identity);
            //points.transform.GetChild(0).GetComponent<TextMeshPro>().text = scoreValue.ToString();
            //ss.score += scoreValue;
            ShowScoreText(scoreValue);

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

    public void ShowScoreText(int score)
    {
        TextMeshPro text = floatingScore.transform.GetChild(0).GetComponent<TextMeshPro>();

        int randomNumber = Random.Range(0, colors.Count);

        text.color = new Color(colors[randomNumber].r, colors[randomNumber].g, colors[randomNumber].b, 1);

        GameObject points = Instantiate(floatingScore, transform.position, Quaternion.identity);
        points.transform.GetChild(0).GetComponent<TextMeshPro>().text = score.ToString();
        ss.score += score;
        Destroy(points, 2f);
    }

}

