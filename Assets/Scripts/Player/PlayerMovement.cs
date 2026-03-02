using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveVel;
    Rigidbody2D rb;
    PlayerInput playerInput;
    Vector2 moveVector;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerInput = new PlayerInput();
    }

    void Update()
    {
        moveVector = playerInput.Player.Move.ReadValue<Vector2>();
        Debug.Log(playerInput.Player.Move.ReadValue<Vector2>());
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(moveVector.x * moveVel, moveVector.y * moveVel);
    }

    void OnEnable()
    {
        playerInput.Enable();
    }

    void OnDisable()
    {
        playerInput.Disable();
    }
}
