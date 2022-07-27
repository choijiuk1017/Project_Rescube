using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static event Action OnPlayerDamaged;

    public float health, maxHealth;

    //void Start()
    //{
    //    health = maxHealth;
    //}
    public void TakeDamaged(float dmg)
    {
        health -= dmg;
        OnPlayerDamaged?.Invoke();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Item")
        {
            Item item = collision.GetComponent<Item>();
            switch (item.type)
            {
                case "HpPotionSmall":
                    health += 2;
                    break;
                case "HpPotionBig":
                    health += 6;
                    break;
            }
            Destroy(collision.gameObject);
        }
    }
    void Update()
    {
        if (health >= maxHealth)
            health = maxHealth;
    }
}