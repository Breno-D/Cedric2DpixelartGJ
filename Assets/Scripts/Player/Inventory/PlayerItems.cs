using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerItems : MonoBehaviour
{
    public static PlayerItems instance;
    [SerializeField] TextMeshProUGUI woodText, rawFishText, cookedFishText, carrotText, seedsText;
    int woodCount;
    int rawFish;
    int cookedFish;
    int carrot;
    int seeds;
    int foodCurrSelected;
    [SerializeField] Image food1Outline, food2Outline;

    void Awake()
    {
        if(instance != null)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
            foodCurrSelected = 1;
        }
    }

    public void ChangeWoodAmount(int value)
    {
        woodCount += value;
        woodText.text = woodCount.ToString();
    }

    public int GetWoodCount()
    {
        return woodCount;
    }

    public void ChangeFishAmount(int value)
    {
        rawFish += value;
        rawFishText.text = rawFish.ToString();
    }

    public int GetFishCount()
    {
        return rawFish;
    }

    public void ChangeCookedFishAmount(int value)
    {
        cookedFish += value;
        cookedFishText.text = cookedFish.ToString();
    }

    public int GetSeedCount()
    {
        return seeds;
    }

    public void ChangeSeedAmount(int value)
    {
        seeds += value;
        seedsText.text = seeds.ToString();
    }

    public void ChangeCarrotAmount(int value)
    {
        carrot += value;
        carrotText.text = carrot.ToString();
    }

    public void SelectFood(int foodToSelect)
    {
        Color32 colorselected = new Color32(255, 105, 115, 255);
        foodCurrSelected = foodToSelect;
        if(foodToSelect == 1)
        {
            food1Outline.color = colorselected;
            food2Outline.color = Color.black;
        }
        else
        {
            food1Outline.color = Color.black;
            food2Outline.color = colorselected;
        }
    }

    public float GetHungerHealAmount()
    {
        if(foodCurrSelected == 1 && carrot > 0)
        {
            float hungerHealAmount = Random.Range(5f, 20f);
            ChangeCarrotAmount(-1);
            return hungerHealAmount;
        }
        else if(foodCurrSelected == 2 && cookedFish > 0)
        {
            float hungerHealAmount = Random.Range(25f, 50f);
            ChangeCookedFishAmount(-1);
            return hungerHealAmount;
        }
        else
        {
            return 0f;
        }
    }
}
