using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointController : MonoBehaviour
{
    Movement movementScript;

    public float amplitude;
    public float multiplier;
    
    void Start()
    {
        movementScript = GetComponent<Movement>();
    }

    void Update()
    {
        movementScript.MoveY(amplitude, multiplier);
    }
}
