using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    Movement movementScript;
    public Transform endPoint;
    public float speed;

    void Start()
    {
        movementScript = GetComponent<Movement>();
    }

    void Update()
    {
        movementScript.MoveForward(speed, 0, false);
        if (transform.position.x > 20 || transform.position.x < -20)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy" && gameObject.tag == "PlayerBullet")
        {
            Destroy(gameObject);
            //This makes hit sound.
            SoundManagerScript.PlaySound("Hit");
        }
        else if (other.gameObject.tag == "Player" && gameObject.tag == "EnemyBullet")
        {
            Destroy(gameObject);
            //This makes hit sound.
            SoundManagerScript.PlaySound("Hit");
        }
    }
}
