using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementScriptBlue : MonoBehaviour
{
    public float movementSpeed = 10f;
    private Rigidbody2D rb;
    private PlayerControlsBlue playerControls;
    private Vector2 moveDirection;
    private InputAction move;

    private void Awake()
    {
        playerControls = new PlayerControlsBlue();
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        moveDirection = playerControls.Player.MoveBlue.ReadValue<Vector2>();
        rb.velocity = moveDirection * movementSpeed;
    }
    private void OnEnable()
    {
        move = playerControls.Player.MoveBlue;
        move.Enable();

    }
    public void DisableMovement()
    {
        move.Disable();
    }
}
