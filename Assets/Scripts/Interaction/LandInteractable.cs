using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandInteractable : InteractableObject
{
    bool cropGrowing, cropFinished;
    public override void Interact()
    {
        if(cropGrowing)
        {
            if(cropFinished)
            {
                cropGrowing = false;
                cropFinished = false;
                int amountCarrotChange = Random.Range(1, 4);
                PlayerItems.instance.ChangeCarrotAmount(amountCarrotChange);
            }
        }
        else
        {
            if(PlayerItems.instance.GetSeedCount() > 0)
            {
                StartCoroutine(PlayerPlant());
            }
            else
            {
                StartCoroutine(PlayerSearchSeeds());
            }
        }
    }

    private IEnumerator PlayerPlant()
    {
        yield return new WaitForSeconds(5f);
        PlayerItems.instance.ChangeSeedAmount(-1);
        StartCoroutine(CropGrowth());
    }

    private IEnumerator PlayerSearchSeeds()
    {
        yield return new WaitForSeconds(5f);
        PlayerItems.instance.ChangeSeedAmount(1);
    }

    private IEnumerator CropGrowth()
    {
        cropGrowing = true;
        cropFinished = false;
        yield return new WaitForSeconds(120f);
        // change crop img to 2nd
        yield return new WaitForSeconds(120f);
        // change crop img to 3rd
        cropFinished = true;
    }
}
