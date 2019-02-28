using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scale_Up : MonoBehaviour
{
    Vector3 finalScale = new Vector3(1, 1, 1);

    Vector3 startScale = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = startScale;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, finalScale, Time.deltaTime);

        if(transform.localScale == finalScale){
            Destroy(this);
        }
    }
}
