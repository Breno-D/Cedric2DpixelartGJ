using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SleepCounter : Counter
{
    [SerializeField] int sleepHeal;

    public void PlayerSleep()
    {
        currCount += sleepHeal;
    }
}
