using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit_Player : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player") {
            collision.transform.GetComponent<Health>().RemoveHealth(1);
            GetComponent<Seek_Player>().maxSpeed = 1;
            gameObject.SetActive(false);
        }
    }
}
