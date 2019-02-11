using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounds : MonoBehaviour
{
    private Vector2 screenBounds;

    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    public void BoundObject()
    {
        Vector3 position = transform.position;
        position.x = Mathf.Clamp(position.x, screenBounds.x, screenBounds.x * -1);
        position.y = Mathf.Clamp(position.y, screenBounds.y, screenBounds.y * -1);
        transform.position = position;
    }
}
