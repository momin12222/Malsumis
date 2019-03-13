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
    private float killCount;

    private void Start()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().progressBar.maxValue = range * 3;
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().progressBar.value = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().killCount;
    }

    private void Update()
    {
        killCount = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().killCount;
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
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().progressBar.value == GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().progressBar.maxValue)
        {
            SceneManager.LoadScene("BossLevel");
        }
    }

    public void Spawn(GameObject prefab)
    {
        spawnPos.x = transform.position.x;
        spawnPos.y = Random.Range(-6, 5);
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
