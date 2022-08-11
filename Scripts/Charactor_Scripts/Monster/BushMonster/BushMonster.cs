using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BushMonster : MonoBehaviour
{
    public Animator anim;
    public Enemy monster;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (monster.health == 0)
        {
            anim.SetTrigger("isDead");
        }

    }
}

