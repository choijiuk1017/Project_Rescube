using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    public GameObject rangeObject;
    BoxCollider rangeCollider;

    public GameObject Spawner;
    private void Awake()
    {
        rangeCollider = rangeObject.GetComponent<BoxCollider>();
    }
    // Start is called before the first frame update
    private void Start()
    {
        for(int i = 0; i < 5; i++)
        {
            GameObject instantSpawner = Instantiate(Spawner, Return_RandomPosition(), Quaternion.identity);
        }
    }

    Vector3 Return_RandomPosition()
    {
        Vector3 originPosition = rangeObject.transform.position;
        // 콜라이더의 사이즈를 가져오는 bound.size 사용
        float range_X = rangeCollider.bounds.size.x;
        float range_Y = rangeCollider.bounds.size.y;

        range_X = Random.Range((range_X / 2) * -1, range_X / 2);
        range_Y = Random.Range((range_Y / 2) * -1, range_Y/ 2);
        Vector3 RandomPostion = new Vector3(range_X, range_Y, 0f);

        Vector3 respawnPosition = originPosition + RandomPostion;
        return respawnPosition;
    }
}
