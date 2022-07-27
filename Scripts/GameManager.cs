using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int startHealthContainer = 1;
    public int curHealth;
    public int healthPerHeart = 4;
    private int maxHealthContainer = 3;
    public int maxHealth;

    public Sprite[] healthSprites;
    public GameObject[] enemyObj;
    public Image[] healthImages;

    void UpdateHealth()
    {
        bool empty = false;
        int i = 0;

        foreach (Image image in healthImages)
        {
            if (empty)
                image.sprite = healthSprites[0];
            else
            {
                i++;
                if (curHealth >= i * healthPerHeart)
                    image.sprite = healthSprites[healthSprites.Length - 1];
                else
                {
                    int currentHeartHealth = (int)(healthPerHeart - (healthPerHeart * i - curHealth));
                    int healthPerImage = healthPerHeart / (healthSprites.Length - 1);
                    int imageIndex = currentHeartHealth / healthPerImage;
                    image.sprite = healthSprites[imageIndex];
                    empty = true;
                }
            }
        }
    }
    void Start()
    {
        curHealth = startHealthContainer * healthPerHeart;
        maxHealth = maxHealthContainer * healthPerHeart;
        CheckHealthAmount();
    }
    //void OnHit(int dmg)
    //{
    //    health -= dmg;
    //    spriteRenderer.sprite = sprites[1];
    //    if (health <= 0)
    //        Destroy(gameObject);
    //}
    void CheckHealthAmount()
    {
        for (int i = 0; i < maxHealthContainer; i++)
        {
            if (startHealthContainer <= i)
            {
                healthImages[i].enabled = false;
            }
            else
            {
                healthImages[i].enabled = true;
            }
        }
        UpdateHealth();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Enemyattack")
        {
            curHealth--;
        }
    }
}