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
    public float timeMin;
    public float timeMax;
    public int range;

    private float cooldown;
    private Vector3 spawnPos;
    public float killCount;

    private void Update()
    {
        if (killCount >= 0 && killCount < range)
        {
            Spawn(prefab1);
        }
        if (killCount >= range && killCount < range * 2)
        {  
            Spawn(prefab2);
            GameObject.FindGameObjectWithTag("Alien").GetComponent<AlienController>().dashActive = true;
        }
        if (killCount >= range * 2 && killCount < range * 3)
        {
            Spawn(prefab3);
            GameObject.FindGameObjectWithTag("Alien").GetComponent<AlienController>().fireballActive = true;
        }
        if (killCount == range * 3)
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
            time = Random.Range(timeMin, timeMax);
            cooldown = Time.time + time;
            Instantiate(prefab, spawnPos, transform.rotation);
        }
    }

    IEnumerator LoadBoss()
    {
        print("here");
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("BossLevel");
    }
}
