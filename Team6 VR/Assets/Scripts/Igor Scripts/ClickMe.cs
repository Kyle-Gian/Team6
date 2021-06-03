using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickMe : MonoBehaviour
{
    public int pointsToGivePlayer;
    public string textToShow;

    public void OnMouseDown()
    {
        SpawnText();
    }

    public void SpawnText()
    {
        GameObject pointsText = Instantiate(Resources.Load("Prefabs/TextOnSpot")) as GameObject;

        if(pointsText.GetComponent<TextOnSpot>() != null)
        {
            var givePointsText = pointsText.GetComponent<TextOnSpot>();
            givePointsText.displayPoints = pointsToGivePlayer;
            givePointsText.displayText = textToShow;

        }
        pointsText.transform.position = gameObject.transform.position;

    }

}
