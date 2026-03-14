using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    PlayerInputActions playerInputActions;
    UnityEvent interactEvent;
    Animator playerAnim; 

    void Awake()
    {
        playerAnim = GetComponent<Animator>();
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Interact.performed += ctx => InteractFunc();
        playerInputActions.Player.Food1.performed += ctx => SelectFood(1);
        playerInputActions.Player.Food2.performed += ctx => SelectFood(2);
        interactEvent = new UnityEvent();
    }

    void InteractFunc()
    {
        interactEvent.Invoke();
    }

    void SelectFood(int foodSelected)
    {
        PlayerItems.instance.SelectFood(foodSelected);
    }

    public UnityEvent GetInteractEvent()
    {
        return interactEvent;
    }

    public Vector2 GetMoveValue()
    {
        Vector2 vectorToReturn = playerInputActions.Player.Move.ReadValue<Vector2>();
        if(vectorToReturn == Vector2.zero)
        {
            PlayerAnimation.instance.SetAnimBool("walking", false);
        }
        else
        {
            PlayerAnimation.instance.SetAnimBool("walking", true);
        }
        return vectorToReturn;
    }
    void OnEnable()
    {
        EnablePlayerControls();
    }

    void OnDisable()
    {
        DisablePlayerControls();
    }

    public void DisablePlayerControls()
    {
        playerInputActions.Disable();
    }

    public void EnablePlayerControls()
    {
        playerInputActions.Enable();
    }
}
