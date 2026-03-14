using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentInteractable : InteractableObject
{
    [SerializeField] SpriteRenderer sleepFade;
    SleepCounter sleepCounter;
    DayManager dayManager;
    FireInteractable fireInter;

    void Start()
    {
        base.Start();
        sleepCounter = FindObjectOfType<SleepCounter>();
        dayManager = FindObjectOfType<DayManager>();
        fireInter = FindObjectOfType<FireInteractable>();
    }

    public override void Interact()
    {
        StartCoroutine(PlayerSleep());
    }

    private IEnumerator PlayerSleep()
    {
        yield return null;
        playerControls.DisablePlayerControls();
        float timePassed = 0f;
        while(timePassed < 2f)
        {
            timePassed += Time.deltaTime;
            sleepFade.color = Color.Lerp(sleepFade.color, Color.black, (timePassed/2f));
            yield return null;
        }
        timePassed  = 0f;
        dayManager.SleepOneDay();
        while(timePassed < 2f)
        {
            timePassed += Time.deltaTime;
            Color clearBlack = Color.black;
            clearBlack.a = 0.1f;
            sleepFade.color = Color.Lerp(sleepFade.color, clearBlack, (timePassed/2f));
            yield return null;
        }
        sleepFade.color = Color.clear;
        playerControls.EnablePlayerControls();
        sleepCounter.PlayerSleep();
        fireInter.TurnOffFire();
        yield return null;
    }
}
