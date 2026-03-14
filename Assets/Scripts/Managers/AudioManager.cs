using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sounds
{
    public AudioClip sound;
    public string soundName;

}


public class AudioManager : MonoBehaviour
{
    [SerializeField] Sounds[] soundsList;
    [SerializeField] AudioSource sfxSource, walkSfx;
    public static AudioManager instance;

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

    public void PlaySFX(string sfxName)
    {
        foreach(Sounds soundToSet in soundsList)
        {
            if(soundToSet.soundName == sfxName)
            {
                sfxSource.clip = soundToSet.sound;
                sfxSource.Play();
            }
        }
    }

    public void StopSFX()
    {
        sfxSource.Stop();
    }

    public void PlayWalk()
    {
        walkSfx.Play();
    }

    public void StopWalk()
    {
        walkSfx.Stop();
    }
}
