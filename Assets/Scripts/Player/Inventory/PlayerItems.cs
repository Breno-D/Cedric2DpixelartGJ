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
    int foodCurrSelected;

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

    public void SelectFood(int foodToSelect)
    {
        foodCurrSelected = foodToSelect;
    }

    public float GetHungerHealAmount()
    {
        if(foodCurrSelected == 1 && carrot > 0)
        {
            float hungerHealAmount = Random.Range(5f, 20f);
            carrot -= 1;
            return hungerHealAmount;
        }
        else if(foodCurrSelected == 2 && cookedFish > 0)
        {
            float hungerHealAmount = Random.Range(25f, 50f);
            cookedFish -= 1;
            return hungerHealAmount;
        }
        else
        {
            return 0f;
        }
    }
}
