using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;

    public void PlayerMovement()
    {
        Vector2 movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        transform.Translate(Time.deltaTime * speed * movement);
    }

    public void MoveForward()
    {
        transform.Translate(Time.deltaTime * speed, 0f, 0f);
    }

    public void MoveToPoint(Transform point)
    {
        transform.position = Vector2.MoveTowards(transform.position, point.position, speed * Time.deltaTime);
    }
}
