//Author Igor Doslov
//created: 10/6/2021
//Last Modified: 17/6/2021

using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RingScore : MonoBehaviour
{
    public List<Color> colors = new List<Color>();
    public AudioClip impact;
    AudioSource audioSource;
    ScoreScreen ss;
    public GameObject floatingScore;
    public int scoreValue;
    public bool _RingActive = false;

    RingsActivated _ringsChallenge;
    CheckRingsAreActive _ringCheck;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        ss = FindObjectOfType<ScoreScreen>();
        _ringsChallenge = FindObjectOfType<RingsActivated>();
        _ringCheck = FindObjectOfType<CheckRingsAreActive>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("LoadableObject"))
        {
            audioSource.PlayOneShot(impact);

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

    // Instantiates score text at hit location
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

