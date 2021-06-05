using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ClipBoard : MonoBehaviour
{
    [SerializeField] GameObject _paperText;
    [SerializeField] List<Challenges> _challenges = new List<Challenges>();

    private List<TextMeshPro> _textList = new List<TextMeshPro>();
    
    // Start is called before the first frame update
    void Start()
    {
        if (_paperText != null)
        {
           _textList = _paperText.GetComponentsInChildren<TextMeshPro>().ToList();
        }

        for (int i = 0; i < _textList.Count; i++)
        {
            _textList[i].text = _challenges[i]._challenge;

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
