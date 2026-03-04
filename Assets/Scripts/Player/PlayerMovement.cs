using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveVel;
    Rigidbody2D rb;
    Vector2 moveVector;
    PlayerInput playerInput;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();
    }

    void Update()
    {
        moveVector = playerInput.GetMoveValue();
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(moveVector.x * moveVel, moveVector.y * moveVel);
    }
}
