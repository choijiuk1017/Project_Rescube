using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public Transform spawnPoint;

    public BetaPlayerMove player;
    public Monster monster;

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (col.gameObject.tag != "Monster")
            {
                StartCoroutine(Spawn());
            }
        }
    }

    //�ڷ�ƾ�� �̿��� �������� ������ �����ϵ��� ����
    IEnumerator Spawn()
    {
        while(true)
        {
            for(int i = 0; i < 3; i++)
            {
                Instantiate(enemyPrefabs[i], spawnPoint.position, Quaternion.identity);
            }
            yield return new WaitForSeconds(10f);
        }
    }


}
