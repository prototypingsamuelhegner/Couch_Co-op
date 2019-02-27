using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health_Pack : MonoBehaviour
{
    GameObject player;

    public int healthToAdd;

    public float fleeDistance;

    public float fleeSpeed;

    void Start()
    {
        player = GameObject.Find("Player Ship");
    }

    void Update()
    {
        float dist = Vector3.Distance(player.transform.position, transform.position);

        if (dist < fleeDistance) {
            Flee();
        }
    }

    void Flee() {
        Vector3 fleeVector = transform.position - player.transform.position;

        fleeVector.Normalize();

        transform.Translate(fleeVector * Time.deltaTime * fleeSpeed);
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
