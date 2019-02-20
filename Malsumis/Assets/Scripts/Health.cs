﻿using System.Collections;
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
        if (currentHP <= 0 && gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamageWithUpdate(int amount)
    {
        TakeDemange(amount);
        updateHearts();
    }

    void updateHearts()
    {
        //currentHP = Mathf.Clamp(currentHP, 0, startHP);
        healthImages[currentHP].SetActive(false);
        
    }
}
