using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandInteractable : InteractableObject
{
    [SerializeField] bool cropGrowing, cropFinished;
    [SerializeField] Sprite landNoCrop, landSeeded, landCropGrowing, landCrop;
    SpriteRenderer mySprite;

    void Awake()
    {
        mySprite = GetComponent<SpriteRenderer>();
    }
    
    public override void Interact()
    {
        if(cropGrowing)
        {
            if(cropFinished)
            {
                StartCoroutine(GatherCrop());
            }
        }
        else if(PlayerItems.instance.GetSeedCount() > 0)
        {
            StartCoroutine(PlayerPlant());
        }
    }

    private IEnumerator GatherCrop()
    {
        PlayerAnimation.instance.SetAnimBool("farm", true);
        playerControls.DisablePlayerControls();
        AudioManager.instance.PlaySFX("land");

        yield return new WaitForSeconds(2f);
        
        PlayerAnimation.instance.SetAnimBool("farm", false);
        playerControls.EnablePlayerControls();
        AudioManager.instance.StopSFX();

        cropGrowing = false;
        cropFinished = false;

        int amountCarrotChange = Random.Range(1, 4);
        PlayerItems.instance.ChangeCarrotAmount(amountCarrotChange);

        int amountSeedChange = Random.Range(1,4);
        PlayerItems.instance.ChangeSeedAmount(amountSeedChange);

        interactText = "PLANT";
        UpdateInteractText();
        mySprite.sprite = landNoCrop;
    }

    private IEnumerator PlayerPlant()
    {
        PlayerItems.instance.ChangeSeedAmount(-1);
        mySprite.sprite = landSeeded;
        mySprite.color = new Color32(70, 65, 93, 255);
        PlayerAnimation.instance.SetAnimBool("farm", true);
        playerControls.DisablePlayerControls();
        AudioManager.instance.PlaySFX("land");
        yield return new WaitForSeconds(3f);
        PlayerAnimation.instance.SetAnimBool("farm", false);
        playerControls.EnablePlayerControls();
        AudioManager.instance.StopSFX();
        interactText = "HARVEST";
        UpdateInteractText();
        StartCoroutine(CropGrowth());
    }

    private IEnumerator CropGrowth()
    {
        cropGrowing = true;
        cropFinished = false;
        yield return new WaitForSeconds(120f);
        mySprite.color = Color.white;
        mySprite.sprite = landCropGrowing;
        yield return new WaitForSeconds(120f);
        mySprite.sprite = landCrop;
        cropFinished = true;
    }
}
