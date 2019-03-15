using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossController : MonoBehaviour
{
    Movement movementScript;
    Health healthScript;
    Shoot shootingScript;
    public Transform spawnPoint;
    public Transform dashPoint;
    public Transform endPoint;

    public GameObject dashCollider;

    public float speed;
    public float dashSpeed;
    private Transform startPos;

    public float dashRate;
    public float fireRate;

    private bool dashing;
    public Image dashIndicator;
    public Image fireballIndicator;

    void Start()
    {
        movementScript = GetComponent<Movement>();
        healthScript = GetComponent<Health>();
        shootingScript = GetComponent<Shoot>();

        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().progressBar.maxValue = healthScript.startHP;
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().killCount = healthScript.currentHP;

        StartCoroutine("Dash");
        StartCoroutine("Fireball");
    }

    void Update()
    {
        if (dashing)
        {
            movementScript.MoveToPoint(dashPoint, dashSpeed);
            if (transform.position == dashPoint.position)
            {
                dashing = false;
                dashCollider.gameObject.SetActive(false);
            }
        }
        else
        {
            movementScript.MoveToPoint(endPoint, dashSpeed);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "PlayerBullet")
        {
            healthScript.TakeDemange(1);
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().killCount = healthScript.currentHP;
            Destroy(other.gameObject);
        }
    }

    IEnumerator Dash()
    {
        while (true)
        {
            yield return new WaitForSeconds(dashRate);
            dashing = true;
            dashPoint.transform.position = new Vector3(dashPoint.position.x, transform.position.y, transform.position.z);
            dashCollider.gameObject.SetActive(true);
            dashIndicator.gameObject.SetActive(false);
        }
    }

    IEnumerator Fireball()
    {
        while (true)
        {
            yield return new WaitForSeconds(fireRate);
            shootingScript.Fireball(spawnPoint);
            fireballIndicator.gameObject.SetActive(false);
        }
    }

}
