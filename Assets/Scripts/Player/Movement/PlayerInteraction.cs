using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInteraction : MonoBehaviour
{
    public UnityEvent interactionTrigger;

    void Awake()
    {
        interactionTrigger = new UnityEvent();
    }

    void Start()
    {
        GetComponent<PlayerInput>().GetInteractEvent().AddListener(InteractFunction);
        AddEatListener();  
    }

    void InteractFunction()
    {
        interactionTrigger.Invoke();
    }

    public void AddEatListener()
    {
        interactionTrigger.AddListener(EatFood);  
    }

    public void RemoveEatListener()
    {
        interactionTrigger.RemoveListener(EatFood); 
    }
    
    void EatFood()
    {
        FindObjectOfType<HungerCounter>().AddHunger(GetComponent<PlayerItems>().GetHungerHealAmount());
    }
}
