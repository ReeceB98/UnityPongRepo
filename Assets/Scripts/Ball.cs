using UnityEngine;

public class Ball : MonoBehaviour
{
    // Balls rigidbody
    private Rigidbody2D rb2d;

    // Ball speed
    [SerializeField] private float ballSpeed;

    // Ball direction using vectors
    private Vector2 moveValue;

    [SerializeField] private bool isPlayerShot = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        moveValue = new Vector2(-1.0f, 0.0f);
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        //moveValue = new Vector2(-1.0f, 0.0f);
        rb2d.linearVelocity = ballSpeed * Time.fixedDeltaTime * moveValue;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //Debug.Log("Collision Detected");
            moveValue = new Vector2(1.0f, -1.0f);
            isPlayerShot = true;
        }

        if (collision.gameObject.name == "TopBarrier" && isPlayerShot)
        {
            //Debug.Log("Collision Detected");
            moveValue = new Vector2(1.0f, -1.0f);
            isPlayerShot = false;
        }

        if (collision.gameObject.name == "BottomBarrier" && isPlayerShot)
        {
            moveValue = new Vector2(1.0f, 1.0f);
            isPlayerShot = false;
        }
        float directionX = (this.transform.position.y - collision.transform.position.y) / collision.gameObject.GetComponent<Collider2D>().bounds.size.y;
    }
}
