using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlienController : MonoBehaviour
{
    Movement movementScript;
    Shoot shootingScript;
    public Transform alienPoint;
    public Transform spawnPoint;
    public float fireRate;
    private float fireCooldown;

    public Image fireballIndicator;

    void Start()
    {
        movementScript = GetComponent<Movement>();
        shootingScript = GetComponent<Shoot>();
    }

    void Update()
    {
        movementScript.MoveToPoint(alienPoint);
        if (Input.GetKey(KeyCode.E) && Time.time > fireCooldown)
        {
            fireCooldown = Time.time + fireRate;
            shootingScript.ShootBullet(spawnPoint);
            fireballIndicator.gameObject.SetActive(false);
        }

        if (Time.time > fireCooldown)
        {
            fireballIndicator.gameObject.SetActive(true);
        }
    }
}
