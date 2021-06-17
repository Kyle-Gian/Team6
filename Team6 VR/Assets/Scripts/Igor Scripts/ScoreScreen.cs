//Author Igor Doslov
//created: 9/6/2021
//Last Modified: 17/6/2021

using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class ScoreScreen : MonoBehaviour
{
    public int score = 0;
    public List<TextMeshPro> scoreText = new List<TextMeshPro>();

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponentsInChildren<TextMeshPro>().ToList();
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var s in scoreText)
        {
            s.text = score.ToString();

        }
    }
}
