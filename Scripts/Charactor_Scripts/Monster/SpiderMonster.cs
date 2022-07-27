using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderMonster : MonoBehaviour
{
    public int Hp;
    BetaPlayerMove player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Hp == 0)
        {
            Destroy(gameObject);
        }
    }

    void TakeDamage(int damage)
    {
        Hp = Hp - damage;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            TakeDamage(1);
        }
    }
}
