using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetaPlayerMove : MonoBehaviour
{

    [SerializeField]
    private float speed;
    private Vector2 direction;

    public int Hp;

    // Start is called before the first frame update
    void Start()
    {
        direction = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        Move();
    }

    public void Move()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    private void GetInput()
    {
        Vector2 moveVector;

        moveVector.x = Input.GetAxisRaw("Horizontal");
        moveVector.y = Input.GetAxisRaw("Vertical");

        direction = moveVector;
    }

    public void TakeDamge(int damage)
    {
        Hp = Hp - damage;
    }
}
