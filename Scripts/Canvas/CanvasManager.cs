using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    bool isPause;
    public GameObject UI;
    public playerAttack player;

    // Start is called before the first frame update
    void Start()
    {
        isPause = false; 
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            UI.SetActive(true);
            if(isPause == false)
            {
                player.enabled = false;
                isPause = true;
                return;
            }

            if (isPause == true)
            {
                player.enabled = true;
                Time.timeScale = 1;
                isPause = false;
                return;
            }
        }

    }
}
