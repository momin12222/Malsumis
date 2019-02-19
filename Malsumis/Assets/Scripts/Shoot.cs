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

    public void Dash(Transform spawnPoint)
    {
        //do the dash

        //move forward and activate collider 
    }

    public void Fireball(Transform spawnPoint)
    {
        //make it happen few times
        ShootBullet(spawnPoint);
    }


}
