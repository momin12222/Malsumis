using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Movement movementScript;
    Health healthScript; //on collision call take dmg with update

    void Start()
    {
        movementScript = GetComponent<Movement>();
    }

    void Update()
    {
        movementScript.PlayerMovement();
    }

}
