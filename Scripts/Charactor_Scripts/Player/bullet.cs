using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed;
    public int dmg;

    public float distance;
    public LayerMask isLayer;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyBullet", 2);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D ray = Physics2D.Raycast(transform.position, transform.right, distance, isLayer);
        if (ray.collider != null)
        {
            {
                if (ray.collider.tag == "Enemy")
                    Debug.Log("ИэСп");
            }
                DestroyBullet();
        }

        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }
    void DestroyBullet()
    {
        Destroy(gameObject);
    }
}