using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Take_Control : MonoBehaviour
{
    public GameObject objInControl;
    public GameObject objPickedUp;

    public bool inControl;
    public bool pickedUp;

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
            transform.position = objInControl.transform.position;
            if (playerNum == 1 && Input.GetButtonDown("A_P1"))
            {
                if (objInControl.GetComponent<Laser>() != null)
                {
                    objInControl.GetComponent<Laser>().controlled = false;
                    objInControl.GetComponent<Laser>().active = false;
                }
                objInControl = null;
                GetComponent<Controller_Movement>().enabled = true;
                inControl = false;
                Invoke("TurnOffControl", 0.2f);
            }
            else if (playerNum == 2 && Input.GetButtonDown("A_P2"))
            {
                if (objInControl.GetComponent<Laser>() != null)
                {
                    objInControl.GetComponent<Laser>().controlled = false;
                    objInControl.GetComponent<Laser>().active = false;
                }
                objInControl = null;
                GetComponent<Controller_Movement>().enabled = true;
                inControl = false;
                Invoke("TurnOffControl", 0.2f);
            }
        }

        if (pickedUp)
        {
            objPickedUp.transform.parent.transform.position = transform.position;

            if (playerNum == 1 && Input.GetButtonDown("A_P1"))
            {
                pickedUp = false;
                Invoke("TurnOffPickUp", 0.2f);
            }
            else if (playerNum == 2 && Input.GetButtonDown("A_P2"))
            {
                pickedUp = false;
                Invoke("TurnOffPickUp", 0.2f);
            }
        }
    }

    IEnumerator OnTriggerStay(Collider other)
    {
        if (Input.GetButton("A_P1"))
        {
            if (playerNum == 1 && other.transform.tag == "Controllable" && inControl == false && pickedUp == false)
            {
                GetComponent<Controller_Movement>().enabled = false;
                GetComponent<Rigidbody>().velocity = Vector3.zero;
                GetComponent<SphereCollider>().enabled = false;
                objInControl = other.gameObject;
                transform.position = new Vector3(objInControl.transform.position.x, transform.position.y, objInControl.transform.position.z);
                yield return new WaitForFixedUpdate();
                yield return new WaitForFixedUpdate();

                TurnOnControl();
            }

            if (playerNum == 1 && other.transform.tag == "Bomb" && pickedUp == false)
            {
                if (!other.gameObject.GetComponent<Bomb>().lit)
                {
                    other.transform.parent.GetComponent<Bomb>().lit = true;
                }
            }

            if (playerNum == 1 && other.tag == "Health" && pickedUp == false)
            {
                GetComponent<SphereCollider>().enabled = false;
                objPickedUp = other.gameObject;
                yield return new WaitForFixedUpdate();
                yield return new WaitForFixedUpdate();

                TurnOnPickUp();
            }
        }
        else if (Input.GetButton("A_P2"))
        {
            if (playerNum == 2 && other.transform.tag == "Controllable" && inControl == false && pickedUp == false)
            {
                GetComponent<Controller_Movement>().enabled = false;
                GetComponent<Rigidbody>().velocity = Vector3.zero;
                GetComponent<SphereCollider>().enabled = false;
                objInControl = other.gameObject;
                transform.position = new Vector3(objInControl.transform.position.x, transform.position.y, objInControl.transform.position.z);
                yield return new WaitForFixedUpdate();
                yield return new WaitForFixedUpdate();

                TurnOnControl();
            }

            if (playerNum == 2 && other.transform.tag == "Bomb" && pickedUp == false)
            {
                if (!other.transform.parent.GetComponent<Bomb>().lit)
                {
                    other.transform.parent.GetComponent<Bomb>().lit = true;
                }
            }

            if (playerNum == 2 && other.tag == "Health" && pickedUp == false)
            {
                GetComponent<SphereCollider>().enabled = false;
                objPickedUp = other.gameObject;
                yield return new WaitForFixedUpdate();
                yield return new WaitForFixedUpdate();

                TurnOnPickUp();
            }
        }
        yield return null;
    }

    void TurnOnControl()
    {
        inControl = true;

        if(objInControl.GetComponent<Laser>() != null){
            objInControl.GetComponent<Laser>().controlled = true;
            objInControl.GetComponent<Laser>().active = false;
        }
    }

    void TurnOffControl()
    {
        GetComponent<SphereCollider>().enabled = true;
    }

    void TurnOnPickUp()
    {
        pickedUp = true;
    }

    void TurnOffPickUp()
    {
        GetComponent<SphereCollider>().enabled = true;
    }

    public void SetNumber()
    {
        playerNum = GetComponent<Controller_Movement>().playerNum;
    }
}
