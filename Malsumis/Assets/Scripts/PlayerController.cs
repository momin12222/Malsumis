using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    Movement movementScript;
    Health healthScript; 
    Shoot shootingScript;
    public Transform spawnPoint;
    public float speed;

    public Slider progressBar;
    public GameObject corruption;
    public float killCount;


    void Start()
    {
        Time.timeScale = 1f;
        movementScript = GetComponent<Movement>();
        healthScript = GetComponent<Health>();
        shootingScript = GetComponent<Shoot>();
        progressBar = GameObject.FindGameObjectWithTag("Slider").GetComponent<Slider>();
    }

    void Update()
    {
        movementScript.PlayerMovement(speed);
        if (Input.GetKey(KeyCode.Space))
        {
            shootingScript.ShootBullet(spawnPoint);
        }
        progressBar.value = killCount;
        if (progressBar.value >= progressBar.maxValue / 3 * 2)
        {
            corruption.SetActive(true);
        }
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
