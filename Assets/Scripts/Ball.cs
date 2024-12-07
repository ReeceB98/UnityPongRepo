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
    private bool isPlayerShot = false;
    private bool isCompShot = false;

    // Directional values
    //private float up = Random.Range(0.3f, 1.0f), down = Random.Range(-0.3f, -1.0f), right = 1.0f, left = -1.0f;
    private float up, down, right, left;

    private float zero = 0.0f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        up = Random.Range(0.3f, 1.0f);
        down = Random.Range(-0.3f, -1.0f);
        right = 1.0f; 
        left = -1.0f;

        // Get all key components
        rb2d = GetComponent<Rigidbody2D>();

        //Initial ball movement at start
        CurrentMoveValue(left, zero);
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
        // Ball hits the top barrier when player takes the shot
        if (collision.gameObject.name == "TopBarrier" && isPlayerShot)
        {
            CurrentMoveValue(right, down);
        }

        // Ball hits the top barrier when computer takes the shot
        if (collision.gameObject.name == "TopBarrier" && isCompShot)
        {
            CurrentMoveValue(left, down);
        }

        // Ball hits bottom barrier when player takes the shot
        if (collision.gameObject.name == "BottomBarrier" && isPlayerShot)
        {
            CurrentMoveValue(right, up);
        }

        // Ball hits bottom barrier when computer takes the shot
        if (collision.gameObject.name == "BottomBarrier" && isCompShot)
        {
            CurrentMoveValue(left, up);
        }
    }

    private void PlayerCollisionDetection(Collision2D collision)
    {
        Vector2 ballPos = this.transform.position;
        Vector2 playerPos = collision.transform.position;

        // Calculates the direction the ball will go when colliding with the player
        float directionY = (ballPos.y - playerPos.y) / collision.gameObject.GetComponent<Collider2D>().bounds.size.y;

        // Ball will go upwards when player takes the shot
        if (collision.gameObject.CompareTag("Player") && directionY < zero)
        {
            isPlayerShot = true;
            isCompShot = false;
            CurrentMoveValue(right, down);
        }

        // Ball will go upwards when computer takes the shot
        if (collision.gameObject.CompareTag("Computer") && directionY < zero)
        {
            isPlayerShot = false;
            isCompShot = true;
            CurrentMoveValue(left, down);
        }

        // Ball will either slighly go up or down when player takes a shot
        if (collision.gameObject.CompareTag("Player") && directionY == zero)
        {
            CurrentMoveValue(right, -0.25f);
        }

        // Ball will either slighly go up or down when computer takes a shot
        if (collision.gameObject.CompareTag("Computer") && directionY == zero)
        {
            CurrentMoveValue(left, -0.25f);
        }

        // Ball will go downwards when player takes the shot
        if (collision.gameObject.CompareTag("Player") && directionY > zero)
        {
            isPlayerShot = true;
            isCompShot = false;
            CurrentMoveValue(right, up);
        }

        // Ball will go downwards when computer takes the shot
        if (collision.gameObject.CompareTag("Computer") && directionY > zero)
        {
            isPlayerShot = false;
            isCompShot = true;
            CurrentMoveValue(left, up);
        }
    }

    private float RandomisedValue(float min, float max)
    {
        return Random.Range(min, max);
    }
}
