using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Monster : MonoBehaviour
{
    public int monsterHp;

    public GameObject player;

    public GameObject monster;

    Rigidbody2D rigid;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //������ ü���� �پ��� �Լ�
    public void TakeDamage(int damage)
    {
        monsterHp = monsterHp - damage;

        //���͸� ������ �� ���Ͱ� �ڷ� �з���
        int dirc = transform.position.x - player.transform.position.x > 0 ? 1 : -1;
        rigid.AddForce(new Vector2(dirc, 2), ForceMode2D.Impulse);

        if(monsterHp == 0)
        {
            monster.SetActive(false);
        }
    }
}
