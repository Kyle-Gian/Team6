using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class SmallTargetsKnocked : Challenges
{
    // Start is called before the first frame update
    void Start()
    {
        _text = GetComponent<TextMeshPro>();

        _challenge = "Knockdown All Small Targets";
        _text.text = _challenge;

    }

    void ChallengeIsCompleted()
    {
        _challengeComplete = true;
    }
}
