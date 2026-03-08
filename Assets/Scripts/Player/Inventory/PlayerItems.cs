using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItems : MonoBehaviour
{
    public static PlayerItems instance;
    int woodCount;
    int rawFish;
    int cookedFish;
    int carrot;
    int seeds;

    void Awake()
    {
        if(instance != null)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    public void ChangeWoodAmount(int value)
    {
        woodCount += value;
    }

    public int GetWoodCount()
    {
        return woodCount;
    }

    public void ChangeFishAmount(int value)
    {
        rawFish += value;
    }

    public int GetFishCount()
    {
        return rawFish;
    }

    public void ChangeCookedFishAmount(int value)
    {
        cookedFish += value;
    }

    public int GetSeedCount()
    {
        return seeds;
    }

    public void ChangeSeedAmount(int value)
    {
        seeds += value;
    }

    public void ChangeCarrotAmount(int value)
    {
        carrot += value;
    }

}
