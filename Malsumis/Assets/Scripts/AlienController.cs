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
    public Transform dashPoint;
    public GameObject dashCollider;

    public float speed;

    public int dashCounter;
    public int fireballCounter;
    public float dashRate;
    public float fireRate;
    private float dashCooldown;
    private float fireCooldown;

    private bool dashing;
    //private bool fireballActive;
    public Image dashIndicator;
    public Image fireballIndicator;

    public bool conceptControls;
    private KeyCode dashKey;
    private KeyCode fireballKey;

    //public int killCount;

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
        if (dashing)
        {
            dashPoint.transform.position = new Vector3(dashPoint.position.x, transform.position.y, transform.position.z);
            movementScript.MoveToPoint(dashPoint, speed * 4);
            if (transform.position == dashPoint.position)
            {
                dashing = false;
                dashCollider.gameObject.SetActive(false);
            }
        }
        else
        {
            movementScript.MoveToPoint(alienPoint, speed);
        }

        if (dashCounter > 0)
        {
            if (Input.GetKey(dashKey) && Time.time > dashCooldown)
            {
                Dash();
            }
            if (Time.time > dashCooldown)
            {
                dashIndicator.gameObject.SetActive(true);
            }
        }

        if (fireballCounter > 0)
        {
            if (Input.GetKey(fireballKey) && Time.time > fireCooldown)
            {
                Fireball();
            }
            if (Time.time > fireCooldown)
            {
                fireballIndicator.gameObject.SetActive(true);
            }
        }
    }

    void Dash()
    {
        dashCollider.gameObject.SetActive(true);
        dashCooldown = Time.time + dashRate;
        dashIndicator.gameObject.SetActive(false);
        dashCounter--;
        dashing = true;
    }

    void Fireball()
    {
        fireCooldown = Time.time + fireRate;
        fireballIndicator.gameObject.SetActive(false);
        fireballCounter--;
        shootingScript.Fireball(spawnPoint);
    }

}
