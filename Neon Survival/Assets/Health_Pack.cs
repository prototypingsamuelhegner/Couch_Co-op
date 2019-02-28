using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health_Pack : MonoBehaviour
{
    GameObject player;

    public int healthToAdd;

    public float fleeDistance;

    public float fleeSpeed;

    public Vector3 placeToMove;

    public bool movingToPoint;

    public bool leaving;
    void Start()
    {
        player = GameObject.Find("Player Ship");
        movingToPoint = true;
    }

    void Update()
    {
        float dist = Vector3.Distance(player.transform.position, transform.position);

        if (dist < fleeDistance) {
            movingToPoint = false;
            Flee();
        }

        if(movingToPoint){
            MoveToPoint();
        }

        if(leaving){
            Leave();
        }
    }

    void Flee() {
        Vector3 fleeVector = transform.position - player.transform.position;

        fleeVector.Normalize();

        transform.Translate(fleeVector * Time.deltaTime * fleeSpeed);
    }

    void MoveToPoint(){
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(placeToMove.x, transform.position.y, placeToMove.z), Time.deltaTime * fleeSpeed);
    }

    void Leave(){
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(placeToMove.x, transform.position.y, placeToMove.z), Time.deltaTime * fleeSpeed);
        if(Vector3.Distance(transform.position, new Vector3(placeToMove.x, transform.position.y, placeToMove.z)) < 0.5f){
            Destroy(gameObject);
        }
    }

    

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") {
            other.GetComponent<Health>().AddHealth(healthToAdd);

            GameObject env = GameObject.Find("Player Environment");
            
            env.GetComponent<Take_Control>().pickedUp = false;
            env.GetComponent<Take_Control>().Invoke("TurnOffPickUp", 0.2f);

            Destroy(gameObject);
        }
    }
}
