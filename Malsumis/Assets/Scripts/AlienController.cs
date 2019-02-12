using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienController : MonoBehaviour
{
    Movement movementScript;
    Shoot shootingScript;
    public Transform alienPoint;
    public Transform spawnPoint;
    private float fireCooldown;

    void Start()
    {
        movementScript = GetComponent<Movement>();
        shootingScript = GetComponent<Shoot>();
    }

    void Update()
    {
        movementScript.MoveToPoint(alienPoint);
        if (Time.time > fireCooldown)
        {
            fireCooldown = Time.time + shootingScript.fireRate;
            shootingScript.ShootBullet(spawnPoint);
        }
    }
}
