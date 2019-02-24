using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    float newY = 0;

    public float rotSpeed;

    int playerNum;

    GameObject enviroPlayer;

    public GameObject objToRotate;

    void Awake()
    {
        enviroPlayer = GameObject.Find("Player Environment");
    }

    void Update()
    {
        playerNum = enviroPlayer.GetComponent<Controller_Movement>().playerNum;

        if (playerNum == 1 && enviroPlayer.GetComponent<Take_Control>().objInControl == gameObject)
        {
            newY += (Input.GetAxis("Horizontal_P1") * rotSpeed) * Time.deltaTime;

            if (objToRotate != null)
            {
                objToRotate.transform.rotation = Quaternion.Euler(new Vector3(0, newY, 0));
            }
            else {
                transform.rotation = Quaternion.Euler(new Vector3(0, newY, 0));
            }

            
        }
        else if (playerNum == 2 && enviroPlayer.GetComponent<Take_Control>().objInControl == gameObject) {
            newY += (Input.GetAxis("Horizontal_P2") * rotSpeed) * Time.deltaTime;
            if (objToRotate != null)
            {
                objToRotate.transform.rotation = Quaternion.Euler(new Vector3(0, newY, 0));
            }
            else {
                transform.rotation = Quaternion.Euler(new Vector3(0, newY, 0));
            }
        }
        
    }
}
