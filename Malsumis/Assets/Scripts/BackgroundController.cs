using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    Movement movementScript;
    public float speed;
    public float length;

    void Start()
    {
        movementScript = GetComponent<Movement>();
    }

    void Update()
    {
        movementScript.MoveForward(speed);

        if (transform.position.x < -length)
        {
            LoopBackground();
        }
    }

    private void LoopBackground()
    {
        Vector2 groundOffSet = new Vector2(length * 2f, 0);
        transform.position = (Vector2)transform.position + groundOffSet;
    }

}
