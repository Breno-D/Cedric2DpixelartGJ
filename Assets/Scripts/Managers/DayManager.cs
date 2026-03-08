using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class DayManager : MonoBehaviour
{
    [SerializeField] Color dayColor, nightColor;
    [SerializeField] Light2D lightObject;
    [SerializeField] float dayTimer;
    float time;
    int daysPassed;
    float target;
    bool isDay = true;

    void Awake()
    {
        time = dayTimer/2f;
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
            isDay = !isDay;
            target = 0f;
        }
    }

    void LerpIntensity(float currIntensity, float targetIntensity)
    {
        lightObject.intensity = Mathf.Lerp(currIntensity, targetIntensity, target);
    }
}
