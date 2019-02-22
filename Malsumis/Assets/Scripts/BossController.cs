﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossController : MonoBehaviour
{
    Movement movementScript;
    Health healthScript;
    Shoot shootingScript;
    public Transform spawnPoint;
    public Transform dashPoint;
    public Transform endPoint;
    public GameObject dashCollider;

    public float speed;
    private Transform startPos;

    public float dashRate;
    public float fireRate;
    private float dashCooldown;
    private float fireCooldown;

    private bool dashing;
    //private bool fireballActive;
    public Image dashIndicator;
    public Image fireballIndicator;

    // Start is called before the first frame update
    void Start()
    {
        movementScript = GetComponent<Movement>();
        healthScript = GetComponent<Health>();
        shootingScript = GetComponent<Shoot>();
    }

    // Update is called once per frame
    void Update()
    {
        if (dashing)
        {
            movementScript.MoveToPoint(dashPoint, speed);
            if (transform.position == dashPoint.position)
            {
                dashing = false;
                dashCollider.gameObject.SetActive(false);
            }
        }
        else
        {
            movementScript.MoveToPoint(endPoint, speed);
        }

        if (Time.time > dashCooldown)
        {
            Dash();
        }
        if (Time.time > dashCooldown)
        {
            dashIndicator.gameObject.SetActive(true);
        }

        if (Time.time > fireCooldown)
        {
            Fireball();
        }
        if (Time.time > fireCooldown)
        {
            fireballIndicator.gameObject.SetActive(true);
        }
    }

    void Dash()
    {
        dashing = true;
        dashPoint.transform.position = new Vector3(dashPoint.position.x, transform.position.y, transform.position.z);
        dashCollider.gameObject.SetActive(true);
        dashCooldown = Time.time + dashRate;
        dashIndicator.gameObject.SetActive(false);
    }

    void Fireball()
    {
        fireCooldown = Time.time + fireRate;
        fireballIndicator.gameObject.SetActive(false);
        shootingScript.Fireball(spawnPoint);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "PlayerBullet")
        {
            healthScript.TakeDemange(2);
            Destroy(other.gameObject);
            //load win screen
        }
    }

}
