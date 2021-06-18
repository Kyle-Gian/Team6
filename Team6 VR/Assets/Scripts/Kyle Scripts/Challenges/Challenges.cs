using TMPro;
using UnityEngine;
using UnityEngine.Events;

//Base class used for all challenges
[System.Serializable]
public class Challenges : MonoBehaviour
{
    public string _challenge;
    public bool _challengeComplete;
    [HideInInspector] public  TextMeshPro _text;
    public UnityEvent ChallengeCompleted;
    private void OnEnable()
    {
        _challengeComplete = false;
        _text = GetComponent<TextMeshPro>();
        _text.text = _challenge;
    }
    public void ChallengeComplete()
    {
        _challengeComplete = true;
        ChallengeCompleted.Invoke();
    }
}
