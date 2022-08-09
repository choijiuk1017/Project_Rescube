using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BushMonster : MonoBehaviour
{
    public Animator anim;
    public int Hp;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Hp == 0)
        {
            anim.SetTrigger("isDead");
            Destroy(gameObject);
        }

    }
}

