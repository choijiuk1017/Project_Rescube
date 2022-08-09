using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BushMonsterAttack : MonoBehaviour
{
    public BushMonsterMove monster;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Attack()
    {
        anim.SetTrigger("isAttack");
    }

    public void StopAttack()
    {
        anim.ResetTrigger("isAttack");
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Attack();
        }
        else if(col == null)
        {
            StopAttack();
        }
    }
}
