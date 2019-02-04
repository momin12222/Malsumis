using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    
    void Start()
    {
    }

    public void PlayerMovement()
    {
        Vector2 movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        transform.Translate(Time.deltaTime * speed * movement);
    }

    public void MoveForward()
    {
        transform.Translate(Time.deltaTime * speed, 0f, 0f);
        //add stop at point or whatever
    }
}
