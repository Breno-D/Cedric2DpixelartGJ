using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class FireInteractable : InteractableObject
{
    bool fireIsOn;
    [SerializeField] Light2D fireLight;
    [SerializeField] float fireDuration;
    Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

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
            playerControls.DisablePlayerControls();
            AudioManager.instance.PlaySFX("fire");

            yield return new WaitForSeconds(2f);

            playerControls.EnablePlayerControls();
            AudioManager.instance.StopSFX();
            anim.SetTrigger("fire");
            fireIsOn = true;
            PlayerItems.instance.ChangeWoodAmount(-1);
            fireLight.gameObject.SetActive(true);
            Invoke("TurnOffFire", fireDuration);
            interactText = "COOK";
            UpdateInteractText();
        }
    }

    private IEnumerator PlayerCook()
    {
        yield return null;
        if(PlayerItems.instance.GetFishCount() > 0)
        {
            playerControls.DisablePlayerControls();
            AudioManager.instance.PlaySFX("cook");

            yield return new WaitForSeconds(3f);

            AudioManager.instance.StopSFX();
            playerControls.EnablePlayerControls();
            PlayerItems.instance.ChangeFishAmount(-1);
            PlayerItems.instance.ChangeCookedFishAmount(1);
        }
    }

    public void TurnOffFire()
    {
        if(fireIsOn)
        {
            interactText = "LIGHT";
            UpdateInteractText();
            fireLight.gameObject.SetActive(false);
            fireIsOn = false;
            anim.SetTrigger("fire");
        }
    }

    public void SetDayFire()
    {
        fireLight.GetComponent<Light2D>().intensity = 20;
    }

    public void SetNightFire()
    {
        fireLight.GetComponent<Light2D>().intensity = 50;
    }
}
