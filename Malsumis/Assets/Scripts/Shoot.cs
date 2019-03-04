using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bullet;
    public float fireRate;

    private float fireCooldown;
 
    public void ShootBullet(Transform spawnPoint)
    {
        if (Time.time > fireCooldown)
        {
            //This makes bullet sounds when shooting.
            SoundManagerScript.PlaySound("Bullet");
            fireCooldown = Time.time + fireRate;
            Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);
        }
    }

    public void Fireball(Transform spawnPoint)
    {
        if (Time.time > fireCooldown)
        {
            //This makes fireball sounds when activated.
            SoundManagerScript.PlaySound("Fireball");
            fireCooldown = Time.time + fireRate;
            Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);
            Instantiate(bullet, spawnPoint.position, spawnPoint.rotation * Quaternion.Euler(0f, 0f, 15f));
            Instantiate(bullet, spawnPoint.position, spawnPoint.rotation * Quaternion.Euler(0f, 0f, -15f));
        }
    }


}
