using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveVel;
    Rigidbody2D rb;
    Vector2 moveVector;
    PlayerInput playerInput;
    bool facingRight;
    bool walkSfxPlaying;

    void Awake()
    {
        walkSfxPlaying = false;
        facingRight = true;
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

        if((Vector2)rb.velocity != Vector2.zero)
        {
            if(!walkSfxPlaying)
            {
                AudioManager.instance.PlayWalk();
                walkSfxPlaying = true;
            }
        }
        else
        {
            AudioManager.instance.StopWalk();
            walkSfxPlaying = false;
        }

        if(moveVector.x < 0 && facingRight || moveVector.x > 0 && !facingRight) 
        {
            TurnPlayer();
        }
    }

    void TurnPlayer()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }
}
