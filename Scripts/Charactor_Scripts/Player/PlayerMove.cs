using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed;
    //public Sprite[] sprites;

    //public GameObject player;
    //public GameManager manager;

    SpriteRenderer spriteRenderer;
    Animator animator;

    void Start()
    {
        
    }
    void Awake()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        move();
    }
    void move()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        transform.Translate(new Vector2(inputX, inputY) * Time.deltaTime * moveSpeed);

        // ´Þ¸®±â

        if (Input.GetKeyDown(KeyCode.LeftShift))
            moveSpeed = moveSpeed + 2;
        else if (Input.GetKeyUp(KeyCode.LeftShift))
            moveSpeed = moveSpeed - 2;

        if (Input.GetButtonDown("Fire1"))
            moveSpeed = moveSpeed - 1;
        else if (Input.GetButtonUp("Fire1"))
            moveSpeed = moveSpeed + 1;
    }
    
}
