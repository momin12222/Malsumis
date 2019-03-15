using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawner : MonoBehaviour
{
    public GameObject prefab1;
    public GameObject prefab2;
    public GameObject prefab3;

    public GameObject corruption1;
    public GameObject corruption2;

    public GameObject evolution1;
    public GameObject evolution2;
    public GameObject evolution3;

    private bool evolve1;
    private bool evolve2;
    private bool evolve3;

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

        evolve1 = true;
        evolve2 = true;
        evolve3 = true;
    }

    private void Update()
    {
        killCount = player.killCount;
        if (killCount >= 0 && killCount < range)
        {
            Activate(prefab1, false, false);
        }
        if (killCount >= range && killCount < range * 2)
        {
            Activate(prefab2, true, false);
            Evolve(evolution1, evolve1);
        }
        if (killCount >= range * 2 && killCount < range * 3)
        {
            Activate(prefab3, true, true);
            Evolve(evolution2, evolve2);
        }
        if (player.progressBar.value == player.progressBar.maxValue)
        {
            //Evolve(evolution3, evolve3);
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

    void Activate(GameObject prefab, bool dash, bool fireball)
    {
        Spawn(prefab);
        alien.dashActive = dash;
        alien.fireballActive = fireball;
        alien.GetComponent<Animator>().SetBool("dash", dash);
        alien.GetComponent<Animator>().SetBool("fireball", fireball);
        corruption1.SetActive(dash);
        corruption2.SetActive(fireball);
    }

    void Evolve(GameObject evolution, bool evolve)
    {
        if (evolve)
        {
            evolution.SetActive(true);
            Time.timeScale = 0f;
            evolve = false;
        }
    }

    IEnumerator LoadBoss()
    {
        print("here");
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("BossLevel");
    }

    public void Resume(GameObject obj)
    {
        print("load");
        Time.timeScale = 1f;
        obj.SetActive(false);
    }
}
