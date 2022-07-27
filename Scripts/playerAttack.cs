using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAttack : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
            Animator animator;

    public GameObject bullet;
    public Transform pos;
    public float cooltime;
    private float curtime;

    // Start is called before the first frame update
    void Start()
    {

    }
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        //�ѱ� ���콺 ���󰡱�
        Vector2 len = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float z = Mathf.Atan2(-len.y, -len.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, z);
        
        //�Ѿ� ȸ��
        Quaternion rotation = Quaternion.AngleAxis(z, Vector3.forward);
        transform.rotation = rotation;

        //�� ���ӽ� �ѱ� ��ȭ
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            if ((z < -90 && z >= -180) || (z > 90 && z <= 180))
                transform.localScale = new Vector3(-1, 1, 0);
            else if ((z > 0 && z <= 90) || (z < 0 && z > -90))
                transform.localScale = new Vector3(1, 1, 0);
        }
        
        //�ѱ� �¿��� ��ȯ
        if (z < -90 && z >= -180)
            spriteRenderer.flipY = true;
        else if (z > 90 && z <= 180)
            spriteRenderer.flipY = true;
        else spriteRenderer.flipY = false;

        if ((z < -90 && z >= -180) || (z > 90 && z <= 180))
            transform.localScale = new Vector3(-1, 1, 0);
        else if ((z > 0 && z <= 90) || (z < 0 && z > -90))
            transform.localScale = new Vector3(1, 1, 0);

        //���� ����
        if (Input.GetButton("Fire1"))
            animator.SetBool("isShoot", true);
        else animator.SetBool("isShoot", false);

        //���콺�� ���
        if (curtime <= 0)
        {
            if (Input.GetButton("Fire1"))
            {
                Instantiate(bullet, pos.position, Quaternion.AngleAxis(z, Vector3.forward));
            }
         curtime = cooltime;
        }
     curtime -= Time.deltaTime;
    }
}