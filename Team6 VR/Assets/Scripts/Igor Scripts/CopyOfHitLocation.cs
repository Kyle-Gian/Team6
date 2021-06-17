using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class CopyOfHitLocation : MonoBehaviour
{
    public List<Color> colors = new List<Color>();

    public GameObject floatingScore;
    public float outer = 0f;
    public float middle = 0f;
    public float bullseye = 0f;
    [Space]
    public int outerScore = 100;
    public int middleScore = 200;
    public int bullseyeScore = 500;
    
    public static bool firstHit = false;
    ScoreScreen ss;
    [Space]
    public List<AudioClip> impacts = new List<AudioClip>();
    AudioSource audioSource;
    // Player player;
     
    private void Awake()
    {
        // player = FindObjectOfType<Player>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        FindObjectOfType<Player>().onEnemyHit += HitLocation_hitEvent;
        ss = FindObjectOfType<ScoreScreen>();
    }

    private void HitLocation_hitEvent()
    {
        firstHit = false;
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.transform.CompareTag("LoadableObject"))
        {
            // if (other.transform.GetComponent<Projectile>().nameOfFirstHitObject != transform.name/*player.firstHit == false*/)
            // {
            //player.firstHit = true;
            //print("Points colliding: " + other.contacts.Length);
            //print("First point that collided: " + other.contacts[0].point);
            //Debug.Log(dis);

            // GameObject points = Instantiate(floatingScore, other.contacts[0].point, Quaternion.identity);
            // points.transform.GetChild(0).GetComponent<TextMeshPro>().text = bullseyeScore;
            if (firstHit == false)
            {
                float dis = Vector3.Distance(other.contacts[0].point, transform.position);

                firstHit = true;
                if (dis > outer)
                {
                    ShowScoreText(outerScore, other);
                    PlaySound(0);
                    //Debug.Log("hit outer");
                }
                else if (dis > middle)
                {
                    ShowScoreText(middleScore, other);
                    PlaySound(1);

                    // Debug.Log("hit middle");

                }
                else if (dis > bullseye)
                {
                    ShowScoreText(bullseyeScore, other);
                    PlaySound(2);

                    //Debug.Log("bullseye");

                }
            }

            // }
        }
    }

    public void ShowScoreText(int score, Collision other)
    {
        TextMeshPro text = floatingScore.transform.GetChild(0).GetComponent<TextMeshPro>();

        int randomNumber = Random.Range(0, colors.Count);

        text.color = new Color(colors[randomNumber].r, colors[randomNumber].g, colors[randomNumber].b, 1);

        GameObject points = Instantiate(floatingScore, other.contacts[0].point, Quaternion.identity);
        points.transform.GetChild(0).GetComponent<TextMeshPro>().text = score.ToString();
        ss.score += score;
        Destroy(points, 2f);
    }

    public void PlaySound(int index)
    {
        audioSource.PlayOneShot(impacts[index]);
    }

}
