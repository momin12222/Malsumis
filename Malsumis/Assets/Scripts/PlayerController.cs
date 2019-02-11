using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Movement movementScript;
    Health healthScript; 
    Shoot shootingScript;
    Bounds boudingSctipt;
    public Transform spawnPoint;

    //public bool leftButtons;
    //just add buttons to pass in function

    void Start()
    {
        movementScript = GetComponent<Movement>();
        healthScript = GetComponent<Health>();
        shootingScript = GetComponent<Shoot>();
        boudingSctipt = GetComponent<Bounds>();
    }

    void Update()
    {
        movementScript.PlayerMovement();
        if (Input.GetKey(KeyCode.Space))
        {
            shootingScript.ShootBullet(spawnPoint);
        }
        //boudingSctipt.BoundObject();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "EnemyBullet")
        {
            healthScript.TakeDemange(2);
        }
    }
}
