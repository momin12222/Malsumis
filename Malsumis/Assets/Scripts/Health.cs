using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    private int startHP = 3;
    public int currentHP;
    
    //health bar
    public Image[] healthImages;
    public Sprite[] healthSprites;
    
    void Start()
    {
        currentHP = startHP;
        TakeDemange(0);
    }

    public void TakeDemange(int amount)
    {
        currentHP += amount;
    }

    public void TakeDamageWithUpdate(int amount)
    {
        TakeDemange(amount);
        updateHearts();
    }

    void updateHearts()
    {
        currentHP = Mathf.Clamp(currentHP, 0, startHP);

        for (int i = 0; i < healthImages.Length; i++)
        {
            if (i < currentHP)
            {
                healthImages[i].sprite = healthSprites[0];
            }
            else
            {
                healthImages[i].sprite = healthSprites[1];
            }
        }
    }
}
