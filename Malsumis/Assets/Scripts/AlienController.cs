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

    public float dashRate;
    public float fireRate;
    private float dashCooldown;
    private float fireCooldown;

    private bool dashActive;
    private bool fireballActive;
    public Image dashIndicator;
    public Image fireballIndicator;

    public bool conceptControls;
    private KeyCode dashKey;
    private KeyCode fireballKey;

    void Start()
    {
        movementScript = GetComponent<Movement>();
        shootingScript = GetComponent<Shoot>();
        if (conceptControls)
        {
            dashKey = KeyCode.Q;
            fireballKey = KeyCode.E;
        }
        else
        {
            dashKey = KeyCode.O;
            fireballKey = KeyCode.P;
        }

    }

    void Update()
    {
        movementScript.MoveToPoint(alienPoint);

        if (Input.GetKey(dashKey) && Time.time > dashCooldown)
        {
            dashCooldown = Time.time + dashRate;
            Dash();
        }
        if (Input.GetKey(fireballKey) && Time.time > fireCooldown)
        {
            fireCooldown = Time.time + fireRate;
            Fireball();
        }

        if (Time.time > dashCooldown && !dashActive)
        {
            dashIndicator.gameObject.SetActive(true);
        }
        if (Time.time > fireCooldown && !fireballActive)
        {
            fireballIndicator.gameObject.SetActive(true);
        }
    }

    void Dash()
    {
        dashIndicator.gameObject.SetActive(false);
        shootingScript.Dash(spawnPoint);
    }

    void Fireball()
    {
        fireballIndicator.gameObject.SetActive(false);
        shootingScript.Fireball(spawnPoint);
    }

}
