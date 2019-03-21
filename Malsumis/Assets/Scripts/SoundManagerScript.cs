using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip BulletSound, DashSound, FireballSound, HitSound, GSPSound;
    static AudioSource audioSrc;
  
    void Start()
    {
        HitSound = Resources.Load<AudioClip>("Hit");
        audioSrc = GetComponent<AudioSource>();
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "Hit":
                audioSrc.PlayOneShot(HitSound);
                break;
            default:
                print("no sound loaded");
                    break;
        }
    }
}
