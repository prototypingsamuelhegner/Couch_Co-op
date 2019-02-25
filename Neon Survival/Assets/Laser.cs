using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{

    Vector3[] waypoint = new Vector3[2];

    int current = 0;

    float speed;

    public float slowestSpeed;
    public float fastestSpeed;

    // Start is called before the first frame update
    void Start()
    {
        waypoint[0] = transform.GetChild(0).position;
        waypoint[1] = transform.GetChild(1).position;
        speed = Random.Range(slowestSpeed, fastestSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(transform.position, waypoint[current]);

        transform.position = Vector3.MoveTowards(transform.position, waypoint[current], Time.deltaTime * speed);

        if (dist < 0.5f) {
            speed = Random.Range(slowestSpeed, fastestSpeed);

            if (current == 0)
            {
                current += 1;
            }
            else {
                current -= 1;
            }
        }
    }
}
