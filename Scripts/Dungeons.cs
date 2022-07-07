using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dungeons : MonoBehaviour
{

    public Vector3 TargetPosition;
    Vector3 CorrectPosition;
    SpriteRenderer sprite;

    public int number;



    void Start()
    {
        
    }
    void Awake()
    {
        TargetPosition = transform.position;
        CorrectPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // 퍼즐이 부드럽게 이동하도록 설정
        transform.position = Vector3.Lerp(transform.position, TargetPosition, 0.05f);

        
    }
}
