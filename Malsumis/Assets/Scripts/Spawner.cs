using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;
    public float time;

    private float cooldown;
    private Vector3 spawnPos;

    private void Update()
    {
        Spawn();
    }

    public void Spawn()
    {
        spawnPos.x = transform.position.x;
        spawnPos.y = Random.Range(-10, 5);
        spawnPos.z = transform.position.z;

        if (Time.time > cooldown)
        {
            cooldown = Time.time + time;
            Instantiate(prefab, spawnPos, transform.rotation);
        }
    }
}
