using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip BulletSound, DashSound, FireballSound, HitSound;
    static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        HitSound = Resources.Load<AudioClip>("Hit");
        BulletSound = Resources.Load<AudioClip>("Bullet");
        DashSound = Resources.Load<AudioClip>("Dash");
        FireballSound = Resources.Load<AudioClip>("Fireball");

        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "Fireball":
                audioSrc.PlayOneShot(FireballSound);
                break;
            case "Bullet":
                audioSrc.PlayOneShot(BulletSound);
                break;
            case "Dash":
                audioSrc.PlayOneShot(DashSound);
                break;
            case "Hit":
                audioSrc.PlayOneShot(HitSound);
                break;
        }
    }
}
