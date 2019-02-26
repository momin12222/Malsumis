using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private float direction = 1;
    private Transform temp;

    public void PlayerMovement(float speed)
    {
        Vector2 movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        //if (transform.position.x > -15 && transform.position.x < 15)
        //{
        //    if (transform.position.y > -8 && transform.position.y < 4)    
        //    {
                transform.Translate(Time.deltaTime * speed * movement);
        //    }
        //}
    }

    public void MoveForward(float speed)
    {
        transform.Translate(Time.deltaTime * speed, 0f, 0f);
    }

    public void MoveInRange(float speed, Transform min, Transform max)
    {
        MoveToPoint(max, speed);
        if (transform.position == max.position && transform.position != min.position)
        {
            MoveToPoint(min, speed);
        }
        //if (gameObject.transform.position.y == max.position.y)
        //{
        //    direction = -1;
        //    print("Cahnged1");
        //}
        //else if (gameObject.transform.position.y == min.position.y)
        //{
        //    direction = 1;
        //    print("Cahnged");
        //}
        //transform.Translate(0f, Time.deltaTime * speed * direction, 0f);
    }

    public void MoveToPoint(Transform point, float speed)
    {
        transform.position = Vector2.MoveTowards(transform.position, point.position, speed * Time.deltaTime);
    }
}
