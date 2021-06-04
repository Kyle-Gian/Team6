using UnityEngine;
using TMPro;

public class HitLocation : MonoBehaviour
{
    public GameObject floatingScore;
    public float outer = 0f;
    public float middle = 0f;
    public float bullseye = 0f;
    public string outerScore = "100";
    public string middleScore = "200";
    public string bullseyeScore = "500";


    void OnCollisionEnter(Collision other)
    {
        //print("Points colliding: " + other.contacts.Length);
        print("First point that collided: " + other.contacts[0].point);
        float dis = Vector3.Distance(other.contacts[0].point, transform.position);
        Debug.Log(dis);

        if(dis > outer)
        {
            ShowScoreText(outerScore, other);
            Debug.Log("hit outer");
        }
        else if (dis > middle)
        {
            ShowScoreText(middleScore, other);

            Debug.Log("hit middle");

        }
        else if(dis > bullseye)
        {
            ShowScoreText(bullseyeScore, other);
            Debug.Log("bullseye");

        }
    }

    public void ShowScoreText(string score, Collision other)
    {
        GameObject points = Instantiate(floatingScore, other.contacts[0].point, Quaternion.identity);
        points.transform.GetChild(0).GetComponent<TextMeshPro>().text = score;
    }
}
