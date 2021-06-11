//Author Kyle Gian
//created: 7/6/2021
//Last Modified: 7/6/2021
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class BallShotAtTarget : Challenges
{
    // Start is called before the first frame update
    void Start()
    {
        _text = GetComponent<TextMeshPro>();

        _challenge = "Shoot the ball at the Target";
        _text.text = _challenge;

    }


    void ChallengeIsCompleted()
    {
        _challengeComplete = true;
    }

}
