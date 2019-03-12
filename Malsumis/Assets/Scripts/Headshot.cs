using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Headshot : MonoBehaviour
{
    Health healthScript;

    void Start()
    {
        healthScript = transform.parent.GetComponent<Health>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "PlayerBullet")
        {
            healthScript.TakeDemange(healthScript.currentHP);
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
