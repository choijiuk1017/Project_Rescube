using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    public float CoolTime = 15f;
    public GameObject[] player;
    public bool solo_play = false;

    private int index = 0;
    private bool isSwitching = false;
    

    // Start is called before the first frame update
    void Start()
    {
        InitializePlayer();
    }

    // Update is called once per frame
    void Update()
    {
        if (solo_play == true)
        {
            isSwitching = true;
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                if (isSwitching == false)
                {
                    if (index == 0)
                        index = 1;
                    else
                        index = 0;
                    StartCoroutine(SwitchDelay(index));
                }
                else
                    Debug.Log("CoolTime");
            }
        }
        

    }

    private void InitializePlayer()
    {
        for (int i = 0; i < player.Length; i++)
        {
            player[i].SetActive(false);
        }
        player[0].SetActive(true);
        index = 0;
    }

    private IEnumerator SwitchDelay(int newIndex)
    {
        isSwitching = true;
        SwitchPlayer(newIndex);
        yield return new WaitForSeconds(CoolTime);
        isSwitching = false;
    }

    
    private void SwitchPlayer(int newIndex)
    {
        for (int i = 0; i < player.Length; i++)
        {
            player[i].SetActive(false);
        }
        player[newIndex].SetActive(true);
    }
    
}
