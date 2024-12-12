using UnityEngine;

public class AI : MonoBehaviour
{
    private Transform ballTransform;

    [SerializeField] private float aiSpeed;

    private Rigidbody2D rb2d;

    private Ball ball;

    private bool isCompOn = true;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ball = GameObject.FindFirstObjectByType<Ball>();
        ballTransform = GameObject.Find("Ball").transform;
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (isCompOn)
        {
            float step = aiSpeed * Time.fixedDeltaTime;

            if (ballTransform.position.y > transform.position.y)
            {
                rb2d.linearVelocity = new Vector2(0.0f, step);
            }

            if (ballTransform.position.y < transform.position.y)
            {
                rb2d.linearVelocity = new Vector2(0.0f, -step);
            }
        }
    }
}
