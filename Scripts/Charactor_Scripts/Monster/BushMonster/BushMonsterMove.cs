using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BushMonsterMove : MonoBehaviour
{
    public enum CurrentState
    {
        trace,
        attack,
        dead
    }
    public CurrentState curState = CurrentState.trace;

    public Transform target;
    public Vector3 direction;
    public float velocity;
    public float accelaration;

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TracePlayer();
        if (player.transform.position.x < transform.position.x)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
    }

    public void TracePlayer()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        direction = (target.position - transform.position).normalized;
        accelaration = 0.005f;


        velocity = (velocity + accelaration * Time.deltaTime);

        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= 20.0f)
        {
            this.transform.position = new Vector3(transform.position.x + (direction.x * velocity), transform.position.y + (direction.y * velocity), transform.position.z);

            curState = CurrentState.trace;
        }

        else if (distance <= 10.0f)
        {
            accelaration = 0.01f;
            this.transform.position = new Vector3(transform.position.x + (direction.x * velocity), transform.position.y + (direction.y * velocity), transform.position.z);

            curState = CurrentState.attack;
        }
        if (distance <= 2f)
        {
            velocity = 0f;
        }
    }
}
