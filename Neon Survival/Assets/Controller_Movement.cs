using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_Movement : MonoBehaviour
{
    public float speed;
    public float maxSpeed;

    [Range(0, 10)]
    public float speedLossPercentagePerSecond;

    [Range(1, 2)]
    public int playerNum;

    Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float hAxis;
        float yAxis;

        if (playerNum == 1)
        {
            hAxis = Input.GetAxis("Horizontal_P1");
            yAxis = Input.GetAxis("Vertical_P1");
        }
        else {
            hAxis = Input.GetAxis("Horizontal_P2");
            yAxis = Input.GetAxis("Vertical_P2");
        }
        

        rb.AddForce(new Vector3(hAxis, 0, yAxis) * speed, ForceMode.VelocityChange);

        rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);


        rb.velocity *= (1.0f - (speedLossPercentagePerSecond * Time.deltaTime));

        if (rb.velocity != Vector3.zero)
        transform.rotation = Quaternion.LookRotation(rb.velocity, transform.up);
    }

    public void SwtichPlayer() {
        if (playerNum == 1)
        {
            playerNum = 2;

            if (GetComponent<Take_Control>() != null)
            {
                GetComponent<Take_Control>().SetNumber();
            }
        }
        else if (playerNum == 2) {
            playerNum = 1;

            if (GetComponent<Take_Control>() != null)
            {
                GetComponent<Take_Control>().SetNumber();
            }
        }
        
    }
}

