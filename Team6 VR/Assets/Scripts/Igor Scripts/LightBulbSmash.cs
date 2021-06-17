//Author Igor Doslov
//created: 17/6/2021
//Last Modified: 17/6/2021
using UnityEngine;

public class LightBulbSmash : MonoBehaviour
{
    public GameObject brokenBulb;

    // To destroy the whole bulb and replace with broken bulb
    public void SwapLightBulb()
    {
        Destroy(gameObject);
        Instantiate(brokenBulb, transform.position, Quaternion.identity);
    }
}
