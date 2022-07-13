using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dungeons : MonoBehaviour
{

    public Vector3 TargetPosition;
    Vector3 CorrectPosition;
    public int number;



    void Start()
    {
        
    }
    void Awake()
    {
        TargetPosition = transform.position;
        CorrectPosition = transform.position;
    }

    void Update()
    {
        

        
    }
    public void OnMoveTo(Vector3 end)
    {
        StartCoroutine("MoveTo", end);
    }

    private IEnumerator MoveTo(Vector3 end)
    {
        float current = 0;
        float percent = 0;
        float moveTime = 0.1f;
        Vector3 start = GetComponent<Transform>().localPosition;

        while (percent < 1)
        {
            current += Time.deltaTime;
            percent = current / moveTime;

            GetComponent<Transform>().localPosition = Vector3.Lerp(start, end, percent);

            yield return null;
        }
    }
}
