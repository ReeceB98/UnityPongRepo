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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        // Getting key components in game object
        rb2d = GetComponent<Rigidbody2D>();

        // Set up player inputs
        moveAction = InputSystem.actions.FindAction("Move");
    }

    private void FixedUpdate()
    {
        // Read Move value as vector2 and apply rb2d velocity to make player move
        moveValue = moveAction.ReadValue<Vector2>();
        rb2d.linearVelocity = moveValue * playerSpeed;
    }
}
