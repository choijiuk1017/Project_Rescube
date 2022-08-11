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
        //ÃÑ±¸ ¸¶¿ì½º µû¶ó°¡±â
        Vector2 len = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float z = Mathf.Atan2(-len.y, -len.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, z);
        
        //ÃÑ¾Ë È¸Àü
        Quaternion rotation = Quaternion.AngleAxis(z, Vector3.forward);
        transform.rotation = rotation;

        //ÃÑ Á¾¼Ó½Ã ÃÑ±¸ º¯È­
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            if ((z < -90 && z >= -180) || (z > 90 && z <= 180))
                transform.localScale = new Vector3(-1, 1, 0);
            else if ((z > 0 && z <= 90) || (z < 0 && z > -90))
                transform.localScale = new Vector3(1, 1, 0);
        }
        
        //ÃÑ±¸ ÁÂ¿ìÃø ÀüÈ¯
        if (z < -90 && z >= -180)
            spriteRenderer.flipY = true;
        else if (z > 90 && z <= 180)
            spriteRenderer.flipY = true;
        else spriteRenderer.flipY = false;

        if ((z < -90 && z >= -180) || (z > 90 && z <= 180))
            transform.localScale = new Vector3(-1, 1, 0);
        else if ((z > 0 && z <= 90) || (z < 0 && z > -90))
            transform.localScale = new Vector3(1, 1, 0);

        //±ÇÃÑ °ø°Ý
        if (Input.GetButton("Fire1"))
            animator.SetBool("isShoot", true);
        else animator.SetBool("isShoot", false);

        //¸¶¿ì½º·Î ½î±â
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