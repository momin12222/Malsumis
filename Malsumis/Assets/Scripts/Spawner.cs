using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawner : MonoBehaviour
{
    public GameObject prefab1;
    public GameObject prefab2;
    public GameObject prefab3;

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

    public float timeToBoss;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        alien = GameObject.FindGameObjectWithTag("Alien").GetComponent<AlienController>();

        player.progressBar.maxValue = range * 3;

        killCount = player.killCount;
        progressValue = player.killCount;

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
            if (evolve1)
            {
                evolution1.SetActive(true);
                Time.timeScale = 0f;
                evolve1 = false;
            }
        }
        if (killCount >= range * 2 && killCount < range * 3)
        {
            Activate(prefab3, true, true);
            if (evolve2)
            {
                evolution2.SetActive(true);
                Time.timeScale = 0f;
                evolve2 = false;
            }
        }
        if (player.progressBar.value == player.progressBar.maxValue)
        {
            if (evolve3)
            {
                evolution3.SetActive(true);
                Time.timeScale = 0f;
                evolve3 = false;
                StartCoroutine(LoadBoss());
            }
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
    }

    IEnumerator LoadBoss()
    {
        yield return new WaitForSeconds(timeToBoss);
        SceneManager.LoadScene("BossLevel");
    }

}
