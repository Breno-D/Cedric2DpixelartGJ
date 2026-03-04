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
    }

    void InteractFunction()
    {
        interactionTrigger.Invoke();
    }
}
