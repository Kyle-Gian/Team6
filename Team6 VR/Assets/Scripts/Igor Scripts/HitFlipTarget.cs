using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitFlipTarget : MonoBehaviour
{
    Animator anim;
    public bool knockedDown = false;
    public int hit = 0;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInParent<Animator>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.CompareTag("LoadableObject"))
        {
            if (!knockedDown)
            {
                knockedDown = true;
                anim.SetBool("FlippedUp", false);
                anim.SetBool("knockedDown", true);
                hit++;
                //AreAllTargetsKnocked.Invoke();
            }
            else
            {
                hit++;

                knockedDown = false;
                anim.SetBool("FlippedUp", true);
                anim.SetBool("knockedDown", false);

            }
        }
        Debug.Log(hit);
    }
}
