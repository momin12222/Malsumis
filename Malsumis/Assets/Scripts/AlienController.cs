using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienController : MonoBehaviour
{
    Movement movementScript;
    public Transform alienPoint;

    void Start()
    {
        movementScript = GetComponent<Movement>();
    }

    void Update()
    {
        movementScript.MoveToPoint(alienPoint);
    }
}
