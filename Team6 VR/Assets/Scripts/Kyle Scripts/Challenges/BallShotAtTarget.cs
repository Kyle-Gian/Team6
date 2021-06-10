//Author Kyle Gian
//created: 7/6/2021
//Last Modified: 7/6/2021
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallShotAtTarget : Challenges
{
    // Start is called before the first frame update
    void Start()
    {
        _challenge = "Shoot the ball at the Target";
    }


    void ChallengeIsCompleted()
    {
        _challengeComplete = true;
    }

}
