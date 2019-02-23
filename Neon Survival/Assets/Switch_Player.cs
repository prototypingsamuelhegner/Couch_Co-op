using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch_Player : MonoBehaviour
{
    int playerNum;

    void Start()
    {
        playerNum = GetComponent<Controller_Movement>().playerNum;
        print(playerNum);
    }

    void Update()
    {
        if (playerNum == 1)
        {
            if (Input.GetButtonDown("X_P1"))
            {
                print("X Pressed");
            }
        }
        else if (playerNum == 2) {
            if (Input.GetButtonDown("X_P2")) {
                print("X Pressed");
            }
        }
    }
}
