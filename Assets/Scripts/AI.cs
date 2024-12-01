using UnityEngine;

public class AI : MonoBehaviour
{
    [SerializeField] private Transform ballTransform;

    [SerializeField] private float aiSpeed;

    [SerializeField] private Rigidbody2D rb2d;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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
}
