using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HungerCounter : Counter
{
    public void AddHunger(float foodAmount)
    {
        currCount += foodAmount;
    }
}
