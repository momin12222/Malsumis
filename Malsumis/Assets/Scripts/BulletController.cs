using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    Movement movementScript;
    public Transform endPoint;

    void Start()
    {
        movementScript = GetComponent<Movement>();
    }

    void Update()
    {
        movementScript.MoveForward();
        if (transform.position.x > 13)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy" && gameObject.tag == "PlayerBullet")
        {
            Destroy(gameObject);
        }
        else if (other.gameObject.tag == "Player" && gameObject.tag == "EnemyBullet")
        {
            Destroy(gameObject);
        }
    }
}
