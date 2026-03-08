using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PondInteractable : InteractableObject
{
    public override void Interact()
    {
        StartCoroutine(PlayerFish());
    }

    private IEnumerator PlayerFish()
    {
        yield return null;
        // disable player movement
        // change player animation to fishing
        yield return new WaitForSeconds(5f);
        PlayerItems.instance.ChangeFishAmount(1);
        // finish fishing animation
    }
}
