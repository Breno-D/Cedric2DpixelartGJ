using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    PlayerInputActions playerInputActions;
    UnityEvent interactEvent;

    void Awake()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Interact.performed += ctx => InteractFunc();
        interactEvent = new UnityEvent();
    }

    void InteractFunc()
    {
        interactEvent.Invoke();
    }

    public UnityEvent GetInteractEvent()
    {
        return interactEvent;
    }

    public Vector2 GetMoveValue()
    {
        return playerInputActions.Player.Move.ReadValue<Vector2>();
    }
    void OnEnable()
    {
        playerInputActions.Enable();
    }

    void OnDisable()
    {
        playerInputActions.Disable();
    }
}
