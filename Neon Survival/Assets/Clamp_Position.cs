using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clamp_Position : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(
   Mathf.Clamp(transform.position.x, -33, 33),
   Mathf.Clamp(transform.position.y, -5, 5),
   Mathf.Clamp(transform.position.z, -18, 18));
    }
}
