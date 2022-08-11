using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove2 : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {

    }
    void Awake()
    {
        animator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        //이동 및 방향 전환
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");
        if (inputX > 0) transform.localScale = new Vector2(-3, 3);
        else if (inputX < 0) transform.localScale = new Vector2(3, 3);

        //공격시 문워크
        Vector2 len = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float z = Mathf.Atan2(-len.y, -len.x) * Mathf.Rad2Deg;

        if (Input.GetButton("Fire1"))
        {
            if ((z < -90 && z >= -180) || (z > 90 && z <= 180))
            {
                if (inputX < 0) transform.localScale = new Vector2(-3, 3);
            }
            else if ((z > 0 && z <= 90) || (z < 0 && z > -90))
                if (inputX > 0) transform.localScale = new Vector2(3, 3);
        }

        if ((z < -90 && z >= -180) || (z > 90 && z <= 180))
            transform.localScale = new Vector2(-3, 3);
        else if ((z > 0 && z <= 90) || (z < 0 && z > -90))
            transform.localScale = new Vector2(3, 3);

        //권총 공격
        if (Input.GetButton("Fire1"))
            animator.SetBool("isShootPistol", true);
        else animator.SetBool("isShootPistol", false);

        //이동 애니메이션
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
            animator.SetBool("isWalking", true);

            if (Input.GetKey(KeyCode.LeftShift))
                animator.SetBool("isRun", true);
            else animator.SetBool("isRun", false);
        }
        else if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.LeftShift))
        {
            animator.SetBool("isWalking", false);
            animator.SetBool("isRun", false);
        }
        else animator.SetBool("isWalking", false);

        
    }
}
