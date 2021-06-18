//Author Kyle Gian
//created: 6/6/2021
//Last Modified: 6/6/2021
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ClipBoard : MonoBehaviour
{
    [SerializeField] GameObject _paperText;
    [SerializeField] List<Challenges> _challenges = new List<Challenges>();
    public UnityEvent _clipboardComplete;

    private void OnEnable()
    {
        if (_challenges.Count != _paperText.transform.childCount)
        {
            Debug.Log($"Challenge Missing. Found {_paperText.transform.childCount}, but {_challenges.Count} attached in List");
        }
    }

    public void CheckAllChallengesComplete()
    {
        for (int i = 0; i < _challenges.Count; i++)
        {
            if (!_challenges[i]._challengeComplete)
            {
                break;
            }
            
            if (_challenges.Count == i)
            {
                UnlockNextClipBoard();
            }
        }
    }

    public void UnlockNextClipBoard()
    {
        _clipboardComplete.Invoke();
    }
        

}
