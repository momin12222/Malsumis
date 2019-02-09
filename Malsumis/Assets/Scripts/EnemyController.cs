using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Movement movementScript;
    Health healthScript; 
    Shoot shootingScript;
    public Transform spawnPoint;

    void Start()
    {
        movementScript = GetComponent<Movement>();
        healthScript = GetComponent<Health>();
        shootingScript = GetComponent<Shoot>();
    }

    void Update()
    {
        movementScript.MoveForward();
        shootingScript.ShootBullet(spawnPoint);
        if (transform.position.x < -20)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "PlayerBullet")
        {
            healthScript.TakeDemange(2);
        }
    }
}
