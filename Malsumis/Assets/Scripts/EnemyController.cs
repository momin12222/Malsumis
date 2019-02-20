using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Movement movementScript;
    Health healthScript; 
    Shoot shootingScript;
    AlienController alienScript;
    public Transform spawnPoint;
    public float speed;

    void Start()
    {
        movementScript = GetComponent<Movement>();
        healthScript = GetComponent<Health>();
        shootingScript = GetComponent<Shoot>();
    }

    void Update()
    {
        movementScript.MoveForward(speed);
        shootingScript.ShootBullet(spawnPoint);
        if (transform.position.x < -20)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "PlayerBullet")
        {
            healthScript.TakeDemange(2);
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
