using UnityEngine;

public class AI : MonoBehaviour
{
    // ball transform
    private Transform ballTransform;

    // How fast the computer moves
    [SerializeField] private float aiSpeed;

    // Computer Rigidbody
    private Rigidbody2D rb2d;

    // Ball class
    private Ball ball;

    // Turn the AI on/off
    private bool isCompOn = true;

    private float zero = 0.0f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        // Get the components needed
        ball = GameObject.FindFirstObjectByType<Ball>();
        ballTransform = GameObject.Find("Ball").transform;
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (isCompOn)
        {
            // Computer speed
            float step = aiSpeed * Time.fixedDeltaTime;

            // Computer will go up towards the ball
            if (ballTransform.position.y > transform.position.y)
            {
                rb2d.linearVelocity = new Vector2(zero, step);
            }

            // Computer will go down towards the ball
            if (ballTransform.position.y < transform.position.y)
            {
                rb2d.linearVelocity = new Vector2(zero, -step);
            }
        }
    }
}
