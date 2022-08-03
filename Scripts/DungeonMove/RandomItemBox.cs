using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomItemBox : MonoBehaviour
{
    public GameObject[] dungeons;
    public GameObject itemBox;

    // Start is called before the first frame update
    void Start()
    {
        RandomDungeon();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RandomDungeon()
    {
        int random = Random.Range(1, 3);

        for(int i = 0; i < random; i++)
        {
            int randomNum = Random.Range(0, 8);
            GameObject item = Instantiate(itemBox, new Vector2(0,0), Quaternion.identity);
            item.transform.SetParent(dungeons[randomNum].transform, false);
        }
       
    }
}
