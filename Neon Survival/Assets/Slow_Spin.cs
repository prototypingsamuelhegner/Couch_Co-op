using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slow_Spin : MonoBehaviour
{
    public bool dir;

    float spinFloat;

    public float speed;

    public float minSpeed;
    public float maxSpeed;



    // Start is called before the first frame update
    void Start()
    {
        int ran = Random.Range(0, 2);
        

        speed = Random.Range(minSpeed, maxSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        if (dir == true)
        {
            spinFloat += Time.deltaTime * speed;
        }
        else {
            spinFloat -= Time.deltaTime * speed;
        }

        transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y + spinFloat, transform.rotation.z);
    }
}
