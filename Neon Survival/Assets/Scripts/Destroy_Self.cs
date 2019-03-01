using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_Self : MonoBehaviour
{
    float timer;
    public float timeTillDestroyed;
    // Start is called before the first frame update
    void Start()
    {
        timer = timeTillDestroyed;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0) {
            Destroy(gameObject);
        }
    }
}
