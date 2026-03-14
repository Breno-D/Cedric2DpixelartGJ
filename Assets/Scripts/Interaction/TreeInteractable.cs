using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeInteractable : InteractableObject
{
    public override void Interact()
    {
        StartCoroutine(PlayerTree());
    }

    private IEnumerator PlayerTree()
    {
        yield return null;
        AudioManager.instance.PlaySFX("cut");
        PlayerAnimation.instance.SetAnimBool("cut", true);
        playerControls.DisablePlayerControls();

        yield return new WaitForSeconds(3f);

        AudioManager.instance.StopSFX();
        playerControls.EnablePlayerControls();
        PlayerAnimation.instance.SetAnimBool("cut", false);
        int woodToAdd = Random.Range(1, 4);
        PlayerItems.instance.ChangeWoodAmount(woodToAdd);
        yield return null;
    }
}
