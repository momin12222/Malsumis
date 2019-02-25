using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int startHP;
    public int currentHP;
    
    //health bar
    public GameObject[] healthImages;
   
    void Start()
    {
        currentHP = startHP;
        TakeDemange(0);
    }

    public void TakeDemange(int amount)
    {
        currentHP -= amount;
        if (currentHP <= 0)
        {
            //if (gameObject.tag == "Enemy1" || gameObject.tag == "Enemy2" || gameObject.tag == "Enemy3")
            //{
            //    GameObject.FindGameObjectWithTag("Spawner").GetComponent<Spawner>().killCount++;
            //    Destroy(gameObject);
            //}
            if (gameObject.tag == "Enemy1")
            {
                GameObject.FindGameObjectWithTag("Spawner").GetComponent<Spawner>().killCount+=0.5f;
                //GameObject.FindGameObjectWithTag("Spawner").GetComponent<Spawner>().enemy1++;
                Destroy(gameObject);
            }
            else if (gameObject.tag == "Enemy2")
            {
                GameObject.FindGameObjectWithTag("Spawner").GetComponent<Spawner>().killCount+=0.5f;
                //GameObject.FindGameObjectWithTag("Spawner").GetComponent<Spawner>().enemy2++;
                Destroy(gameObject);
            }
            else if (gameObject.tag == "Enemy3")
            {
                GameObject.FindGameObjectWithTag("Spawner").GetComponent<Spawner>().killCount++;
                //GameObject.FindGameObjectWithTag("Spawner").GetComponent<Spawner>().enemy3++;
                Destroy(gameObject);
            }
        }
    }

    public void TakeDamageWithUpdate(int amount)
    {
        TakeDemange(amount);
        updateHearts();
    }

    void updateHearts()
    {
        healthImages[currentHP].SetActive(false);
    }
}
