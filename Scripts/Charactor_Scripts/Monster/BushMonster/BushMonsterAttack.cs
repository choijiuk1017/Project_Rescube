using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BushMonsterAttack : MonoBehaviour
{
    public BushMonsterMove monster;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Attack()
    {
        if(monster.curState == BushMonsterMove.CurrentState.attack)
        {
            anim.SetTrigger("isAttack");
        }    
    }
}
