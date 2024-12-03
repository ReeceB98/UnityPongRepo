using UnityEngine;

public class AI : MonoBehaviour
{
    [SerializeField] private Transform ballTransform;

    [SerializeField] private float aiSpeed;

    [SerializeField] private Rigidbody2D rb2d;

    private Ball ball;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ball = GameObject.FindFirstObjectByType<Ball>();
    }

    // Update is called once per frame
    private void Update()
    {
        //float step = aiSpeed * Time.deltaTime;
        //transform.position = Vector2.MoveTowards(rb2d.position, ballTransform.position, step);
    }

    private void FixedUpdate()
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Ball")
        {
            //Debug.Log("Computer Hit");
            //ball.moveValue = new Vector2(-1.0f, -1.0f);
            ball.CurrentMoveValue(-1.0f, -1.0f);
        }
    }
}
