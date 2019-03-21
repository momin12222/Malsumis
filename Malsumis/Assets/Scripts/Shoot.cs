using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bullet;
    public float fireRate;
    public int bulletNumber;
    public float bulletDelay;

    private float fireCooldown;
 
    public void ShootBullet(Transform spawnPoint)
    {
        if (Time.time > fireCooldown)
        {              
            fireCooldown = Time.time + fireRate;
            StartCoroutine(TrippleShot(spawnPoint, bulletNumber, bulletDelay));
        }
    }

    public void Fireball(Transform spawnPoint)
    {
        if (Time.time > fireCooldown)
        {
            fireCooldown = Time.time + fireRate;
            Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);
            Instantiate(bullet, spawnPoint.position, spawnPoint.rotation * Quaternion.Euler(0f, 0f, 15f));
            Instantiate(bullet, spawnPoint.position, spawnPoint.rotation * Quaternion.Euler(0f, 0f, -15f));
        }
    }

    IEnumerator TrippleShot(Transform spawnPoint, int count, float bulletDelay)
    {
        for (int i = 0; i < count; i++)
        {
            yield return new WaitForSeconds(bulletDelay);
            Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);
        }
    }
}
