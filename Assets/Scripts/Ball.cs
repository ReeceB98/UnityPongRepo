using UnityEngine;

public class Ball : MonoBehaviour
{
    // Balls rigidbody
    private Rigidbody2D rb2d;

    // Ball speed
    [SerializeField] private float ballSpeed;

    // Ball direction using vectors
    [SerializeField] private Vector2 moveValue;

    [SerializeField] private bool isPlayerShot = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        // Get all key components
        rb2d = GetComponent<Rigidbody2D>();

        //Initial ball movement at start
        CurrentMoveValue(-1.0f, 0.0f);
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        BallVelocity();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "TopBarrier" && isPlayerShot)
        {
            isPlayerShot = false;
            CurrentMoveValue(1.0f, -1.0f);
        }

        if (collision.gameObject.name == "BottomBarrier" && isPlayerShot)
        {
            isPlayerShot = false;
            CurrentMoveValue(1.0f, 1.0f);
        }

        float directionY = (this.transform.position.y - collision.transform.position.y) / collision.gameObject.GetComponent<Collider2D>().bounds.size.y;

        if (directionY < 0.0f)
        {
            isPlayerShot = true;
            CurrentMoveValue(1.0f, -1.0f);
        }

        if (directionY == 0.0f)
        {
            //Debug.Log("Hit the middle of player");
            CurrentMoveValue(1.0f, -0.25f);
        }

        if (directionY > 0.0f)
        {
            isPlayerShot = true;
            CurrentMoveValue(1.0f, 1.0f);
        }
    }

    public void CurrentMoveValue(float x, float y)
    {
        moveValue = new Vector2(x, y);
    }

    private void BallVelocity()
    {
        rb2d.linearVelocity = ballSpeed * Time.fixedDeltaTime * moveValue;
    }
}
