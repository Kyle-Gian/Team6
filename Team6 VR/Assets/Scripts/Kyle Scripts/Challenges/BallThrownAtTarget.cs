//Author Kyle Gian
//created: 7/6/2021
//Last Modified: 7/6/2021
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class BallThrownAtTarget : Challenges
{
    // Start is called before the first frame update
    void OnEnable()
    {
        _text = GetComponent<TextMeshPro>();

        _challenge = "Throw the ball at the Target";

        _text.text = _challenge;

    }

    void ChallengeIsCompleted()
    {
        _challengeComplete = true;
    }
}
