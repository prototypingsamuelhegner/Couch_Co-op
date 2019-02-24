using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public bool lit;

    public float fuseTimer;

    public float explosionActiveTime;

    List<GameObject> thingsHit = new List<GameObject>();

    void Start()
    {
        lit = false;
    }

    void Update()
    {
        if (lit) {
            fuseTimer -= Time.deltaTime;
        }

        if (fuseTimer <= 0) {
            Explode();
            fuseTimer = float.MaxValue;
        }
    }

    void Explode() {
        GetComponent<SphereCollider>().enabled = true;
        Invoke("DisableBomb", explosionActiveTime);
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player") {

        }

        if (other.tag == "Enemy") {
            print("Enemy");
            if (!thingsHit.Contains(other.gameObject)) {
                other.gameObject.SetActive(false);
                thingsHit.Add(other.gameObject);
            }
        }
    }

    private void DisableBomb()
    {
        GetComponent<SphereCollider>().enabled = false;
        Destroy(gameObject);
    }
}
