using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    Animator playerAnim;
    public static PlayerAnimation instance;
    
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
        
        playerAnim = GetComponent<Animator>();    
    }

    public void SetAnimBool(string boolToSet, bool valueToSet)
    {
        playerAnim.SetBool(boolToSet, valueToSet);
    }
}
