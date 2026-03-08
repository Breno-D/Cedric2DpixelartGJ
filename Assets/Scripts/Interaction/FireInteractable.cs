using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class FireInteractable : InteractableObject
{
    bool fireIsOn;
    [SerializeField] Light2D fireLight;

    public override void Interact()
    {
        if(fireIsOn)
        {
            StartCoroutine(PlayerCook());
        }
        else
        {
            StartCoroutine(PlayerFire());
        }
    }

    private IEnumerator PlayerFire()
    {
        yield return null;
        if(PlayerItems.instance.GetWoodCount() > 0)
        {
            fireIsOn = true;
            fireLight.gameObject.SetActive(true);
            Invoke("TurnOffFire", 120f);
        }
    }

    private IEnumerator PlayerCook()
    {
        yield return null;
        if(PlayerItems.instance.GetFishCount() > 0)
        {
            // visual/sound cue
            yield return new WaitForSeconds(5f);
            PlayerItems.instance.ChangeFishAmount(-1);
            PlayerItems.instance.ChangeCookedFishAmount(1);
        }
    }

    void TurnOffFire()
    {
        fireLight.gameObject.SetActive(false);
        fireIsOn = false;
    }
}
