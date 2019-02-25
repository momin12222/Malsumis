using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public Slider progressBar;

    void Start()
    {
        movementScript = GetComponent<Movement>();
        healthScript = GetComponent<Health>();
        shootingScript = GetComponent<Shoot>();
        //boudingSctipt = GetComponent<Bounds>();
        progressBar.value = killCount;
    }

    void Update()
    {
        movementScript.PlayerMovement(speed);
     
        if (Input.GetKey(KeyCode.Space))
        {
            shootingScript.ShootBullet(spawnPoint);
        }

        progressBar.value = killCount;
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
