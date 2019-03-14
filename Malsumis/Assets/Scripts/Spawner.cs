using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawner : MonoBehaviour
{
    public GameObject prefab1;
    public GameObject prefab2;
    public GameObject prefab3;

    private PlayerController player;
    private AlienController alien;

    public float time;
    public float timeMin;
    public float timeMax;
    public int range;

    private float cooldown;
    private Vector3 spawnPos;

    private float killCount;
    private float progressValue;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        alien = GameObject.FindGameObjectWithTag("Alien").GetComponent<AlienController>();

        killCount = player.killCount;
        progressValue = player.killCount;

        player.progressBar.maxValue = range * 3;
    }

    private void Update()
    {
        killCount = player.killCount;
        if (killCount >= 0 && killCount < range)
        {
            Spawn(prefab1);
            alien.GetComponent<Animator>().SetBool("dash", false);
            alien.GetComponent<Animator>().SetBool("fireball", false);
        }
        if (killCount >= range && killCount < range * 2)
        {  
            Spawn(prefab2);
            alien.dashActive = true;
            alien.GetComponent<Animator>().SetBool("dash", true);
            alien.GetComponent<Animator>().SetBool("fireball", false);
        }
        if (killCount >= range * 2 && killCount < range * 3)
        {
            Spawn(prefab3);
            alien.fireballActive = true;
            alien.GetComponent<Animator>().SetBool("dash", true);
            alien.GetComponent<Animator>().SetBool("fireball", true);
        }
        if (player.progressBar.value == player.progressBar.maxValue)
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
