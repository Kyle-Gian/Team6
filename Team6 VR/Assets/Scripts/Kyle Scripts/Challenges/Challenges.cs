using TMPro;
using UnityEngine;
using UnityEngine.Events;


[System.Serializable]
public class Challenges : MonoBehaviour
{
    public string _challenge;
    public bool _challengeComplete;
    private TextMeshPro _text;
    public UnityEvent ChallengeCompleted;
    private void Start()
    {
        _challengeComplete = false;
        _text.text = _challenge;
    }
    public void ChallengeComplete()
    {
        _challengeComplete = true;
        ChallengeCompleted.Invoke();
    }
}
