using UnityEngine;
using UnityEngine.InputSystem;


public class Player : MonoBehaviour
{
    public float moveSpeed = 10;
    protected Vector3 moveVec = Vector3.zero; // movement speed of player
    protected Rigidbody rigidbody;			// reference to the rigidbody
    public GameObject projectile;
    public Transform gunEnd;
    //public bool firstHit = false;


    public delegate void ChangeEnemyColor(Color color);
    public event ChangeEnemyColor onEnemyHit;

    // Start is called before the first frame update
    void Awake()
    {
		rigidbody = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        UpdateWhenGrounded();
    }

    void UpdateWhenGrounded()
    {
        // 1 
        rigidbody.velocity = moveVec * moveSpeed;

        // 2
        if (moveVec != Vector3.zero)
        {
            transform.LookAt(this.transform.position + moveVec.normalized);
        }

        // 3
        //CheckShouldFall();
    }

    public void OnMove(InputValue input)
    {
        Vector2 inputVec = input.Get<Vector2>();

        moveVec = new Vector3(inputVec.x, 0, inputVec.y);
    }

    public void OnShoot()
    {
        //firstHit = false;
        Ray mouseRay = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        GameObject newGameObject = (GameObject)Instantiate(projectile, mouseRay.origin, Quaternion.identity);
        Rigidbody rb = newGameObject.GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.velocity = mouseRay.direction * moveSpeed;
        }

        if(onEnemyHit != null)
        {
            onEnemyHit(Color.red);
            Debug.Log("shoot");
        }
    }
}
