using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int startHP;
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
        currentHP = Mathf.Clamp(currentHP, 0, startHP);

        //for (int i = 0; i < healthImages.Length; i++)
        //{
            switch (currentHP)
            {
                case 5: 
                    healthImages[6].gameObject.SetActive(true);
                    break;
                case 4:
                    healthImages[5].gameObject.SetActive(true);
                    break;
                case 3:
                    healthImages[4].gameObject.SetActive(true);
                    break;
                case 2:
                    healthImages[3].gameObject.SetActive(true);
                    break;
                case 1:
                    healthImages[2].gameObject.SetActive(true);
                    break;
                case 0:
                    healthImages[1].gameObject.SetActive(true);
                    break;
                default:
                    break;
            }

        //}
    }
}
