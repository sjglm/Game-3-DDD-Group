using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementScriptRed : MonoBehaviour
{
    public float movementSpeed = 10f;
    private Rigidbody2D rb;
    private PlayerControlsRed playerControls;
    private Vector2 moveDirection;
    private InputAction move;

    private void Awake()
    {
        playerControls = new PlayerControlsRed();
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        moveDirection = playerControls.Player.MoveRed.ReadValue<Vector2>();
        rb.velocity = moveDirection * movementSpeed;
    }
    private void OnEnable()
    {
        move = playerControls.Player.MoveRed;
        move.Enable();

    }
    private void OnDisable()
    {
        move.Disable();
    }
}
