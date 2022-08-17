using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public GameObject player;
    public GameObject[] item;
    public GameObject spawnPoint;
    Animator anim;
    public bool isPlayerEnter;
    public BoxCollider2D boxCollider2D;

    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();

        isPlayerEnter = false;

        boxCollider2D = GetComponent<BoxCollider2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // �÷��̾ ���� �ȿ� �ְ� E Ű�� �����ٸ�
        if (isPlayerEnter && Input.GetKeyDown(KeyCode.E))
        {
            // �ڽ� �ִϸ��̼ǿ��� Open���� �̸������� Ʈ���Ÿ� üũ!
            anim.SetTrigger("Open");
            Invoke("OpenBox", 0.8f);
        }

    }

    void OpenBox()
    {
        int randomNum = Random.Range(0, item.Length+1);

        spawnPoint = Instantiate(item[randomNum], spawnPoint.transform.position, Quaternion.identity);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject == player)
        {
            isPlayerEnter = true;
        }

    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject == player)
        {
            isPlayerEnter = false;
        }
    }
}
