using UnityEngine;

public class Ball : MonoBehaviour
{
    // Balls rigidbody
    private Rigidbody2D rb2d;

    // Ball speed
    [SerializeField] private float ballSpeed;

    // Ball direction using vectors
    private Vector2 moveValue;

    // Indicates if the player took a shot at the ball
    [SerializeField] private bool isPlayerShot = false;
    [SerializeField] private bool isCompShot = false;


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
        // Detects if the ball hits either barrier in the game
        BarrierCollisionDetection(collision);

        // Detects if the ball hits the surface area of the player
        PlayerCollisionDetection(collision);
    }

    public void CurrentMoveValue(float x, float y)
    {
        moveValue = new Vector2(x, y);
    }

    private void BallVelocity()
    {
        rb2d.linearVelocity = ballSpeed * Time.fixedDeltaTime * moveValue;
    }

    private void BarrierCollisionDetection(Collision2D collision)
    {
        // Ball hits the top barrier
        if (collision.gameObject.name == "TopBarrier" && isPlayerShot)
        {
            //isPlayerShot = false;
            CurrentMoveValue(1.0f, -1.0f);
        }

        if (collision.gameObject.name == "TopBarrier" && isCompShot)
        {
            //isCompShot = false;
            CurrentMoveValue(-1.0f, -1.0f);
        }

        // Ball hits bottom barrier
        if (collision.gameObject.name == "BottomBarrier" && isPlayerShot)
        {
            //isPlayerShot = false;
            CurrentMoveValue(1.0f, 1.0f);
        }

        if (collision.gameObject.name == "BottomBarrier" && isCompShot)
        {
            //isCompShot = false;
            CurrentMoveValue(-1.0f, 1.0f);
        }
    }

    private void PlayerCollisionDetection(Collision2D collision)
    {
        Vector2 ballPos = this.transform.position;
        Vector2 playerPos = collision.transform.position;

        // Calculates the direction the ball will go when colliding with the player
        float directionY = (ballPos.y - playerPos.y) / collision.gameObject.GetComponent<Collider2D>().bounds.size.y;

        // Ball will go upwards
        if (collision.gameObject.CompareTag("Player") && directionY < 0.0f /*&& playerPos.x < 0.0f*/)
        {
            Debug.Log("Player Collision");
            isPlayerShot = true;
            isCompShot = false;
            CurrentMoveValue(1.0f, -1.0f);
        }

        if (collision.gameObject.CompareTag("Computer") && directionY < 0.0f /*&& ballPos.x > 0.0f*/)
        {
            Debug.Log("Computer Collision");
            CurrentMoveValue(-1.0f, -1.0f);
            isPlayerShot = false;
            isCompShot = true;
        }

        // Ball will either slighly go up or down
        if (directionY == 0.0f)
        {
            Debug.Log("Player Collision");
            CurrentMoveValue(1.0f, -0.25f);
        }

        // Ball will go downwards
        if (collision.gameObject.CompareTag("Player") && directionY > 0.0f /*&& playerPos.x < 0.0f*/)
        {
            Debug.Log("Player Collision");
            isPlayerShot = true;
            isCompShot = false;
            CurrentMoveValue(1.0f, 1.0f);
        }

        if (collision.gameObject.CompareTag("Computer") && directionY > 0.0f /*&& ballPos.x > 0.0f*/)
        {
            Debug.Log("Computer Collision");
            CurrentMoveValue(-1.0f, 1.0f);
            isPlayerShot = false;
            isCompShot = true;
        }
    }
}
