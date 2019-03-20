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
                print("Fireball");
                audioSrc.PlayOneShot(FireballSound);
                break;
            case "Bullet":
                print("Bullet");
                audioSrc.PlayOneShot(BulletSound);
                audioSrc.pitch = 7f;
                audioSrc.volume = 0.05f;
                break;
            case "Dash":
                print("Dash");
                audioSrc.PlayOneShot(DashSound);
                break;
            case "GSP":
                audioSrc.PlayOneShot(GSPSound);
                print("GSP");
                break;
            case "Hit":
                print("Hit");
                audioSrc.PlayOneShot(HitSound);
                audioSrc.pitch = 6f;
                audioSrc.volume = 1.25f;
                break;
            default:
                print("no sound loaded");
                    break;
        }
    }
}
