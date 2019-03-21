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
        BulletSound = Resources.Load<AudioClip>("Bullet");
        DashSound = Resources.Load<AudioClip>("Dash");
        FireballSound = Resources.Load<AudioClip>("Fireball");
        GSPSound = Resources.Load<AudioClip>("GSP");
        audioSrc = GetComponent<AudioSource>();
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "Fireball":
                audioSrc.PlayOneShot(FireballSound);
                break;
            case "Dash":
                audioSrc.PlayOneShot(DashSound);
                break;
            case "GSP":
                audioSrc.PlayOneShot(GSPSound);
                break;
            case "Hit":
                audioSrc.PlayOneShot(HitSound);
                break;
            default:
                print("no sound loaded");
                    break;
        }
    }
}
