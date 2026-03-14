using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using TMPro;

public class DayManager : MonoBehaviour
{
    [SerializeField] Color dayColor, nightColor;
    [SerializeField] Light2D lightObject;
    [SerializeField] float dayTimer;
    [SerializeField] TextMeshProUGUI dayCounterText;
    FireInteractable fireInter;
    float time;
    int daysPassed;
    float target;
    bool isDay = true;
    float dayCounter;

    void Awake()
    {
        time = dayTimer/2f;
        dayCounter = 1;
    }

    void Start()
    {
        fireInter = FindObjectOfType<FireInteractable>();
    }

    void Update()
    {
        if(isDay)
        {
            DayCycle();
        }
        else
        {
            NightCycle();
        }
    }

    private void DayCycle()
    {
        LerpColors(dayColor, nightColor);
        LerpIntensity(1f, 0.4f);
    }

    void NightCycle()
    {
        LerpColors(nightColor, dayColor);
        LerpIntensity(0.4f, 1f);
        
    }

    void LerpColors(Color currColor, Color targetColor)
    {
        target += Time.deltaTime/time;
        lightObject.color = Color.Lerp(currColor, targetColor, target);
        if(target >= 1f)
        {
            dayCounter += 0.5f;  //convert to int when showing
            isDay = !isDay;
            target = 0f;
            UpdateDayCounter();
        }
    }

    void LerpIntensity(float currIntensity, float targetIntensity)
    {
        lightObject.intensity = Mathf.Lerp(currIntensity, targetIntensity, target);
        if(currIntensity < 0.7)
        {
            fireInter.SetNightFire();
        }
        else
        {
            fireInter.SetDayFire();
        }
    }

    public void SleepOneDay()
    {
        dayCounter += 1;
        UpdateDayCounter();
        lightObject.color = dayColor;
        lightObject.intensity = 1f;
        isDay = true;
    }

    void UpdateDayCounter()
    {
        int currentDay = (int)dayCounter;
        dayCounterText.text = "Dia "+currentDay;
    }

}
