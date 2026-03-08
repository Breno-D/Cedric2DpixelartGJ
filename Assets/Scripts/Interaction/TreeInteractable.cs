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
        // change animation to cutting tree
        // disable player movement
        // wait
        int woodToAdd = Random.Range(1, 4);
        PlayerItems.instance.ChangeWoodAmount(woodToAdd);
        yield return null;
    }
}
