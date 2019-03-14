using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Movement movementScript;
    Health healthScript; 
    Shoot shootingScript;
    public Transform spawnPoint;
    public float speed;
    public float amplitude;

    void Start()
    {
        movementScript = GetComponent<Movement>();
        healthScript = GetComponent<Health>();
        shootingScript = GetComponent<Shoot>();
    }

    void Update()
    {
        movementScript.MoveForward(speed, amplitude, true);
        shootingScript.ShootBullet(spawnPoint);
        if (transform.position.x < -20)
        {
            if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().killCount >= 1)
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().killCount--;
            }
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "PlayerBullet")
        {
            healthScript.TakeDemange(1);
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Fireball")
        {
            healthScript.TakeDemange(healthScript.currentHP);
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Dash")
        {
            healthScript.TakeDemange(healthScript.currentHP);
        }
    }

    
}
