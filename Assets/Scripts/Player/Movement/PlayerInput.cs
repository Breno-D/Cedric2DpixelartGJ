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
        playerInputActions.Player.Food1.performed += ctx => SelectFood(1);
        playerInputActions.Player.Food2.performed += ctx => SelectFood(2);
        playerInputActions.Player.Eat.performed += ctx => EatFood();
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

    void EatFood()
    {
        GetComponent<HungerCounter>().AddHunger(GetComponent<PlayerItems>().GetHungerHealAmount());
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
