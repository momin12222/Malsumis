using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private float direction = 1;
    private Transform temp;

    Vector3 newVector;
    private Transform topLeft;
    private Transform bottomRight;

    private void Start()
    {
        topLeft = GameObject.FindGameObjectWithTag("top").transform;
        bottomRight = GameObject.FindGameObjectWithTag("bottom").transform;
    }

    public void PlayerMovement(float speed)
    {
        Vector2 movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        transform.Translate(Time.deltaTime * speed * movement);
        Bound();
    }

    public void MoveToPoint(Transform point, float speed)
    {
        transform.position = Vector2.MoveTowards(transform.position, point.position, speed * Time.deltaTime);
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

    private void Bound()
    {
        if (transform.position.x < topLeft.position.x)
        {
            newVector = new Vector2(transform.position.x + 1, transform.position.y);
            if (transform.position != newVector)
            {
                transform.position = Vector3.MoveTowards(transform.position, newVector, 1f);
            }
        }
        else if (transform.position.x > bottomRight.position.x)
        {
            newVector = new Vector2(transform.position.x + 1, transform.position.y);
            if (transform.position != newVector)
            {
                transform.position = Vector3.MoveTowards(transform.position, newVector, -1f);
            }
        }
        else if (transform.position.y > topLeft.position.y)
        {
            newVector = new Vector2(transform.position.x, transform.position.y - 1);
            if (transform.position != newVector)
            {
                transform.position = Vector3.MoveTowards(transform.position, newVector, 1f);
            }
        }
        else if (transform.position.y < bottomRight.position.y)
        {
            newVector = new Vector2(transform.position.x, transform.position.y - 1);
            if (transform.position != newVector)
            {
                transform.position = Vector3.MoveTowards(transform.position, newVector, -1f);
            }
        }
    }
}
