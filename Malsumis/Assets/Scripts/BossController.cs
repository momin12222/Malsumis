using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossController : MonoBehaviour
{
    Movement movementScript;
    Health healthScript;
    Shoot shootingScript;
    private Animator animator;
    private AnimatorClipInfo[] animatorClipInfo;

    public Transform spawnPoint;
    public Transform dashPoint;
    public Transform endPoint;

    public GameObject dashCollider;
    public GameObject win;

    public float speed;
    public float dashSpeed;
    private Transform startPos;

    public float dashRate;
    public float fireRate;

    private bool dashing;

    void Start()
    {
        movementScript = GetComponent<Movement>();
        healthScript = GetComponent<Health>();
        shootingScript = GetComponent<Shoot>();
        animator = GetComponent<Animator>();
        animatorClipInfo = animator.GetCurrentAnimatorClipInfo(0);

        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().progressBar.maxValue = healthScript.startHP;
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().killCount = healthScript.currentHP;

        StartCoroutine("Dash");
        StartCoroutine("Fireball");
        StartCoroutine(CheckPoint(spawnPoint));
        StartCoroutine(CheckPoint(dashCollider.transform));
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
        }
    }

    IEnumerator Fireball()
    {
        while (true)
        {
            yield return new WaitForSeconds(fireRate);
            shootingScript.Fireball(spawnPoint);
        }
    }

    IEnumerator CheckPoint(Transform point)
    {
        while (true)
        {
            point.transform.localPosition = new Vector2(-4.6f, -2.4f);
            yield return new WaitForSeconds(animatorClipInfo.Length);
            point.transform.localPosition = new Vector2(-5.17f, -1.13f);
            yield return new WaitForSeconds(animatorClipInfo.Length);
            point.transform.localPosition = new Vector2(-5.51f, 0.08f);
            yield return new WaitForSeconds(animatorClipInfo.Length);
            point.transform.localPosition = new Vector2(-4.63f, -0.72f);
            yield return new WaitForSeconds(animatorClipInfo.Length);
        }
    }

}
