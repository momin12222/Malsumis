using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Movement movementScript;
    Health healthScript; 
    Shoot shootingScript;
    private Animator animator;

    public Transform spawnPoint;
    public float speed;
    private bool canIdle;

    public Slider progressBar;
    public float killCount;

    void Start()
    {
        Time.timeScale = 1f;
        movementScript = GetComponent<Movement>();
        healthScript = GetComponent<Health>();
        shootingScript = GetComponent<Shoot>();
        animator = GetComponent<Animator>();

        progressBar = GameObject.FindGameObjectWithTag("Slider").GetComponent<Slider>();

        canIdle = SceneManager.GetActiveScene().name == "BossLevel";
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
            healthScript.TakeDamageWithUpdate(1);
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "BossDash")
        {
            healthScript.TakeDamageWithUpdate(1);
        }
    }
}
