using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private float direction = 1;
    private Transform temp;

    public Camera MainCamera;
    private Vector2 screenBounds;
    private float objectWidth;
    private float objectHeight;

    private void Start()
    {
        MainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        screenBounds = MainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, MainCamera.transform.position.z));
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.extents.x; //extents = size of width / 2
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.extents.y; //extents = size of height / 2
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

    public void Bound()
    {
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, screenBounds.x * -1 + objectWidth, screenBounds.x - objectWidth);
        pos.y = Mathf.Clamp(pos.y, screenBounds.y * -1 + objectHeight, screenBounds.y - objectHeight - 4);
        transform.position = pos;
    }
}
