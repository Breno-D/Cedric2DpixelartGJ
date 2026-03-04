using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : InteractableObject
{
    void Start()
    {
        
    }

    override public void Interact()
    {
        Debug.Log("Override Door");
    }
}
