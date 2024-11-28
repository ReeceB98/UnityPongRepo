using UnityEngine;

public class Ball : MonoBehaviour
{
    // Balls rigidbody
    private Rigidbody2D rb2d;

    // Ball speed
    [SerializeField] private float ballSpeed;

    // Ball direction using vectors
    private Vector2 moveValue;



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
}
