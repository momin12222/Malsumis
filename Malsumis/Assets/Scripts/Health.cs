using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int startHP;
    public int currentHP;
    public GameObject[] healthImages;
   
    void Start()
    {
        currentHP = startHP;
        //TakeDemange(0);
    }

    public void TakeDemange(int amount)
    {
        StartCoroutine("Blink");
        currentHP -= amount;
        if (currentHP <= 0)
        {
            DeathConditions();
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

    void DeathConditions()
    {
        if (gameObject.tag == "Enemy")
        {
            GameObject.FindGameObjectWithTag("UI").GetComponent<PauseMenu>().Death();
        }
        else if (gameObject.tag == "Enemy1" || gameObject.tag == "Enemy2" || gameObject.tag == "Enemy3")
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().killCount++;
            Destroy(gameObject);
        }
    }

    IEnumerator Blink()
    {
        //This makes hit sound.
        SoundManagerScript.PlaySound("Hit");
        gameObject.GetComponent<SpriteRenderer>().material.color = Color.gray;
        yield return new WaitForSeconds(0.1f);
        gameObject.GetComponent<SpriteRenderer>().material.color = Color.white;
    }
}
