using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb2d;

    private InputAction moveAction;

    private Vector2 moveValue;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
    }

    // Update is called once per frame
    private void Update()
    {
        moveValue = moveAction.ReadValue<Vector2>();
        Debug.Log(moveValue);
    }
}
