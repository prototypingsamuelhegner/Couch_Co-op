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
        if (playerNum == 1 && Input.GetButtonDown("X_P1") && GameObject.FindObjectOfType<Take_Control>().objInControl == null)
        {
            print("X Pressed on first controller");
            Switch();
        }
        else if (playerNum == 2 && Input.GetButtonDown("X_P2") && GameObject.FindObjectOfType<Take_Control>().objInControl == null) {
            print("X Pressed on Second controller");
            Switch();
        }
    }

    void Switch() {
        Controller_Movement[] players = GameObject.FindObjectsOfType<Controller_Movement>();

        

        foreach (Controller_Movement player in players) {
            player.SwtichPlayer();
        }
        playerNum = GetComponent<Controller_Movement>().playerNum;

        Vector3 pos0 = players[0].transform.position;
        Vector3 pos1 = players[1].transform.position;

        players[0].transform.position = pos1;
        players[1].transform.position = pos0;
    }
}
