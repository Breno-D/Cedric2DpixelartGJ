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
        playerControls.DisablePlayerControls();
        AudioManager.instance.PlaySFX("fish");
        PlayerAnimation.instance.SetAnimBool("fishing", true);
        
        yield return new WaitForSeconds(5f);

        PlayerItems.instance.ChangeFishAmount(1);
        AudioManager.instance.StopSFX();
        PlayerAnimation.instance.SetAnimBool("fishing", false);
        playerControls.EnablePlayerControls();
    }
}
