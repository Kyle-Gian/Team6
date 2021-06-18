//Author Igor Doslov and Kyle Gian
//created: 29/5/2021
//Last Modified: 17/6/2021

using UnityEngine;
using TMPro;
using UnityEngine.XR.Interaction.Toolkit;
using System.Collections.Generic;

public class HitLocation : MonoBehaviour
{

    public GameObject floatingScore;
    // Size of score areas on target
    public float outer = 0f;
    public float middle = 0f;
    public float bullseye = 0f;
    [Space] // Scores per area on target
    public int outerScore = 100;
    public int middleScore = 200;
    public int bullseyeScore = 500;
    [Space]
    public List<AudioClip> sounds = new List<AudioClip>();

    public AudioSource audioSource;

    int hit = 0;
    public static bool firstHit = false;
    ScoreScreen ss;

    public GameObject _leftHand;
    public GameObject _rightHand;
    XRDirectInteractor _leftHandInteractor;
    XRDirectInteractor _rightHandInteractor;

    BallShotAtTarget _shootChallenge;
    BallThrownAtTarget _thrownChallenge;
    WeaponThrownAtTarget _weaponThrownChallenge;

    private void Start()
    {

        _shootChallenge = FindObjectOfType<BallShotAtTarget>();
        _thrownChallenge = FindObjectOfType<BallThrownAtTarget>();
        _weaponThrownChallenge = FindObjectOfType<WeaponThrownAtTarget>();

        ss = FindObjectOfType<ScoreScreen>();
        ReloadWeapon reloadWeapon = FindObjectOfType<ReloadWeapon>();
        reloadWeapon.ObjectLoaded.AddListener(HitLocation_hitEvent);
        
        ShootFromGun shootWeapon = FindObjectOfType<ShootFromGun>();
        shootWeapon.ObjectShotFromGun.AddListener(HitLocation_hitEvent);
        
        /*_leftHand = GameObject.FindWithTag("left");
        _rightHand = GameObject.FindWithTag("right");

        //If either the left or right hand are null throw an error for the user
        if (_leftHand != null)
        {
            //Get the left hand interactor and access the event
            _leftHandInteractor = _leftHand.GetComponent<XRDirectInteractor>();
            _leftHandInteractor.selectEntered.AddListener(HitLocation_hitEvent);

        }
        else
        {
            Debug.LogWarning("Left hand has not been attached, Check Tag on left hand controller");

        }
        if (_rightHand != null)
        {
            //Get the right hand interactor and access the event
            _rightHandInteractor = _rightHand.GetComponent<XRDirectInteractor>();
            _rightHandInteractor.selectEntered.AddListener(HitLocation_hitEvent);

        }
        else
        {
            Debug.LogWarning("Right hand has not been attached, Check Tag on Right hand controller");

        }*/
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
        if (other.transform.CompareTag("LoadableObject"))
        {
            //Check if the target is a pop up target due to knock down check
            if (transform.CompareTag("PopUpCollider"))
            {
                //check if the target has been knocked down before adding points
                if (!firstHit && GetComponent<SmallTargetKnockedDown>()._targetKnocked == false)
                {
                    float dis = Vector3.Distance(other.contacts[0].point, transform.position);

                    hit++;
                    Debug.Log("Hit" + hit);
                    firstHit = true; // For some reason oncollision enter gets called twice in this project so need this to ensure only one hit
                    if (dis > outer) // outer ring on target
                    {
                        ShowScoreText(outerScore, other);
                        PlaySound(0);

                    }
                    else if (dis > middle) // Middle ring on target
                    {
                        ShowScoreText(middleScore, other);
                        PlaySound(1);

                    }
                    else if (dis > bullseye) // bullseye area on target
                    {
                        ShowScoreText(bullseyeScore, other);
                        PlaySound(2);

                    }
                }
            }
            else
            {
                if (firstHit == false)
                {
                    float dis = Vector3.Distance(other.contacts[0].point, transform.position);

                    hit++;
                    Debug.Log("Hit" + hit);
                    firstHit = true;
                    if (dis > outer) // outer ring on target
                    {
                        ShowScoreText(outerScore, other);
                        PlaySound(0);

                    }
                    else if (dis > middle) // Middle ring on target
                    {
                        ShowScoreText(middleScore, other);
                        PlaySound(1);

                    }
                    else if (dis > bullseye) // bullseye area on target
                    {
                        ShowScoreText(bullseyeScore, other);
                        PlaySound(2);

                    }
                }
            }
            
        }

        if (transform.CompareTag("Main Target"))
        {
            //If both challenges have been completed skip this entire step
            if (!_thrownChallenge._challengeComplete || !_shootChallenge._challengeComplete || !_weaponThrownChallenge._challengeComplete)
            {
                if (other.transform.CompareTag("LoadableObject"))
                {
                    if (other.gameObject.GetComponent<Interactable>()._thrown)
                    {
                        _thrownChallenge.ChallengeComplete();
                    }
                    else
                    {
                        _shootChallenge.ChallengeComplete();
                    }
                }

            }
            if (other.transform.CompareTag("Gun"))
            {

                _weaponThrownChallenge.ChallengeComplete();
            }
        }
    }

    // Instantiates score text at hit location
    public void ShowScoreText(int score, Collision other)
    {
        GameObject points = Instantiate(floatingScore, other.contacts[0].point, Quaternion.identity);
        points.transform.GetChild(0).GetComponent<TextMeshPro>().text = score.ToString();
        ss.score += score;
    }

    // Play a sound
    public void PlaySound(int index)
    {
        audioSource.PlayOneShot(sounds[index]);
    }

}
