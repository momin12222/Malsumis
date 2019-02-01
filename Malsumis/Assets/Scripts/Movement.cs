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

    public void PlayerMovement4axis()
    {
        Vector2 movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if (movement.x < 0) //left
        {
            
        }
        else if (movement.x > 0) //right
        {

        }
        else if (movement.y < 0) //down
        {

        }
        else if (movement.y > 0) //up
        {

        }
    }

    public void MoveForward()
    {
        transform.Translate(Time.deltaTime * speed, 0f, 0f);
        //add stop at point or whatever
    }
}
