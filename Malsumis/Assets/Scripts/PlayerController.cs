using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Movement movementScript;
    Health healthScript; 
    Shoot shootingScript;
    //Bounds boudingSctipt;
    public Transform spawnPoint;
    public float speed;
    public int killCount;

    public int enemyDmg;
    public int dashDmg;
    public int fireballDmg;

    void Start()
    {
        movementScript = GetComponent<Movement>();
        healthScript = GetComponent<Health>();
        shootingScript = GetComponent<Shoot>();
        //boudingSctipt = GetComponent<Bounds>();
    }

    void Update()
    {
        movementScript.PlayerMovement(speed);
     
        if (Input.GetKey(KeyCode.Space))
        {
            shootingScript.ShootBullet(spawnPoint);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "EnemyBullet")
        {
            healthScript.TakeDamageWithUpdate(enemyDmg);
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "BossFireball")
        {
            healthScript.TakeDamageWithUpdate(dashDmg);
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "BossDash")
        {
            healthScript.TakeDamageWithUpdate(fireballDmg);
            Destroy(other.gameObject);
        }
    }
}
