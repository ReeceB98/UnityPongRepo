using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    // Player rigidbody2D
    [SerializeField] private Rigidbody2D rb2d;

    // Player Inputs
    private InputAction moveAction;

    // Player movement vector
    private Vector2 moveValue;

    // Players overall speed
    [SerializeField] private float playerSpeed;

    // Player Positions
    private float playerPosY = 4.0f;
    private float playerPosX = 7.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        // Getting key components in game object
        rb2d = GetComponent<Rigidbody2D>();

        // Set up player inputs
        moveAction = InputSystem.actions.FindAction("Move");
    }

    private void Update()
    {
        PlayerPosConstraints();
    }

    private void FixedUpdate()
    {
        // Read Move value as vector2 and apply rb2d velocity to make player move
        moveValue = moveAction.ReadValue<Vector2>();
        rb2d.linearVelocity = playerSpeed * Time.fixedDeltaTime * moveValue;
    }

    private void PlayerPosConstraints()
    {
        // Player cannot go higher than screen dimensions
        if (this.transform.position.y < -playerPosY)
        {
            this.transform.position = new Vector2(-playerPosX, -playerPosY);
        }

        // Player cannot go lower than screen dimensions
        if (this.transform.position.y > playerPosY)
        {
            this.transform.position = new Vector2(-playerPosX, playerPosY);
        }
    }
}
