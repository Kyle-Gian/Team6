using UnityEngine;
using System.Collections.Generic;
using TMPro;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class HitLocation : MonoBehaviour
{
    public GameObject _leftHand;
    public GameObject _rightHand;
    public GameObject floatingScore;
    public float outer = 0f;
    public float middle = 0f;
    public float bullseye = 0f;
    public int outerScore = 100;
    public int middleScore = 200;
    public int bullseyeScore = 500;
    int hit = 0;
    public static bool firstHit = false;
    ScoreScreen ss;

    XRDirectInteractor _leftHandInteractor;
    XRDirectInteractor _rightHandInteractor;

    private void Awake()
    {
        ReloadWeapon reloadWeapon = FindObjectOfType<ReloadWeapon>();
        reloadWeapon.ObjectLoaded.AddListener(HitLocation_hitEvent);

        _leftHand = GameObject.FindGameObjectWithTag("left");
        _rightHand = GameObject.FindGameObjectWithTag("right");


        _leftHandInteractor = _leftHand.GetComponent<XRDirectInteractor>();
        _rightHandInteractor = _rightHand.GetComponent<XRDirectInteractor>();

        _leftHandInteractor.selectEntered.AddListener(HitLocation_hitEvent);
        _rightHandInteractor.selectEntered.AddListener(HitLocation_hitEvent);

    }

    private void Start()
    {
        //FindObjectOfType<Player>().onEnemyHit += HitLocation_hitEvent;

        ss = FindObjectOfType<ScoreScreen>();
    }

    public void HitLocation_hitEvent(SelectEnterEventArgs test)
    {
        firstHit = false;
    }
    public void HitLocation_hitEvent()
    {
        firstHit = false;
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.transform.CompareTag("Ball"))
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

                hit++;
                Debug.Log("Hit" + hit);
                firstHit = true;
                if (dis > outer)
                {
                    ShowScoreText(outerScore, other);
                    //Debug.Log("hit outer");
                }
                else if (dis > middle)
                {
                    ShowScoreText(middleScore, other);

                    // Debug.Log("hit middle");

                }
                else if (dis > bullseye)
                {
                    ShowScoreText(bullseyeScore, other);
                    //Debug.Log("bullseye");

                }
            }

            // }
        }
    }

    public void ShowScoreText(int score, Collision other)
    {
        GameObject points = Instantiate(floatingScore, other.contacts[0].point, Quaternion.identity);
        points.transform.GetChild(0).GetComponent<TextMeshPro>().text = score.ToString();
        ss.score += score;
    }

}
