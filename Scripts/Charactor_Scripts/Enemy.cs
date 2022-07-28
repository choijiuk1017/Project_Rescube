using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public int dmg;

    SpriteRenderer spriteRenderer;
    void OnHit(int dmg)
    {
        health -= dmg;
        if (health <= 0)
            Destroy(gameObject);
        //spriteRenderer.sprite = sprites[1];
        //ReturnSprite();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerAttack")
        {
            bullet Bullet = collision.gameObject.GetComponent<bullet>();
            OnHit(Bullet.dmg);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamaged(dmg);
        }
    }
}
