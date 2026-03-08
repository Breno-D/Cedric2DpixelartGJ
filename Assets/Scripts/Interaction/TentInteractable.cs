using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentInteractable : InteractableObject
{
    public override void Interact()
    {
        StartCoroutine(PlayerSleep());
    }

    private IEnumerator PlayerSleep()
    {
        yield return null;
        // create player tiredness first
        // player rest X amount or gt full
        // change day
    }
}
