using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonChange : MonoBehaviour
{
    [SerializeField] private Transform emptyDungeon = null;
    [SerializeField] public List<Dungeons> dungeons;



    int emptyDunGeonIndex;

    // Start is called before the first frame update
    void Start()
    {
        dungeons = new List<Dungeons>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void dungeonIndexChange()
    {
        
        
    }
   
    

}
