using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch_Player : MonoBehaviour
{
    int playerNum;

    public int switchesLeft;

    void Start()
    {
        playerNum = GetComponent<Controller_Movement>().playerNum;
        switchesLeft = 3;
    }

    void Update()
    {
        if (playerNum == 1 && Input.GetButtonDown("X_P1") && GameObject.FindObjectOfType<Take_Control>().objInControl == null && switchesLeft > 0)
        {
            print("X Pressed on first controller");
            Switch();
            switchesLeft--;
        }
        else if (playerNum == 2 && Input.GetButtonDown("X_P2") && GameObject.FindObjectOfType<Take_Control>().objInControl == null && switchesLeft > 0) {
            print("X Pressed on Second controller");
            Switch();
            switchesLeft--;
        }
    }

    void Switch() {
        Controller_Movement[] players = GameObject.FindObjectsOfType<Controller_Movement>();

        

        foreach (Controller_Movement player in players) {
            player.SwtichPlayer();
            player.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
        playerNum = GetComponent<Controller_Movement>().playerNum;

        Vector3 pos0 = players[0].transform.position;
        Vector3 pos1 = players[1].transform.position;

        players[0].transform.position = pos1;
        players[1].transform.position = pos0;

        foreach (Controller_Movement player in players)
        {
            if (player.name == "Player Ship") {

                GameObject[] objects = GameObject.FindGameObjectsWithTag("Controllable");

                foreach (GameObject obj in objects) {
                    int ammount = 0;
                    print(player.gameObject.GetComponent<Collider>().bounds.Intersects(obj.GetComponent<Collider>().bounds));
                    while (player.GetComponent<Collider>().bounds.Intersects(obj.GetComponent<Collider>().bounds)) {
                        Vector3 newPlayerPos = player.transform.position;
                        newPlayerPos.x++;
                        player.transform.position = newPlayerPos;
                        ammount++;
                        print("Looped " + ammount + " times");
                    }
                }
                
            }
        }
    }
}
