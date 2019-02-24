using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawner : MonoBehaviour
{
    public GameObject prefab1;
    public GameObject prefab2;
    public GameObject prefab3;
    public float time;
    public int range1;
    public int range2;
    public int range3;

    private float cooldown;
    private Vector3 spawnPos;
    private int killCount;

    private void Update()
    {
        killCount = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().killCount;
        if (killCount >= 0 && killCount <= range1)
        {
            Spawn(prefab1);
        }
        else if (killCount >= range1 && killCount <= range2)
        {
            Spawn(prefab2);
        }
        else if (killCount >= range2 && killCount < range3)
        {
            Spawn(prefab3);
        }
        if (killCount == range3)
        {
            SceneManager.LoadScene("BossLevel");
        }
    }

    public void Spawn(GameObject prefab)
    {
        spawnPos.x = transform.position.x;
        spawnPos.y = Random.Range(-7, 5);
        spawnPos.z = transform.position.z;

        if (Time.time > cooldown)
        {
            cooldown = Time.time + time;
            Instantiate(prefab, spawnPos, transform.rotation);
        }
    }
}
