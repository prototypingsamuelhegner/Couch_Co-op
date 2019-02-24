using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Take_Control : MonoBehaviour
{
    public GameObject objInControl;

    bool inControl;

    int playerNum;

    void Start()
    {
        playerNum = GetComponent<Controller_Movement>().playerNum;
        inControl = false;
    }

    void Update()
    {
        if (inControl)
        {
            if (playerNum == 1 && Input.GetButton("A_P1"))
            {
                objInControl = null;
                GetComponent<Controller_Movement>().enabled = true;
                inControl = false;
                Invoke("TurnOffControl", 0.2f);
            }
            else if (playerNum == 2 && Input.GetButton("A_P2"))
            {
                objInControl = null;
                GetComponent<Controller_Movement>().enabled = true;
                inControl = false;
                Invoke("TurnOffControl", 0.2f);
            }
        }
    }

    void OnTriggerStay(Collider other)
    {

        if (Input.GetButton("A_P1"))
        {
            if (playerNum == 1 && other.transform.tag == "Controllable" && inControl == false)
            {
                GetComponent<Controller_Movement>().enabled = false;
                GetComponent<Rigidbody>().velocity = Vector3.zero;
                GetComponent<SphereCollider>().enabled = false;
                objInControl = other.gameObject;
                transform.position = new Vector3(objInControl.transform.position.x, transform.position.y, objInControl.transform.position.z);
                Invoke("TurnOnControl", 0.2f);
            }

            if (playerNum == 1 && other.transform.tag == "Bomb")
            {
                if (!other.gameObject.GetComponent<Bomb>().lit)
                {
                    other.transform.parent.GetComponent<Bomb>().lit = true;
                }
            }
        }
        else if (Input.GetButton("A_P2"))
        {
            if (playerNum == 2 && other.transform.tag == "Controllable" && inControl == false)
            {
                GetComponent<Controller_Movement>().enabled = false;
                GetComponent<Rigidbody>().velocity = Vector3.zero;
                GetComponent<SphereCollider>().enabled = false;
                objInControl = other.gameObject;
                transform.position = new Vector3(objInControl.transform.position.x, transform.position.y, objInControl.transform.position.z);
                Invoke("TurnOnControl", 0.2f);
            }

            if (playerNum == 2 && other.transform.tag == "Bomb") {
                if (!other.transform.parent.GetComponent<Bomb>().lit) {
                    other.transform.parent.GetComponent<Bomb>().lit = true;
                }
            }
        }


    }

    void TurnOnControl()
    {
        inControl = true;
    }

    public void SetNumber()
    {
        playerNum = GetComponent<Controller_Movement>().playerNum;
    }

    void TurnOffControl() {
        GetComponent<SphereCollider>().enabled = true;
    }
}
