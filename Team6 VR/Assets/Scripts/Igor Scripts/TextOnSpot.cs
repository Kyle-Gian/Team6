using UnityEngine.UI;
using UnityEngine;

public class TextOnSpot : MonoBehaviour
{
    public string displayText;
    public int displayPoints;
    public Text textPrefab;
    public float speed;
    public float destroyAfter;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = destroyAfter;
        textPrefab = GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer < 0)
        {
            Destroy(gameObject);
        }

        if(displayPoints > 0)
        {
            textPrefab.text = "+" + displayPoints;
        }
        else if(displayText != null)
        {
            textPrefab.text = displayText;
        }

        if(speed > 0)
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime, Space.World);
        }
    }
}
