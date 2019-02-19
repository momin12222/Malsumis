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
            fireCooldown = Time.time + fireRate;
            Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);
        }
    }

    public void Fireball(Transform spawnPoint)
    {
        //make it happen few times?
        if (Time.time > fireCooldown)
        {
            fireCooldown = Time.time + fireRate;
            Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);
            Instantiate(bullet, spawnPoint.position, spawnPoint.rotation * Quaternion.Euler(0f, 0f, 15f));
            Instantiate(bullet, spawnPoint.position, spawnPoint.rotation * Quaternion.Euler(0f, 0f, -15f));
        }
    }


}
