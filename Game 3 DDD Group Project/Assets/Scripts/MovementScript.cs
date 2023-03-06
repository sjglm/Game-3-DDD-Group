using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementScript : MonoBehaviour
{
    public float movementSpeed = 10f;
    private Rigidbody2D rb;
    private PlayerControls playerControls;
    private Vector2 moveDirection;
    private InputAction move;
    private InputAction fire;

    private void Awake()
    {
        playerControls = new PlayerControls();
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        moveDirection = playerControls.Player.Move.ReadValue<Vector2>();
        rb.velocity = moveDirection * movementSpeed;
    }
    private void OnEnable()
    {
        move = playerControls.Player.Move;
        move.Enable();

        fire = playerControls.Player.Fire;
        fire.Enable();
        fire.performed += Fire;
    }
    private void OnDisable()
    {
        move.Disable();
        fire.Disable();
    }
    private void Fire(InputAction.CallbackContext context)
    {
        Debug.Log("We fired");
    }
}
