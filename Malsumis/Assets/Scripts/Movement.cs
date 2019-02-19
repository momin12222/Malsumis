using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public void PlayerMovement(float speed)
    {
        Vector2 movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        transform.Translate(Time.deltaTime * speed * movement);
    }

    public void MoveForward(float speed)
    {
        transform.Translate(Time.deltaTime * speed, 0f, 0f);
    }

    public void MoveToPoint(Transform point, float speed)
    {
        transform.position = Vector2.MoveTowards(transform.position, point.position, speed * Time.deltaTime);
    }
}
